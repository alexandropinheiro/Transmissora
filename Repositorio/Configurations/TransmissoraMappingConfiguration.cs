using Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio.Configurations
{
    public class TransmissoraMappingConfiguration : EntityTypeConfiguration<Transmissora>
    {
        public TransmissoraMappingConfiguration()
        {
            ToTable("TRANSMISSORA");
            HasKey(t => t.Id);
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
