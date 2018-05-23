using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.ECommerce.Entites
{
    public class Produit
    {
        public int Id { get; set; }

        public int Code { get; set; }

        public string Libelle { get; set; }

        public string Description { get; set; }
        
        public bool Actif { get; set; }
       
        public float Prix { get; set; }
        
        public int Stock { get; set; }

        public int CategorieId { get; set; }

        public Categorie Categorie { get; set; }

        public List<LogProduit> LogProduits { get; set; }

        public List<CommandeProduit> CommandesProduits { get; set; }
    }
}
