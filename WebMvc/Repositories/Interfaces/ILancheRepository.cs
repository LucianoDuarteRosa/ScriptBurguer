using WebMvc.Models;

namespace WebMvc.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesEmPromocao { get; }
        Lanche GetLancheById(int lancheId);
    }
}
