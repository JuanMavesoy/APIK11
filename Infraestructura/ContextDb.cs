using Dominio.Entidad;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class ContextDb : DbContext
    {
        public ContextDb() { }

        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<User> users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}