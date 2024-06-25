using BootCamp.MS.Library.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BootCamp.MS.Library.Application.Controllers
{
    public class libraryController
    {
        private readonly ILogger<libraryController> _logger;
        private readonly LibroService _libroService;

        public libraryController(ILogger<libraryController> logger, LibroService libroService)
        {
            _logger = logger;
            _libroService = libroService;
        }

        [Function("GetAllBooks")]
        public async Task<IActionResult> GetAll([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            
            var res = await _libroService.GetAll();
            return res.Success ? new OkObjectResult(res) : new BadRequestObjectResult(res);
        }

        [Function("CreateBook")]
        public async Task<IActionResult> CreateBook([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {

            var res = await _libroService.Create(req);
            return res.Success ? new OkObjectResult(res) : new BadRequestObjectResult(res);
        }


        [Function("UpdateBook")]
        public async Task<IActionResult> UpdateBook([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {

            var res = await _libroService.Update(req);
            return res.Success ? new OkObjectResult(res) : new BadRequestObjectResult(res);
        }
    }
}
