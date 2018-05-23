using System.Collections.Generic;
using Modele.ECommerce.Entites;

namespace Modele.ECommerce.Entites
{
    public class CommandeProduit
    {


        public int ProduitId { get; set; }

        public Produit Produit { get; set; }

        public int CommandeId { get; set; }

        public Commande Commande { get; set; }

        public int Quantite { get; set; }
    }
}
