using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modele.ECommerce;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Queries
{
    public class ProduitQuery
    {
        private readonly ContextFluent _contexte;

        public ProduitQuery(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Produit> GetAll()
        {
            return _contexte.Produits;
        }

        public IQueryable<Produit> GetByID(int id)
        {
            return _contexte.Produits.Where(p => p.Id == id);
        }

        public IQueryable<int> GetStockByCode(int code)
        {
            return _contexte.Produits.Where(p => p.Code == code).Select(p => p.Stock);
        }

        public Produit Add(Produit produit)
        {
            _contexte.Produits.Add(produit);
            return produit;
        }

        public Produit Delete(Produit produit)
        {
            _contexte.Produits.Remove(produit);
            return produit;
        }
    }
}
