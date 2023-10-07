using Microsoft.AspNetCore.Mvc;

namespace Tarteeb.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Get() =>
            "Hello Mario, Princess is in another castle";
    }
}
