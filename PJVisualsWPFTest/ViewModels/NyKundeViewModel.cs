using PJVisualsWPFTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJVisualsWPFTest.ViewModels
{
    public class NyKundeViewModel : INotifyPropertyChanged
    {

        private KundeRepository kundeRepository = new KundeRepository();
        public ObservableCollection<KundeViewModel> KundeVM { get; set; } = new ObservableCollection<KundeViewModel>();

        public NyKundeViewModel() 
        {
            foreach (Kunde kunde in kundeRepository.GetAll())
            {
                KundeVM.Add(new KundeViewModel(kunde));
            }
        
        }
        //SelectedKunde
        private KundeViewModel selectedKunde;


        //Til lister
        public KundeViewModel SelectedKunde
        {
            get { return selectedKunde; }
            set
            {
                selectedKunde = value;
                OnPropertyChanged("SelectedKunde");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }









    }
}
