using Modele.ECommerce.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Modele.ECommerce.Fluent
{
    public class ProduitFluent : EntityTypeConfiguration<Produit>
    {
        public ProduitFluent()
        {
            ToTable("APP_PRODUIT");
            HasKey(p => p.Id);

            Property(p => p.Id).HasColumnName("PRD_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Code).HasColumnName("PRD_CODE").IsRequired();
            Property(p => p.Libelle).HasColumnName("PRD_LIBELLE").IsRequired().HasMaxLength(255);
            Property(p => p.Description).HasColumnName("PRD_DESCRIPTION").IsRequired().HasMaxLength(255);
            Property(p => p.Actif).HasColumnName("PRD_ACTIF").IsRequired();
            Property(p => p.Prix).HasColumnName("PRD_PRIX").IsRequired();
            Property(p => p.Stock).HasColumnName("PRD_STOCK").IsRequired();
            Property(p => p.CategorieId).HasColumnName("PRD_CATEGORIEID");

            HasRequired(p => p.Categorie).WithMany(c => c.Produits).HasForeignKey(p => p.CategorieId);
        }
    }
}
