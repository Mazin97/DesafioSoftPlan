using Microsoft.AspNetCore.Mvc;

namespace CompoundCalcApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ILogger<ShowMeTheCodeController> _logger;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok("https://github.com/Mazin97/DesafioSoftPlan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
