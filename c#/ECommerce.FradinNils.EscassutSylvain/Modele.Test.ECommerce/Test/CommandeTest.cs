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
    public class CommandeTest
    {
        private Commande commande;
        private Client client;
        private Statut statut;

        [TestMethod]
        public void GetAllCommandesTest()
        {
            List<Commande> commandesOld = Manager.Instance.GetAllCommandes();
            int oldCount = commandesOld.Count();
            CreateCommande();
            Manager.Instance.AddCommande(this.commande);
            List<Commande> commandesNew = Manager.Instance.GetAllCommandes();
            Assert.AreEqual(oldCount + 1, commandesNew.Count());
            DeleteCommande();
        }

        [TestMethod]
        public void AddCommandeTest()
        {
            CreateCommande();
            Manager.Instance.AddCommande(this.commande);
            List<Commande> commandes = Manager.Instance.GetAllCommandes();
            Assert.AreEqual(this.commande, commandes.Last());

            DeleteCommande();
        }

        [TestMethod]
        public void UpdateCommandeTest()
        {
            CreateCommande();
            Manager.Instance.AddCommande(this.commande);
            this.commande.Observation = "TestCommandeUpdate";
            Commande commandeUpdated = Manager.Instance.UpdateCommande(this.commande);
            Assert.AreEqual("TestCommandeUpdate", commandeUpdated.Observation);
            DeleteCommande();
        }

        [TestMethod]
        public void DeleteCommandeTest()
        {
            CreateCommande();
            Manager.Instance.AddCommande(this.commande);
            Commande commandeTmp = this.commande;
            DeleteCommande();
            List<Commande> commandes = Manager.Instance.GetAllCommandes();
            if (commandes.Count() > 0)
            {
                Assert.AreNotEqual(commandeTmp, commandes.Last());
            }
        }

        private void CreateCommande()
        {
            this.client = new Client();
            this.client.Actif = false;
            this.client.Nom = "TestCommande";
            this.client.Prenom = "TestCommande";
            Manager.Instance.AddClient(this.client);

            this.statut = new Statut();
            this.statut.Libelle = "TestCommande";
            Manager.Instance.AddStatut(this.statut);

            this.commande = new Commande();
            this.commande.Observation = "TestCommande";
            this.commande.ClientID = this.client.Id;
            this.commande.StatutId = this.statut.Id;
        }

        private void DeleteCommande()
        {
            Manager.Instance.DeleteCommande(this.commande);
            Manager.Instance.DeleteStatut(this.statut);
            Manager.Instance.DeleteClient(this.client);
        }
    }
}
