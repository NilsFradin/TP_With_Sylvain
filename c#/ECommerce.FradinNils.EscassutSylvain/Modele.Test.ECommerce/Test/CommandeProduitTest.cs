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
    public class CommandeProduitTest
    {
        private CommandeProduit commandeProduit;
        private Categorie categorie;
        private Produit produit;
        private Statut statut;
        private Client client;
        private Commande commande;

        [TestMethod]
        public void GetAllCommandesProduitsTest()
        {
            List<CommandeProduit> commandesProduitsOld = Manager.Instance.GetAllCommandesProduits();
            int oldCount = commandesProduitsOld.Count();
            CreateCommandeProduit();
            Manager.Instance.AddCommandeProduit(this.commandeProduit);
            List<CommandeProduit> commandesProduitsNew = Manager.Instance.GetAllCommandesProduits();
            Assert.AreEqual(oldCount + 1, commandesProduitsNew.Count());
            DeleteCommandeProduit();
        }

        [TestMethod]
        public void AddCommandeProduitTest()
        {
            CreateCommandeProduit();
            Manager.Instance.AddCommandeProduit(this.commandeProduit);
            List<CommandeProduit> commandesProduits = Manager.Instance.GetAllCommandesProduits();
            Assert.AreEqual(this.commandeProduit, commandesProduits.Last());

            DeleteCommandeProduit();
        }

        [TestMethod]
        public void UpdateCommandeProduitTest()
        {
            CreateCommandeProduit ();
            Manager.Instance.AddCommandeProduit(this.commandeProduit);
            this.commandeProduit.Quantite = 1111;
            CommandeProduit commandeProduitUpdated = Manager.Instance.UpdateCommandeProduit(this.commandeProduit);
            Assert.AreEqual(1111, commandeProduitUpdated.Quantite);
            DeleteCommandeProduit();
        }

        [TestMethod]
        public void DeleteCommandeProduitTest()
        {
            CreateCommandeProduit();
            Manager.Instance.AddCommandeProduit(this.commandeProduit);
            CommandeProduit commandeProduitTmp = this.commandeProduit;
            DeleteCommandeProduit();
            List<CommandeProduit> commandesProduits = Manager.Instance.GetAllCommandesProduits();
            if (commandesProduits.Count() > 0)
            {
                Assert.AreNotEqual(commandeProduitTmp, commandesProduits.Last());
            }
        }

        private void CreateCommandeProduit()
        {
            this.client = new Client();
            this.client.Actif = false;
            this.client.Nom = "TestCommandeProduit";
            this.client.Prenom = "TestCommandeProduit";
            Manager.Instance.AddClient(this.client);

            this.statut = new Statut();
            this.statut.Libelle = "TestCommandeProduit";
            Manager.Instance.AddStatut(this.statut);

            this.commande = new Commande();
            this.commande.Observation = "TestCommandeProduit";
            this.commande.ClientID = this.client.Id;
            this.commande.StatutId = this.statut.Id;
            Manager.Instance.AddCommande(this.commande);

            this.categorie = new Categorie();
            this.categorie.Actif = false;
            this.categorie.Libelle = "TestCommandeProduit";
            Manager.Instance.AddCategorie(this.categorie);

            this.produit = new Produit();
            this.produit.Actif = false;
            this.produit.Code = 0;
            this.produit.Description = "TestCommandeProduit";
            this.produit.Libelle = "TestCommandeProduit";
            this.produit.Prix = 0;
            this.produit.Stock = 0;
            this.produit.CategorieId = this.categorie.Id;
            Manager.Instance.AddProduit(this.produit);

            this.commandeProduit = new CommandeProduit();
            this.commandeProduit.Quantite = 0;
            this.commandeProduit.CommandeId = this.commande.Id;
            this.commandeProduit.ProduitId = this.produit.Id;
        }

        private void DeleteCommandeProduit()
        {
            Manager.Instance.DeleteCommandeProduit(this.commandeProduit);
            Manager.Instance.DeleteProduit(this.produit);
            Manager.Instance.DeleteCategorie(this.categorie);
            Manager.Instance.DeleteCommande(this.commande);
            Manager.Instance.DeleteStatut(this.statut);
            Manager.Instance.DeleteClient(this.client);
        }
    }
}
