using Gauss.ProjetoTcc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gauss.ProjetoTcc.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Funcao, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Noticia> Categorias { get; set; }
    }
}