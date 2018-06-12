using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Service.ECommerce.Model;
using Service.ECommerce.Contrat;
using BusinessLayer.ECommerce;


namespace Service.ECommerce
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceECommerce : IServiceECommerce
    {
        public List<Commande> GetCommandes()
        {
            List<Commande> aRetourner = new List<Commande>();
            List<Modele.ECommerce.Entites.Commande> aConvertir = Manager.Instance.GetAllCommandes();

            foreach (Modele.ECommerce.Entites.Commande commande in aConvertir)
            {
                aRetourner.Add(new Commande(commande));
            }

            return aRetourner;
        }

        public List<Produit> GetProduits()
        {
            List<Produit> aRetourner = new List<Produit>();
            List<Modele.ECommerce.Entites.Produit> aConvertir = Manager.Instance.GetAllProduits();

            foreach (Modele.ECommerce.Entites.Produit produit in aConvertir)
            {
                aRetourner.Add(new Produit(produit));
            }

            return aRetourner;
        }

        public int GetStock(int code)
        {
            return Manager.Instance.GetStockByCode(code);
        }

        public Produit GetProduitById(int id)
        {
            Modele.ECommerce.Entites.Produit aConvertir = Manager.Instance.GetProduitById(id);
            Produit p = new Produit(aConvertir);

            return p;
        }
    }
}
