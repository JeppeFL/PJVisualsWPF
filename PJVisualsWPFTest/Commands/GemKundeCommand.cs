using PJVisualsWPFTest.Models;
using PJVisualsWPFTest.ViewModels;
using PJVisualsWPFTest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PJVisualsWPFTest.Commands
{
    public class GemKundeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //true eller false
        public bool CanExecute(object? parameter)
        {
            bool result = true;
            if (parameter is KundeViewModel kundeViewModel)
            {
                if (string.IsNullOrEmpty(kundeViewModel.VirksomhedsNavn))
                    result = false;
                if (string.IsNullOrEmpty(kundeViewModel.Navn))
                    result = false;
                if (string.IsNullOrEmpty(kundeViewModel.Email))
                    result = false;
                if (string.IsNullOrEmpty(kundeViewModel.Telefonnummer))
                    result = false;



            }
            //CommandManager.InvalidateRequerySuggested();
            return result; 
        }

        //Hvad skal den gøre
        public void Execute(object? parameter)
        {
         
            if (parameter is KundeViewModel kundeViewModel) 
            {
                //GemKunde
                Kunde nyKunde = new Kunde(kundeViewModel.VirksomhedsNavn, kundeViewModel.Navn, kundeViewModel.Email, kundeViewModel.Telefonnummer);
                KundeRepository repo = new KundeRepository();
                repo.GemKundeTilFil(nyKunde);

                kundeViewModel.VirksomhedsNavn = "";
                kundeViewModel.Navn = "";
                kundeViewModel.Email = "";
                kundeViewModel.Telefonnummer = "";

                //Når gemkunde er klikket så sættes den tilbage til udgangspunktet
              

            }

        }
    }
}
