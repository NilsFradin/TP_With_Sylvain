using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Modele.ECommerce.Entites;
using BusinessLayer.ECommerce;
using System.Windows.Input;

namespace ProduitsMVVM.ViewModel
{
    public class ListeProduitsViewModel : BaseViewModel
    {
        private ObservableCollection<DetailProduitViewModel> _produits = null;
        private DetailProduitViewModel _selectedProduit;
        private RelayCommand _actionRechercher;
        private String _recherche;

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

        public ICommand ActionRechercher
        {
            get
            {
                if (_actionRechercher == null)
                    _actionRechercher = new RelayCommand(() => this.RechercherProduits());
                return _actionRechercher;
            }
        }

        private void RechercherProduits()
        {
            List<Produit> produits = Manager.Instance.GetProduitByLibelle(this._recherche);
            _produits.Clear();
            foreach (Produit p in produits)
            {
                _produits.Add(new DetailProduitViewModel(p));
            }
        }

        public String Recherche
        {
            get { return this._recherche; }
            set { this._recherche = value; }
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
