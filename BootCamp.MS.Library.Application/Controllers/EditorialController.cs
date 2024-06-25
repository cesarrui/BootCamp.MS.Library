using BootCamp.MS.Library.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BootCamp.MS.Library.Application.Controllers
{
    public class EditorialController
    {
        private readonly ILogger<EditorialController> _logger;

        private readonly EditorialService _editorialService;

        public EditorialController(ILogger<EditorialController> logger, EditorialService editorialService)
        {
            _logger = logger;
            _editorialService = editorialService;
            
        }

        [Function("GetAllEditorials")]
        public async Task<IActionResult> GetAll([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {

            var res = await _editorialService.GetAll();
            return res.Success ? new OkObjectResult(res) : new BadRequestObjectResult(res);
        }
    }
}
