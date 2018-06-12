using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ServiceModel;
using Service.ECommerce.Model;

namespace Service.ECommerce.Contrat
{
    [ServiceContract]
    public interface IServiceECommerce
    {
        [OperationContract]
        List<Produit> GetProduits();
        [OperationContract]
        List<Commande> GetCommandes();
        [OperationContract]
        int GetStock(int code);


    }
}
