using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarkodWeb.Areas.Ana.Controllers
{
    [AllowAnonymous]
    [Area("Ana")]
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> Basarisiz()
        {

            return View();
        }
    }
}
