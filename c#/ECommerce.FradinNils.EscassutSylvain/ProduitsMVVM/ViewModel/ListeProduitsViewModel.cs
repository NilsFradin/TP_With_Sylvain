using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Modele.ECommerce.Entites;
using BusinessLayer.ECommerce;

namespace ProduitsMVVM.ViewModel
{
    public class ListeProduitsViewModel : BaseViewModel
    {
        private ObservableCollection<DetailProduitViewModel> _produits = null;
        private DetailProduitViewModel _selectedProduit;

        public ListeProduitsViewModel()
        {
            _produits = new ObservableCollection<DetailProduitViewModel>();
            foreach(Produit p in Manager.Instance.GetAllProduits())
            {
                _produits.Add(new DetailProduitViewModel(p));
            }

            if (_produits != null && _produits.Count > 0)
                _selectedProduit = _produits.ElementAt(0);
        }

        public ObservableCollection<DetailProduitViewModel> Produits
        {
            get { return _produits; }
            set
            {
                _produits = value;
                OnPropertyChanged("Produits");
            }
        }

        public  DetailProduitViewModel SelectedProduit
        {
            get { return _selectedProduit; }
            set
            {
                _selectedProduit = value;
                OnPropertyChanged("SelectedProduit");
            }
        }

    }
}
