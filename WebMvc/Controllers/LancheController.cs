using Microsoft.AspNetCore.Mvc;
using WebMvc.Repositories;
using WebMvc.Repositories.Interfaces;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";
               
            return View(lanchesListViewModel);
        }
    }
}
