using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api")]
    public class FlashcardsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FlashcardsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("")]
        public IActionResult Test() 
            => Content($"Flashcards is working on '{_hostingEnvironment.EnvironmentName}'...");
    }
}
