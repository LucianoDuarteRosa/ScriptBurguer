using Microsoft.EntityFrameworkCore;
using WebMvc.Context;
using WebMvc.Models;
using WebMvc.Repositories.Interfaces;

namespace WebMvc.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesEmPromocao => _context.Lanches.
            Where(r => r.EmPromocao).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(r => r.LancheId == lancheId);
        }
    }
}
