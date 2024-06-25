using BootCamp.MS.Library.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BootCamp.MS.Library.Application.Controllers
{
    public class AutorController
    {
        private readonly ILogger<AutorController> _logger;

        private readonly AutorService _autorService;

        public AutorController(ILogger<AutorController> logger, AutorService autorService)
        {
            _logger = logger;
            _autorService = autorService;
        }

        [Function("GetAllAutors")]
        public async Task<IActionResult> GetAll([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {

            var res = await _autorService.GetAll();
            return res.Success ? new OkObjectResult(res) : new BadRequestObjectResult(res);
        }
    }
}
