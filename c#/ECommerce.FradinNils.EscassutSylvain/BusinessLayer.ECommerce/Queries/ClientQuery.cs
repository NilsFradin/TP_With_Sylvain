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

        public Client Add(Client client)
        {
            _contexte.Clients.Add(client);
            return client;
        }

        public Client Delete(Client client)
        {
            _contexte.Clients.Remove(client);
            return client;
        }
    }
}
