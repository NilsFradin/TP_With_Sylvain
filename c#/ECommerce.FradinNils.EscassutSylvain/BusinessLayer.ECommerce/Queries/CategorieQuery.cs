using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Queries
{
    public class CategorieQuery
    {
        private readonly ContextFluent _contexte;

        public CategorieQuery(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Categorie> GetAll()
        {
            return _contexte.Categories;
        }

        public Categorie Add(Categorie categorie)
        {
            _contexte.Categories.Add(categorie);
            return categorie;
        }

        public Categorie Delete(Categorie categorie)
        {
            _contexte.Categories.Remove(categorie);
            return categorie;
        }
    }
}
