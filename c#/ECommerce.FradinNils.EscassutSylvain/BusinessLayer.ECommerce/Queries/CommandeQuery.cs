﻿using Modele.ECommerce.Fluent;
using Modele.ECommerce.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ECommerce.Queries
{
    public class CommandeQuery
    {
        private readonly ContextFluent _contexte;

        public CommandeQuery(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Commande> GetAll()
        {
            return _contexte.Commandes;
        }

        public IQueryable<Commande> GetFiveCommande()
        {
            return _contexte.Commandes.OrderByDescending(c => c.DateCommande).Take(5);
        }
    }
}
