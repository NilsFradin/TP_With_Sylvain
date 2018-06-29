using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.ECommerce;
using Modele.ECommerce.Entites;

namespace Modele.Test.ECommerce.Test
{
    [TestClass]
    public class ProduitTest
    {
        private Produit produit;
        private Categorie categorie;

        [TestMethod]
        public void GetAllProduitsTest()
        {
            List<Produit> produitsOld = Manager.Instance.GetAllProduits();
            int oldCount = produitsOld.Count();
            CreateProduit();
            Manager.Instance.AddProduit(this.produit);
            List<Produit> produitsNew = Manager.Instance.GetAllProduits();
            Assert.AreEqual(oldCount + 1, produitsNew.Count());
            DeleteProduit();
        }

        [TestMethod]
        public void AddProduitTest()
        {
            CreateProduit();
            Manager.Instance.AddProduit(this.produit);
            List<Produit> produits = Manager.Instance.GetAllProduits();
            Assert.AreEqual(this.produit, produits.Last());
            DeleteProduit();
        }

        [TestMethod]
        public void UpdateProduitTest()
        {
            CreateProduit();
            Manager.Instance.AddProduit(this.produit);
            this.produit.Description = "TestProduitUpdate";
            this.produit.Libelle = "TestProduitUpdate";
            Produit produitUpdated = Manager.Instance.UpdateProduit(this.produit);
            Assert.AreEqual("TestProduitUpdate", produitUpdated.Description);
            Assert.AreEqual("TestProduitUpdate", produitUpdated.Libelle);
            DeleteProduit();
        }

        [TestMethod]
        public void DeleteProduitTest()
        {
            CreateProduit();
            Manager.Instance.AddProduit(this.produit);
            Produit produitTmp = this.produit;
            DeleteProduit();
            List<Produit> produits = Manager.Instance.GetAllProduits();
            if (produits.Count() > 0)
            {
                Assert.AreNotEqual(produitTmp, produits.Last());
            }
        }

        private void CreateProduit()
        {
            this.categorie = new Categorie();
            this.categorie.Actif = false;
            this.categorie.Libelle = "TestProduit";
            Manager.Instance.AddCategorie(this.categorie);

            this.produit = new Produit();
            this.produit.Actif = false;
            this.produit.Code = 0;
            this.produit.Description = "TestProduit";
            this.produit.Libelle = "TestProduit";
            this.produit.Prix = 0;
            this.produit.Stock = 0;
            this.produit.CategorieId = this.categorie.Id;
        }

        private void DeleteProduit()
        {
            Manager.Instance.DeleteProduit(this.produit);
            Manager.Instance.DeleteCategorie(this.categorie);
        }
    }
}
