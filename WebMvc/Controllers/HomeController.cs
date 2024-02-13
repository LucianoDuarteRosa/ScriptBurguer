using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMvc.Models;
using WebMvc.Repositories.Interfaces;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancherepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancherepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LancheEmPromocao = _lancherepository.LanchesEmPromocao
            };
            return View(homeViewModel);
        }

        public IActionResult List()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
