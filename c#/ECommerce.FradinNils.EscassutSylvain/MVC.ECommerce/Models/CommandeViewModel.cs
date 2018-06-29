using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modele.ECommerce.Entites;

namespace MVC.ECommerce.Models
{
    public class CommandeViewModel
    {
        public CommandeViewModel(Commande c)
        {
            this.Id = c.Id;
            this.DateCommande = c.DateCommande;
            this.Observation = c.Observation;
            this.StatutId = c.StatutId;
            this.Statut = c.Statut;
            this.ClientID = c.ClientID;
            this.Client = c.Client;
            this.CommandesProduits = c.CommandesProduits;
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