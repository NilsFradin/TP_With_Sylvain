using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.ECommerce;
using Modele.ECommerce.Entites;

namespace Modele.Test.ECommerce.Test
{
    [TestClass]
    public class ClientTest
    {
        private Client client;

        [TestMethod]
        public void GetAllClientsTest()
        {
            List<Client> clientsOld = Manager.Instance.GetAllClients();
            int oldCount = clientsOld.Count();
            CreateClient();
            Manager.Instance.AddClient(this.client);
            List<Client> clientsNew = Manager.Instance.GetAllClients();
            Assert.AreEqual(oldCount + 1, clientsNew.Count());
            DeleteClient();
        }

        [TestMethod]
        public void AddClientTest()
        {
            CreateClient();
            Manager.Instance.AddClient(this.client);
            List<Client> clients = Manager.Instance.GetAllClients();
            Assert.AreEqual(this.client, clients.Last());

            DeleteClient();
        }

        [TestMethod]
        public void UpdateClientTest()
        {
            CreateClient();
            Manager.Instance.AddClient(this.client);
            this.client.Nom = "TestClientUpdate";
            this.client.Prenom = "TestClientUpdate";
            Client clientUpdated = Manager.Instance.UpdateClient(this.client);
            Assert.AreEqual("TestClientUpdate", clientUpdated.Nom);
            Assert.AreEqual("TestClientUpdate", clientUpdated.Prenom);
            DeleteClient();
        }

        [TestMethod]
        public void DeleteClientTest()
        {
            CreateClient();
            Manager.Instance.AddClient(this.client);
            Client clientTmp = this.client;
            DeleteClient();
            List<Client> clients = Manager.Instance.GetAllClients();
            if (clients.Count() > 0)
            {
                Assert.AreNotEqual(clientTmp, clients.Last());
            }
        }

        private void CreateClient()
        {
            this.client = new Client();
            this.client.Actif = false;
            this.client.Nom = "TestClient";
            this.client.Prenom = "TestClient";
        }

        private void DeleteClient()
        {
            Manager.Instance.DeleteClient(this.client);
        }
    }
}
