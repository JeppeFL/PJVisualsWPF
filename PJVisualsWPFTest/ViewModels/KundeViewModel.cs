using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PJVisualsWPFTest.Models;
using PJVisualsWPFTest.Commands;
using System.Threading.Tasks;
using System.Windows.Input;
using PJVisualsWPFTest.Commands;
using System.ComponentModel;

namespace PJVisualsWPFTest.ViewModels
{
    public class KundeViewModel : INotifyPropertyChanged
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

        public KundeViewModel(Kunde kunde)
        {
            VirksomhedsNavn = kunde.VirksomhedsNavn;
            Navn = kunde.Navn;
            Email = kunde.Email;
            Telefonnummer = kunde.Telefonnummer;
            

        }

        public ICommand GemKundeCmd { get; set; } = new GemKundeCommand();

        //SelectedKune
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
