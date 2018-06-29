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
    public class StatutTest
    {
        private Statut statut;

        [TestMethod]
        public void GetAllStatutsTest()
        {
            List<Statut> statutsOld = Manager.Instance.GetAllStatuts();
            int oldCount = statutsOld.Count();
            CreateStatut();
            Manager.Instance.AddStatut(this.statut);
            List<Statut> statutsNew = Manager.Instance.GetAllStatuts();
            Assert.AreEqual(oldCount + 1, statutsNew.Count());
            DeleteStatut();
        }

        [TestMethod]
        public void AddStatutTest()
        {
            CreateStatut();
            Manager.Instance.AddStatut(this.statut);
            List<Statut> statuts = Manager.Instance.GetAllStatuts();
            Assert.AreEqual(this.statut, statuts.Last());

            DeleteStatut();
        }

        [TestMethod]
        public void UpdateStatutTest()
        {
            CreateStatut();
            Manager.Instance.AddStatut(this.statut);
            this.statut.Libelle = "TestStatutUpdate";
            Statut statutUpdated = Manager.Instance.UpdateStatut(this.statut);
            Assert.AreEqual("TestStatutUpdate", statutUpdated.Libelle);
            DeleteStatut();
        }

        [TestMethod]
        public void DeleteStatutTest()
        {
            CreateStatut();
            Manager.Instance.AddStatut(this.statut);
            Statut statutTmp = this.statut;
            DeleteStatut();
            List<Statut> statuts = Manager.Instance.GetAllStatuts();
            if (statuts.Count() > 0)
            {
                Assert.AreNotEqual(statutTmp, statuts.Last());
            }
        }

        private void CreateStatut()
        {
            this.statut = new Statut();
            this.statut.Libelle = "TestStatut";
        }

        private void DeleteStatut()
        {
            Manager.Instance.DeleteStatut(this.statut);
        }
    }
}
