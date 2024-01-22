using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebMvc.Models;

namespace WebMvc.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }


    }
}
