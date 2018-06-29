using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ECommerce.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(List<ProduitViewModel> produits, List<CommandeViewModel> commandes)
        {
            this.produits = produits;
            this.commandes = commandes;
        }

        public List<ProduitViewModel> produits { get; set; }

        public List<CommandeViewModel> commandes { get; set; }
    }
}