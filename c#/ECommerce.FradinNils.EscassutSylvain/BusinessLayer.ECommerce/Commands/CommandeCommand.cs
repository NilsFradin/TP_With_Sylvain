using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Fluent;
using Modele.ECommerce.Entites;

namespace BusinessLayer.ECommerce.Commands
{
    public class CommandeCommand
    {
        private readonly ContextFluent _contexte;

        public CommandeCommand(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public Commande Add(Commande commande)
        {
            _contexte.Commandes.Add(commande);
            _contexte.SaveChanges();

            return commande;
        }

        public Commande Update(Commande commande)
        {
            Commande cDB = _contexte.Commandes.Where(c => c.Id == commande.Id).FirstOrDefault();
            if (cDB != null)
            {
                cDB.Id = commande.Id;
                cDB.Client = commande.Client;
                cDB.ClientID = commande.ClientID;
                cDB.CommandesProduits = commande.CommandesProduits;
                cDB.DateCommande = commande.DateCommande;
                cDB.Observation = commande.Observation;
                cDB.Statut = commande.Statut;
                cDB.StatutId = commande.StatutId;
            }
            _contexte.SaveChanges();

            return cDB;
        }

        public Commande Delete(Commande commande)
        {
            _contexte.Commandes.Remove(commande);
            _contexte.SaveChanges();

            return commande;
        }
    }
}
