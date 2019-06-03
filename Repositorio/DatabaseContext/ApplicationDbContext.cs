using Dominio.Entidades;
using Repositorio.Configurations;
using System.Data.Entity;

namespace Repositorio.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Transmissora> Transmissoras { get; set; }
        public DbSet<Fatura> Faturas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TransmissoraMappingConfiguration());
            modelBuilder.Configurations.Add(new FaturaMappingConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
