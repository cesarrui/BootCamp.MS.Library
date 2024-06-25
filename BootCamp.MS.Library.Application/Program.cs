using Bootcamp.MS.Library.Domain;
using Bootcamp.MS.Library.Infrastructure;
using BootCamp.MS.Library.Application;
using BootCamp.MS.Library.Application.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;

var host = new HostBuilder()
     .ConfigureFunctionsWebApplication(builder => {

         //builder.UseMiddleware<AuthMiddleware>();

         builder.UseWhen<AuthMiddleware>((context) =>
         {

             return context.FunctionDefinition.InputBindings.Values
                           .First(a => a.Type.EndsWith("Trigger")).Type == "httpTrigger";
         });

     })
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        var configuration = context.Configuration;
        var connectionString = configuration.GetConnectionString("dbLibrary");
        services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));

        services.AddScoped<LibroService>();
        services.AddScoped<ILibroRepository, LibroRepoitory>();

        services.AddScoped<CategoriaService>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();

        services.AddScoped<AutorService>();
        services.AddScoped<IAutorRepository, AutorRepository>();

        services.AddScoped<EditorialService>();
        services.AddScoped<IEditorialRepository, EditorialRepository>();

        services.AddScoped<IDataAccesRepository, GenericRepository>();
        services.AddHttpClient<AuthMiddleware>();
    })
    .Build();

host.Run();
