using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Queries
{
    public class StatutQuery
    {
        private readonly ContextFluent _contexte;

        public StatutQuery(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Statut> GetAll()
        {
            return _contexte.Statuts;
        }
    }
}
