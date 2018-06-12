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
    public class ProduitController : Controller
    {
        public ActionResult GetProduit(int id)
        {
            ServiceECommerce service = new ServiceECommerce();
            Produit produit = service.GetProduitById(id);
            ProduitViewModels produitVM = new ProduitViewModels(produit);

            return View("GetProduit", produitVM);
        }

        public ActionResult AddProduit()
        {

            return View("AddProduit");
        }

        public ActionResult UpdateProduit(int id)
        {
            ServiceECommerce service = new ServiceECommerce();
            Produit produit = service.GetProduitById(id);
            ProduitViewModels produitVM = new ProduitViewModels(produit);

            return View("UpdateProduit", produitVM);
        }
    }
}