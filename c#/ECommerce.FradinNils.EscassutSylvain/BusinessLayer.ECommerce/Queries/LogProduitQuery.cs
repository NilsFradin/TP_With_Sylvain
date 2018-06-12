using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Queries
{
    public class LogProduitQuery
    {
        private readonly ContextFluent _contexte;

        public LogProduitQuery(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<LogProduit> GetAll()
        {
            return _contexte.LogsProduits;
        }

        public LogProduit Add(LogProduit logProduit)
        {
            _contexte.LogsProduits.Add(logProduit);
            return logProduit;
        }

        public LogProduit Delete(LogProduit logProduit)
        {
            _contexte.LogsProduits.Remove(logProduit);
            return logProduit;
        }
    }
}
