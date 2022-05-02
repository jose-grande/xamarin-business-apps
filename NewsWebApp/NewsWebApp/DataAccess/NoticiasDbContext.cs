using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsWebApp.DataAccess
{
    public class NoticiasDbContext: DbContext
    {
        public NoticiasDbContext(DbContextOptions<NoticiasDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().Property(c => c.Nombre)
                .HasMaxLength(500)
                .IsRequired();
            modelBuilder.Entity<Noticia>().HasOne<Categoria>(c => c.Categoria)
                .WithMany(c => c.Noticias)
                .HasForeignKey(c => c.CategoriaId);
        }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
