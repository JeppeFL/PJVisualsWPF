using PJVisualsWPFTest.Commands;
using PJVisualsWPFTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PJVisualsWPFTest.ViewModels
{
    public class NyKundeViewModel : INotifyPropertyChanged
    {

        private Kunde kunde;

        private string virksomhedsNavn;
        public string VirksomhedsNavn
        {
            get { return virksomhedsNavn; }
            set
            {
                virksomhedsNavn = value;
                OnPropertyChanged("VirksomhedsNavn");
            }
        }

        private string navn;
        public string Navn
        {
            get { return navn; }
            set
            {
                navn = value;
                OnPropertyChanged("Navn");
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        private string telefonnummer;
        public string Telefonnummer
        {
            get { return telefonnummer; }
            set
            {
                telefonnummer = value;
                OnPropertyChanged("Telefonnummer");
            }
        }

        public NyKundeViewModel(Kunde kunde)
        {
            VirksomhedsNavn = kunde.VirksomhedsNavn;
            Navn = kunde.Navn;
            Email = kunde.Email;
            Telefonnummer = kunde.Telefonnummer;


        }

        public ICommand GemKundeCmd { get; set; } = new GemKundeCommand();

        private KundeRepository kundeRepository = new KundeRepository();
        public ObservableCollection<NyKundeViewModel> NyKundeVM { get; set; } = new ObservableCollection<NyKundeViewModel>();

        public NyKundeViewModel() 
        {
            foreach (Kunde kunde in kundeRepository.GetAll())
            {
                NyKundeVM.Add(new NyKundeViewModel(kunde));
            }
        
        }

        //SelectedKunde
        private NyKundeViewModel selectedKunde;


        //Til lister
        public NyKundeViewModel SelectedKunde
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
