using Modele.ECommerce.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Modele.ECommerce.Fluent
{
    public class CommandeProduitFluent : EntityTypeConfiguration<CommandeProduit>
    {
        public CommandeProduitFluent()
        {
            ToTable("APP_COMMANDEPRODUIT");
            HasKey(cp => new { cp.CommandeId, cp.ProduitId });

            Property(cp => cp.ProduitId).HasColumnName("CPD_PRODUITID");
            Property(cp => cp.CommandeId).HasColumnName("CPD_COMMANDEID");
            Property(cp => cp.Quantite).HasColumnName("CPD_QUANTITE").IsRequired();

            HasRequired(cp => cp.Commande).WithMany(c => c.CommandesProduits).HasForeignKey(cp => cp.CommandeId);
            HasRequired(cp => cp.Produit).WithMany(p => p.CommandesProduits).HasForeignKey(cp => cp.ProduitId);
        }
    }
}