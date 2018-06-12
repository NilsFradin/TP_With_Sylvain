using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Service.ECommerce.Model
{
    [DataContract]
    public class Commande
    {
        public Commande(Modele.ECommerce.Entites.Commande c)
        {
            this.Id = c.Id;
            this.DateCommande = c.DateCommande;
            this.StatutId = c.StatutId;
            this.ClientID = c.ClientID;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DateCommande { get; set; }

        [DataMember]
        public int StatutId { get; set; }

        [DataMember]
        public int ClientID { get; set; }
    }
}