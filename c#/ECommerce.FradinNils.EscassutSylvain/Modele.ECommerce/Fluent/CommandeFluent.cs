using Modele.ECommerce.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Modele.ECommerce.Fluent
{
    public class CommandeFluent : EntityTypeConfiguration<Commande>
    { 
        public CommandeFluent()
        {
            ToTable("APP_COMMANDE");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CMD_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.DateCommande).HasColumnName("CMD_DATECOMMANDE").IsRequired();
            Property(c => c.Observation).HasColumnName("CMD_OBSERVATION").IsRequired().HasMaxLength(255);
            Property(c => c.StatutId).HasColumnName("CMD_STATUTID");
            Property(c => c.ClientID).HasColumnName("CMD_CLIENTID");

            HasRequired(c => c.Client).WithMany(cli => cli.Commandes).HasForeignKey(c => c.ClientID);
            HasRequired(c => c.Statut).WithMany(st => st.Commandes).HasForeignKey(c => c.StatutId);
        }
    }
}
