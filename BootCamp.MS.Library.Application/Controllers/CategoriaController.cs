using BootCamp.MS.Library.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BootCamp.MS.Library.Application.Controllers
{
    public class CategoriaController
    {
        private readonly ILogger<CategoriaController> _logger;

        private readonly CategoriaService _categoriaService ;

        public CategoriaController(ILogger<CategoriaController> logger, CategoriaService categoriaService)   
        {
            _logger = logger;
            _categoriaService = categoriaService;
        }

        [Function("GetAllCategories")]
        public async Task<IActionResult> GetAll([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {

            var res = await _categoriaService.GetAll();
            return res.Success ? new OkObjectResult(res) : new BadRequestObjectResult(res);
        }
    }
}
