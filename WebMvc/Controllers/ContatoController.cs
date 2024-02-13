using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
