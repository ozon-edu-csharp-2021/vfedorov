namespace OzonEdu.MerchandiseService
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("/")]
    [ApiController]
    public class RootStubController : ControllerBase
    {
        private readonly ILogger<RootStubController> logger;
        public RootStubController(ILogger<RootStubController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            logger.LogInformation("Stub has been called");

            return "Hello from the Merchandise API!";
        }
    }
}
