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
    public class ProduitController : Controller
    {
        public ActionResult ListeProduit()
        {
            List<Produit> produits = Manager.Instance.GetAllProduits();
            List<ProduitViewModel> produitsVM = new List<ProduitViewModel>();
            foreach (Produit p in produits)
            {
                produitsVM.Add(new ProduitViewModel(p));
            }

            return View("ListeProduit", produitsVM);
        }

        public ActionResult GetProduit(int id)
        {
            Produit produit = Manager.Instance.GetProduitById(id);
            if (produit == null)
            {
                return RedirectToAction("ListeProduit", "Produit");
            }
            ProduitViewModel produitVM = new ProduitViewModel(produit);

            return View("GetProduit", produitVM);
        }

        public ActionResult AddProduit()
        {
            return View("AddProduit");
        }

        [HttpPost]
        public ActionResult AddProduit(ProduitViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                pVM.CategorieId = 1;
                pVM.Actif = true;
                Manager.Instance.AddProduit(pVM.Converte());
            }

            return RedirectToAction("ListeProduit", "Produit");
        }

        public ActionResult UpdateProduit(int id)
        {
            Produit produit = Manager.Instance.GetProduitById(id);
            if(produit == null)
            {
                return RedirectToAction("ListeProduit", "Produit");
            }
            ProduitViewModel produitVM = new ProduitViewModel(produit);

            return View("UpdateProduit", produitVM);
        }

        [HttpPost]
        public ActionResult UpdateProduit(ProduitViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                pVM.CategorieId = 1;
                Manager.Instance.UpdateProduit(pVM.Converte());
            }

            return RedirectToAction("GetProduit", "Produit", new { id = pVM.Id });
        }

        public ActionResult DeleteProduit(int id)
        {
            Produit produit = Manager.Instance.GetProduitById(id);
            if (produit == null)
            {
                return RedirectToAction("ListeProduit", "Produit");
            }
            Manager.Instance.DeleteProduit(produit);

            return RedirectToAction("ListeProduit", "Produit");
        }

        [HttpPost]
        public ActionResult RechercherProduit(string libelle)
        {
            List<Produit> produits = Manager.Instance.GetProduitByLibelle(libelle);
            List<ProduitViewModel> produitsVM = new List<ProduitViewModel>();
            foreach (Produit p in produits)
            {
                produitsVM.Add(new ProduitViewModel(p));
            }

            return View("ListeProduit", produitsVM);
        }
    }
}