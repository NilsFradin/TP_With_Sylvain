using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.ECommerce;
using Service.ECommerce.Model;
using MVC.ECommerce.Models;

namespace MVC.ECommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiceECommerce service = new ServiceECommerce();
            List<Produit> produits = service.GetProduits();
            List<ProduitViewModels> produitsVM = new List<ProduitViewModels>();
            foreach(Produit p in produits)
            {
                produitsVM.Add(new ProduitViewModels(p));
            }

            return View("Index", produitsVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}