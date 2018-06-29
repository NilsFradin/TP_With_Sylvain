using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.ECommerce;
using Modele.ECommerce.Entites;
using MVC.ECommerce.Models;

namespace MVC.ECommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Produit> produits = Manager.Instance.GetFiveProduit();
            List<ProduitViewModel> produitsVM = new List<ProduitViewModel>();
            foreach (Produit p in produits)
            {
                produitsVM.Add(new ProduitViewModel(p));
            }
            List<Commande> commandes = Manager.Instance.GetFiveCommande();
            List<CommandeViewModel> commandesVM = new List<CommandeViewModel>();
            foreach (Commande c in commandes)
            {
                commandesVM.Add(new CommandeViewModel(c));
            }

            HomeViewModel homeVM = new HomeViewModel(produitsVM, commandesVM);

            return View("Index", homeVM);
        }
    }
}