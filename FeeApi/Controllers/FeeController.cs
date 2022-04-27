using Microsoft.AspNetCore.Mvc;

namespace FeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeeController : ControllerBase
    {
        private static readonly float Fee = 0.01F;

        [Route("/TaxaJuros")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Fee);
        }
    }
}