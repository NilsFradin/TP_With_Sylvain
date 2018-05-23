using Modele.ECommerce.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Modele.ECommerce.Fluent
{
    public class CategorieFluent : EntityTypeConfiguration<Categorie>
    {
        public CategorieFluent()
        {
            ToTable("APP_CATEGORIE");
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("CAT_ID").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Libelle).HasColumnName("CAT_LIBELLE").IsRequired().HasMaxLength(255);
            Property(c => c.Actif).HasColumnName("CAT_ACTIF").IsRequired();
        }
    }
}
