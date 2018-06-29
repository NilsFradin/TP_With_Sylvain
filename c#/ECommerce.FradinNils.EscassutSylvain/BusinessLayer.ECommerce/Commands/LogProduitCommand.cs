using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Commands
{
    public class LogProduitCommand
    {
        private readonly ContextFluent _contexte;

        public LogProduitCommand(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public LogProduit Add(LogProduit logProduit)
        {
            _contexte.LogsProduits.Add(logProduit);
            _contexte.SaveChanges();

            return logProduit;
        }

        public LogProduit Update(LogProduit logProduit)
        {
            LogProduit lpDB = _contexte.LogsProduits.Where(lp => lp.Id == logProduit.Id).FirstOrDefault();
            if (lpDB != null)
            {
                lpDB.Id = logProduit.Id;
                lpDB.Message = logProduit.Message;
                lpDB.Produit = logProduit.Produit;
                lpDB.ProduitId = logProduit.ProduitId;
                lpDB.Date = logProduit.Date;
            }
            _contexte.SaveChanges();

            return lpDB;
        }

        public LogProduit Delete(LogProduit logProduit)
        {
            _contexte.LogsProduits.Remove(logProduit);
            _contexte.SaveChanges();

            return logProduit;
        }
    }
}
