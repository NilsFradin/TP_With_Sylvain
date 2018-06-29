using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modele.ECommerce;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;
using BusinessLayer.ECommerce.Queries;
using BusinessLayer.ECommerce.Commands;

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

        #region Produit

        public List<Produit> GetAllProduits()
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetAll().ToList();
        }

        public Produit GetProduitById(int id)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetByID(id).ToList().FirstOrDefault();
        }

        public List<Produit> GetProduitByLibelle(string libelle)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetByLibelle(libelle).ToList();
        }

        public List<Produit> GetFiveProduit()
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetFiveProduit().ToList();
        }

        public void AddProduit(Produit p)
        {
            ProduitCommand pc = new ProduitCommand(contexte);
            pc.Add(p);
        }

        public Produit UpdateProduit(Produit p)
        {
            ProduitCommand pc = new ProduitCommand(contexte);
            return pc.Update(p);
        }

        public void DeleteProduit(Produit p)
        {
            ProduitCommand pc = new ProduitCommand(contexte);
            pc.Delete(p);
        }

        public int GetStockByCode(int code)
        {
            ProduitQuery pq = new ProduitQuery(contexte);
            return pq.GetStockByCode(code).ToList().First();
        }

        #endregion

        #region Commande

        public List<Commande> GetAllCommandes()
        {
            CommandeQuery cq = new CommandeQuery(contexte);
            return cq.GetAll().ToList();
        }

        public List<Commande> GetFiveCommande()
        {
            CommandeQuery cq = new CommandeQuery(contexte);
            return cq.GetFiveCommande().ToList();
        }

        public void AddCommande(Commande c)
        {
            CommandeCommand cc = new CommandeCommand(contexte);
            cc.Add(c);
        }

        public Commande UpdateCommande(Commande c)
        {
            CommandeCommand cc = new CommandeCommand(contexte);
            return cc.Update(c);
        }

        public void DeleteCommande(Commande c)
        {
            CommandeCommand cc = new CommandeCommand(contexte);
            cc.Delete(c);
        }

        #endregion

        #region Client

        public List<Client> GetAllClients()
        {
            ClientQuery cq = new ClientQuery(contexte);
            return cq.GetAll().ToList();
        }

        public void AddClient(Client c)
        {
            ClientCommand cc = new ClientCommand(contexte);
            cc.Add(c);
        }

        public Client UpdateClient(Client c)
        {
            ClientCommand cc = new ClientCommand(contexte);
            return cc.Update(c);
        }

        public void DeleteClient(Client c)
        {
            ClientCommand cc = new ClientCommand(contexte);
            cc.Delete(c);
        }

        #endregion

        #region CommandeProduit

        public List<CommandeProduit> GetAllCommandesProduits()
        {
            CommandeProduitQuery cq = new CommandeProduitQuery(contexte);
            return cq.GetAll().ToList();
        }

        public void AddCommandeProduit(CommandeProduit cp)
        {
            CommandeProduitCommand cpc = new CommandeProduitCommand(contexte);
            cpc.Add(cp);
        }

        public CommandeProduit UpdateCommandeProduit(CommandeProduit cp)
        {
            CommandeProduitCommand cpc = new CommandeProduitCommand(contexte);
            return cpc.Update(cp);
        }

        public void DeleteCommandeProduit(CommandeProduit cp)
        {
            CommandeProduitCommand cpc = new CommandeProduitCommand(contexte);
            cpc.Delete(cp);
        }

        #endregion

        #region LogProduit

        public List<LogProduit> GetAllLogsProduits()
        {
            LogProduitQuery lpq = new LogProduitQuery(contexte);
            return lpq.GetAll().ToList();
        }

        public void AddLogProduit(LogProduit lp)
        {
            LogProduitCommand lpc = new LogProduitCommand(contexte);
            lpc.Add(lp);
        }

        public LogProduit UpdateLogProduit(LogProduit lp)
        {
            LogProduitCommand lpc = new LogProduitCommand(contexte);
            return lpc.Update(lp);
        }

        public void DeleteLogProduit(LogProduit lp)
        {
            LogProduitCommand lpc = new LogProduitCommand(contexte);
            lpc.Delete(lp);
        }

        #endregion

        #region Categorie

        public List<Categorie> GetAllCategories()
        {
            CategorieQuery cq = new CategorieQuery(contexte);
            return cq.GetAll().ToList();
        }

        public void AddCategorie(Categorie c)
        {
            CategorieCommand cc = new CategorieCommand(contexte);
            cc.Add(c);
        }

        public Categorie UpdateCategorie(Categorie c)
        {
            CategorieCommand cc = new CategorieCommand(contexte);
            return cc.Update(c);
        }

        public void DeleteCategorie(Categorie c)
        {
            CategorieCommand cc = new CategorieCommand(contexte);
            cc.Delete(c);
        }

        #endregion

        #region Statut

        public List<Statut> GetAllStatuts()
        {
            StatutQuery sq = new StatutQuery(contexte);
            return sq.GetAll().ToList();
        }

        public void AddStatut(Statut s)
        {
            StatutCommand sc = new StatutCommand(contexte);
            sc.Add(s);
        }

        public Statut UpdateStatut(Statut s)
        {
            StatutCommand sc = new StatutCommand(contexte);
            return sc.Update(s);
        }

        public void DeleteStatut(Statut s)
        {
            StatutCommand sc = new StatutCommand(contexte);
            sc.Delete(s);
        }

        #endregion
    }
}
