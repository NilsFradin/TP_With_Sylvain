using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modele.ECommerce.Entites;
using System.Runtime.Serialization;

namespace Service.ECommerce.Model
{
    [DataContract]
    public class Produit
    {
        public Produit(Modele.ECommerce.Entites.Produit p)
        {
            this.Id = p.Id;
            this.Code = p.Code;
            this.Libelle = p.Libelle;
            this.Prix = p.Prix;
            this.Stock = p.Stock;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Libelle { get; set; }

        [DataMember]
        public float Prix { get; set; }

        [DataMember]
        public int Stock { get; set; }
    }
}