using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ECommerce.Entites
{
    public class LogProduit
    {
        public LogProduit()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        public int ProduitId { get; set; }

        public Produit Produit { get; set; }
    }
}
