using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Commands
{
    public class CommandeProduitCommand
    {
        private readonly ContextFluent _contexte;

        public CommandeProduitCommand(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public CommandeProduit Add(CommandeProduit commandeProduit)
        {
            _contexte.CommandesProduits.Add(commandeProduit);
            _contexte.SaveChanges();

            return commandeProduit;
        }

        public CommandeProduit Update(CommandeProduit commandeProduit)
        {
            CommandeProduit cpDB = _contexte.CommandesProduits.Where(cp => cp.ProduitId == commandeProduit.ProduitId).Where(cp => cp.CommandeId == commandeProduit.CommandeId).FirstOrDefault();
            if (cpDB != null)
            {
                cpDB.Commande = commandeProduit.Commande;
                cpDB.CommandeId = commandeProduit.CommandeId;
                cpDB.Produit = commandeProduit.Produit;
                cpDB.ProduitId = commandeProduit.ProduitId;
                cpDB.Quantite = commandeProduit.Quantite;
            }
            _contexte.SaveChanges();

            return cpDB;
        }

        public CommandeProduit Delete(CommandeProduit commandeProduit)
        {
            _contexte.CommandesProduits.Remove(commandeProduit);
            _contexte.SaveChanges();

            return commandeProduit;
        }
    }
}
