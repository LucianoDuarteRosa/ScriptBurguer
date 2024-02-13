using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LancheEmPromocao { get; set; }
    }
}
