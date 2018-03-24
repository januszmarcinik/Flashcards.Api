using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [HttpGet]
        public string Get()
            => "Flashcards works!";
    }
}
