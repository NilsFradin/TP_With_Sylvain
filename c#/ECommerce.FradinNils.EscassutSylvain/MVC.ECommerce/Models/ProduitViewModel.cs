using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modele.ECommerce.Entites;

namespace MVC.ECommerce.Models
{
    public class ProduitViewModel
    {
        public ProduitViewModel()
        {

        }

        public ProduitViewModel(Produit p)
        {
            this.Id = p.Id;
            this.Code = p.Code;
            this.Libelle = p.Libelle;
            this.Description = p.Description;
            this.Actif = p.Actif;
            this.Prix = p.Prix;
            this.Stock = p.Stock;
            this.CategorieId = p.CategorieId;
            this.Categorie = p.Categorie;
            this.LogProduits = p.LogProduits;
            this.CommandesProduits = p.CommandesProduits;
        }

        public int Id { get; set; }

        public int Code { get; set; }

        public string Libelle { get; set; }

        public string Description { get; set; }

        public bool Actif { get; set; }

        public float Prix { get; set; }

        public int Stock { get; set; }

        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }

        public List<LogProduit> LogProduits { get; set; }

        public List<CommandeProduit> CommandesProduits { get; set; }

        public Produit Converte()
        {
            Produit aRetourner = new Produit();
            aRetourner.Stock = this.Stock;
            aRetourner.Id = this.Id;
            aRetourner.Code = this.Code;
            aRetourner.Libelle = this.Libelle;
            aRetourner.Description = this.Description;
            aRetourner.Actif = this.Actif;
            aRetourner.Prix = this.Prix;
            aRetourner.CategorieId = this.CategorieId;
            aRetourner.Categorie = this.Categorie;
            aRetourner.LogProduits = this.LogProduits;
            aRetourner.CommandesProduits = this.CommandesProduits;

            return aRetourner;
        }
    }
}