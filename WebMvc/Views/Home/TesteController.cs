using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Views.Home
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
