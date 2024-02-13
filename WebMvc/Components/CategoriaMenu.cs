using Microsoft.AspNetCore.Mvc;
using WebMvc.Repositories.Interfaces;

namespace WebMvc.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(i => i.CategoriaNome);
            return View(categorias);
        }
    }
}
