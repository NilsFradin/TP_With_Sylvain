using System.Collections.Generic;

namespace Modele.ECommerce.Entites
{
    public class Client
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public bool Actif { get; set; }

        public List<Commande> Commandes { get; set; }
    }
}
