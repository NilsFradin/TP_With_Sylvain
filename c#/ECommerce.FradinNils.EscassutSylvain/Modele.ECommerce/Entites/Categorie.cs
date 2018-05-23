using System.Collections.Generic;

namespace Modele.ECommerce.Entites
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Libelle { get; set; }

        public bool Actif { get; set; }

        public List<Produit> Produits { get; set; }
    }
}
