using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modele.ECommerce;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;
using BusinessLayer.ECommerce.Queries;

namespace BusinessLayer.ECommerce
{
    public class Manager
    {
        private readonly ContextFluent contexte;
        private static Manager _businessManager = null;

        private Manager()
        {
            contexte = new ContextFluent();
        }

        public static Manager Instance
        {
            get
            {
                if (_businessManager == null)
                    _businessManager = new Manager();
                return _businessManager;
            }
        }

        #region Produits

        public List<Produit> GetAllProduits()
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetAll().ToList();
        }

        public Produit GetProduitById(int id)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetByID(id).ToList().First();
        }

        public List<Commande> GetAllCommandes()
        {
            CommandeQuery cq = new CommandeQuery(contexte);
            return cq.GetAll().ToList();
        }

        public int GetStockByCode(int code)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetStockByCode(code).ToList().First();
        }
       
        #endregion
    }
}
