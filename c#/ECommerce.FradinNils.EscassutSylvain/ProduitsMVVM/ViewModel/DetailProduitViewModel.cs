using Modele.ECommerce.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusinessLayer.ECommerce;

namespace ProduitsMVVM.ViewModel
{
    public class DetailProduitViewModel : BaseViewModel
    {
        private Produit produit;
        private RelayCommand _actionModifier;
               

        public DetailProduitViewModel(Produit p)
        {
            this.produit = p;
        }

        public ICommand ActionModifier
        {
            get
            {
                if (_actionModifier == null)
                    _actionModifier = new RelayCommand(() => this.ModifierProduit());
                return _actionModifier;
            }
        }

        private void ModifierProduit()
        {
            Manager.Instance.UpdateProduit(this.produit);
        }

        #region GET SET

        public int Code
        {
            get { return this.produit.Code; }
            set { this.produit.Code = value; }
        }

        public string Libelle
        {
            get { return this.produit.Libelle; } 
            set { this.produit.Libelle = value; }
        }

        public string Description
        {
            get { return this.produit.Description; }
            set { this.produit.Description = value; }
        }

        public float Prix
        {
            get { return this.produit.Prix; }
            set { this.produit.Prix = value; }
        }

        public int Stock
        {
            get { return this.produit.Stock; } 
            set { this.produit.Stock = value; }
        }

        #endregion
    }
}
