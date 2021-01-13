using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.Sandbox.Dto;

namespace Swashbuckle.Sandbox.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("[controller]")]
    public class SwashbuckleController : ControllerBase
    {
        private readonly ILogger<SwashbuckleController> _logger;

        /// <inheritdoc />
        public SwashbuckleController(ILogger<SwashbuckleController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Adds a company to the scenario.
        /// </summary>
        [HttpPost]
        [Route("AddCompany")]
        public IActionResult AddCompany(AddCompanyRequest addCompanyRequest)
        {
            return Ok();
        }
    }
}
