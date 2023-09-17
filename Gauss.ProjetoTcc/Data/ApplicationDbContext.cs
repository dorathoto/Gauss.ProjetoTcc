using Gauss.ProjetoTcc.Models;
using Gauss.ProjetoTcc.Models.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Configuration;

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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Usuario>();
        //}

        private void ModelStatusModificacao<T>(EntityTypeBuilder<T> entity) where T : class, IStatusModificacao
        {
            entity.HasQueryFilter(x => !x.Excluido);
            entity.Property(x => x.DataExcluido).HasColumnType("datetime2(2)");
            entity.Property(x => x.DataCadastro).HasColumnType("datetime2(2)");
            entity.Property(x => x.DataUltimaModificacao).HasColumnType("datetime2(2)");
        }
       
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            PreencheIStatusModificacao();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            PreencheIStatusModificacao();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void PreencheIStatusModificacao()
        {

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity != null
                        && typeof(IStatusModificacao).IsAssignableFrom(e.Entity.GetType())))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataUltimaModificacao").CurrentValue = DateTime.Now;
                    entry.Property("DataCadastro").IsModified = false;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("DataExcluido").CurrentValue = DateTime.Now;
                    entry.Property("Excluido").CurrentValue = true;
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

        }

        public DbSet<Gauss.ProjetoTcc.Models.Categoria> Categoria { get; set; }
    }
}
