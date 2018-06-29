using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Fluent;
using Modele.ECommerce.Entites;

namespace BusinessLayer.ECommerce.Commands
{
    public class CategorieCommand
    {
        private readonly ContextFluent _contexte;

        public CategorieCommand(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public Categorie Add(Categorie categorie)
        {
            _contexte.Categories.Add(categorie);
            _contexte.SaveChanges();

            return categorie;
        }

        public Categorie Update(Categorie categorie)
        {
            Categorie cDB = _contexte.Categories.Where(c => c.Id == categorie.Id).FirstOrDefault();
            if (cDB != null)
            {
                cDB.Id = categorie.Id;
                cDB.Actif = categorie.Actif;
                cDB.Libelle = categorie.Libelle;
                cDB.Produits = categorie.Produits;
            }
            _contexte.SaveChanges();

            return cDB;
        }

        public Categorie Delete(Categorie categorie)
        {
            _contexte.Categories.Remove(categorie);
            _contexte.SaveChanges();

            return categorie;
        }
    }
}
