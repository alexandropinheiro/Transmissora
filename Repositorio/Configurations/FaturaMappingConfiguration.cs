using Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repositorio.Configurations
{
    public class FaturaMappingConfiguration : EntityTypeConfiguration<Fatura>
    {
        public FaturaMappingConfiguration()
        {
            ToTable("FATURA");
            HasKey(t => t.Id);
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(f => f.Transmissora)
                .WithMany(t => t.Faturas)
                .Map(f => f.MapKey("IDTRANSMISSORA"));
        }
    }
}
