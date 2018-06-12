using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Queries
{
    public class CommandeProduitQuery
    {
        private readonly ContextFluent _contexte;

        public CommandeProduitQuery(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<CommandeProduit> GetAll()
        {
            return _contexte.CommandesProduits;
        }

        public CommandeProduit Add(CommandeProduit commandeProduit)
        {
            _contexte.CommandesProduits.Add(commandeProduit);
            return commandeProduit;
        }

        public CommandeProduit Delete(CommandeProduit commandeProduit)
        {
            _contexte.CommandesProduits.Remove(commandeProduit);
            return commandeProduit;
        }
    }
}
