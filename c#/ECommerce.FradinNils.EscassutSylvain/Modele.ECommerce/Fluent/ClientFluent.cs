using Modele.ECommerce.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Modele.ECommerce.Fluent
{
    public class ClientFluent : EntityTypeConfiguration<Client>
    {
        public ClientFluent()
        {
            ToTable("APP_CLIENT");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CLI_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nom).HasColumnName("CLI_NOM").IsRequired().HasMaxLength(255);
            Property(c => c.Prenom).HasColumnName("CLI_PRENOM").IsRequired().HasMaxLength(255);
            Property(c => c.Actif).HasColumnName("CLI_ACTIF").IsRequired();
        }
    }
}
