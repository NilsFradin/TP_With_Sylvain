using Modele.ECommerce.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitsMVVM.ViewModel
{
    public class DetailProduitViewModel : BaseViewModel
    {
        private int _code;
        private string _libelle;
        private string _description;
        private float _prix;
        private int _stock;
               

        public DetailProduitViewModel(Produit p)
        {
            this._code = p.Code;
            this._libelle = p.Libelle;
            this._description = p.Description;
            this._prix = p.Prix;
            this._stock = p.Stock;
        }

        #region GET SET

        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Libelle
        {
            get { return _libelle; } 
            set { _libelle = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public float Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        public int Stock
        {
            get { return _stock; } 
            set { _stock = value; }
        }

        #endregion
    }
}
