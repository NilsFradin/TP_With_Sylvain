using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Queries
{
    public class ClientQuery
    {
        private readonly ContextFluent _contexte;

        public ClientQuery(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public IQueryable<Client> GetAll()
        {
            return _contexte.Clients;
        }
    }
}
