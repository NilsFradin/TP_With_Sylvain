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
    public class LogProduitTest
    {
        private LogProduit logProduit;
        private Categorie categorie;
        private Produit produit;

        [TestMethod]
        public void GetAllLogsProduitsTest()
        {
            List<LogProduit> logsProduitsOld = Manager.Instance.GetAllLogsProduits();
            int oldCount = logsProduitsOld.Count();
            CreateLogProduit();
            Manager.Instance.AddLogProduit(this.logProduit);
            List<LogProduit> logsProduitsNew = Manager.Instance.GetAllLogsProduits();
            Assert.AreEqual(oldCount + 1, logsProduitsNew.Count());
            DeleteLogProduit();
        }

        [TestMethod]
        public void AddLogProduitTest()
        {
            CreateLogProduit();
            Manager.Instance.AddLogProduit(this.logProduit);
            List<LogProduit> logProduits = Manager.Instance.GetAllLogsProduits();
            Assert.AreEqual(this.logProduit, logProduits.Last());
            DeleteLogProduit();
        }

        [TestMethod]
        public void UpdateLogProduitTest()
        {
            CreateLogProduit();
            Manager.Instance.AddLogProduit(this.logProduit);
            this.logProduit.Message = "TestLogProduitUpdate";
            LogProduit logProduitUpdated = Manager.Instance.UpdateLogProduit(this.logProduit);
            Assert.AreEqual("TestLogProduitUpdate", logProduitUpdated.Message);
            DeleteLogProduit();
        }

        [TestMethod]
        public void DeleteLogProduitTest()
        {
            CreateLogProduit();
            Manager.Instance.AddLogProduit(this.logProduit);
            LogProduit logProduitTmp = this.logProduit;
            DeleteLogProduit();
            List<LogProduit> logsProduits = Manager.Instance.GetAllLogsProduits();
            if (logsProduits.Count() > 0)
            {
                Assert.AreNotEqual(logProduitTmp, logsProduits.Last());
            }
        }

        private void CreateLogProduit()
        {
            this.categorie = new Categorie();
            this.categorie.Actif = false;
            this.categorie.Libelle = "TestLogProduit";
            Manager.Instance.AddCategorie(this.categorie);

            this.produit = new Produit();
            this.produit.Actif = false;
            this.produit.Code = 0;
            this.produit.Description = "TestLogProduit";
            this.produit.Libelle = "TestLogProduit";
            this.produit.Prix = 0;
            this.produit.Stock = 0;
            this.produit.CategorieId = this.categorie.Id;
            Manager.Instance.AddProduit(this.produit);

            this.logProduit = new LogProduit();
            this.logProduit.Message = "TestLogProduit";
            this.logProduit.ProduitId = this.produit.Id;
        }

        private void DeleteLogProduit()
        {
            Manager.Instance.DeleteLogProduit(this.logProduit);
            Manager.Instance.DeleteProduit(this.produit);
            Manager.Instance.DeleteCategorie(this.categorie);
        }
    }
}
