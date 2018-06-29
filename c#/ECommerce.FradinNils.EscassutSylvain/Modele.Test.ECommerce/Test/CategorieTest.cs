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
    public class CategorieTest
    {
        private Categorie categorie;

        [TestMethod]
        public void GetAllCategoriesTest()
        {
            List<Categorie> categoriesOld = Manager.Instance.GetAllCategories();
            int oldCount = categoriesOld.Count();
            CreateCategorie();
            Manager.Instance.AddCategorie(this.categorie);
            List<Categorie> categoriesNew = Manager.Instance.GetAllCategories();
            Assert.AreEqual(oldCount + 1, categoriesNew.Count());
            DeleteCategorie();
        }

        [TestMethod]
        public void AddCategorieTest()
        {
            CreateCategorie();
            Manager.Instance.AddCategorie(this.categorie);
            List<Categorie> categories = Manager.Instance.GetAllCategories();
            Assert.AreEqual(this.categorie, categories.Last());
            DeleteCategorie();
        }

        [TestMethod]
        public void UpdateCategorieTest()
        {
            CreateCategorie();
            Manager.Instance.AddCategorie(this.categorie);
            this.categorie.Libelle = "TestCategorieUpdate";
            Categorie categorieUpdated = Manager.Instance.UpdateCategorie(this.categorie);
            Assert.AreEqual("TestCategorieUpdate", categorieUpdated.Libelle);
            DeleteCategorie();
        }

        [TestMethod]
        public void DeleteCategorieTest()
        {
            CreateCategorie();
            Manager.Instance.AddCategorie(this.categorie);
            Categorie categorieTmp = this.categorie;
            DeleteCategorie();
            List<Categorie> categories = Manager.Instance.GetAllCategories();
            if (categories.Count() > 0)
            {
                Assert.AreNotEqual(categorieTmp, categories.Last());
            }
        }

        private void CreateCategorie()
        {
            this.categorie = new Categorie();
            this.categorie.Actif = false;
            this.categorie.Libelle = "TestCategorie";
        }

        private void DeleteCategorie()
        {
            Manager.Instance.DeleteCategorie(this.categorie);
        }
    }
}
