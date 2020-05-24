using ConfigurationProviders.Samples.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationProviders.Samples.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IOptionsSnapshot<EmailServiceOptions> _options;

        public HomeController(IOptionsSnapshot<EmailServiceOptions> options)
        {
            _options = options;
        }

        [Route("api/email-service/key")] 
        public IActionResult Index()
        {
            return Ok(_options.Value.ApiKey);
        }
    }
}
