using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Commands
{
    public class ClientCommand
    {
        private readonly ContextFluent _contexte;

        public ClientCommand(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public Client Add(Client client)
        {
            _contexte.Clients.Add(client);
            _contexte.SaveChanges();

            return client;
        }

        public Client Update(Client client)
        {
            Client cDB = _contexte.Clients.Where(c => c.Id == client.Id).FirstOrDefault();
            if (cDB != null)
            {
                cDB.Id = client.Id;
                cDB.Actif = client.Actif;
                cDB.Commandes = client.Commandes;
                cDB.Nom = client.Nom;
                cDB.Prenom = client.Prenom;
            }
            _contexte.SaveChanges();

            return cDB;
        }

        public Client Delete(Client client)
        {
            _contexte.Clients.Remove(client);
            _contexte.SaveChanges();

            return client;
        }
    }
}
