using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ECommerce.Model;

namespace MVC.ECommerce.Models
{
    public class ProduitViewModels
    {
        public ProduitViewModels(Produit p)
        {
            this.Id = p.Id;
            this.Code = p.Code;
            this.Libelle = p.Libelle;
            this.Prix = p.Prix;
            this.Stock = p.Stock;
        }

        public int Id { get; set; }

        public int Code { get; set; }

        public string Libelle { get; set; }

        public float Prix { get; set; }

        public int Stock { get; set; }
    }
}