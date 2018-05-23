using System.Collections.Generic;

namespace Modele.ECommerce.Entites
{
    public class Statut
    {
        public int Id { get; set; }

        public string Libelle { get; set; }

        public List<Commande> Commandes { get; set; }
    }
}
