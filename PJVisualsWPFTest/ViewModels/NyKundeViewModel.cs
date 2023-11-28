using PJVisualsWPFTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJVisualsWPFTest.ViewModels
{
    public class NyKundeViewModel
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




                



    }
}
