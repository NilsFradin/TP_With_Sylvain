using Modele.ECommerce.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Modele.ECommerce.Fluent
{
    public class LogProduitFluent : EntityTypeConfiguration<LogProduit>
    {
        public LogProduitFluent()
        {
            ToTable("APP_LOGPRODUIT");
            HasKey(l => l.Id);

            Property(l => l.Id).HasColumnName("LOG_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(l => l.Message).HasColumnName("LOG_MESSAGE").IsRequired().HasMaxLength(255);
            Property(l => l.Date).HasColumnName("LOG_DATE").IsRequired();
            Property(l => l.ProduitId).HasColumnName("LOG_PRODUITID");

            HasRequired(l => l.Produit).WithMany(p => p.LogProduits).HasForeignKey(l => l.ProduitId);
        }
    }
}
