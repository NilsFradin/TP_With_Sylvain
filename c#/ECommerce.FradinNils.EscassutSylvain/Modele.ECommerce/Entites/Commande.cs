using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ECommerce.Entites
{
    public class Commande
    {
        public Commande()
        {
            DateCommande = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime DateCommande { get; set; }

        public string Observation { get; set; }

        public int StatutId { get; set; }

        public Statut Statut { get; set; }

        public int ClientID { get; set; }

        public Client Client { get; set; }

        public List<CommandeProduit> CommandesProduits { get; set; }
    }
}
