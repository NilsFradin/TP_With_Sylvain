using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Commands
{
    public class ProduitCommand
    {
        private readonly ContextFluent _contexte;

        public ProduitCommand(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public Produit Add(Produit produit)
        {
            _contexte.Produits.Add(produit);
            _contexte.SaveChanges();

            return produit;
        }

        public Produit Update(Produit produit)
        {
            Produit pDB = _contexte.Produits.Where(p => p.Id == produit.Id).FirstOrDefault();
            if (pDB != null)
            {
                pDB.Stock = produit.Stock;
                pDB.Id = produit.Id;
                pDB.Code = produit.Code;
                pDB.Libelle = produit.Libelle;
                pDB.Description = produit.Description;
                pDB.Actif = produit.Actif;
                pDB.Prix = produit.Prix;
                pDB.CategorieId = produit.CategorieId;
                pDB.Categorie = produit.Categorie;
                pDB.LogProduits = produit.LogProduits;
                pDB.CommandesProduits = produit.CommandesProduits;
            }
            _contexte.SaveChanges();

            return pDB;
        }

        public Produit Delete(Produit produit)
        {
            _contexte.Produits.Remove(produit);
            _contexte.SaveChanges();

            return produit;
        }
    }
}
