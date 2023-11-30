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
    public class SaveCustomerCommand : ICommand
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
            if (parameter is NewCustomerViewModel customerViewModel)
            {
                if (string.IsNullOrEmpty(customerViewModel.CompanyName))
                    result = false;
                if (string.IsNullOrEmpty(customerViewModel.Name))
                    result = false;
                if (string.IsNullOrEmpty(customerViewModel.Email))
                    result = false;
                if (string.IsNullOrEmpty(customerViewModel.Phone))
                    result = false;



            }
            //CommandManager.InvalidateRequerySuggested();
            return result; 
        }

        //Hvad skal den gøre
        public void Execute(object? parameter)
        {
         
            if (parameter is NewCustomerViewModel customerViewModel) 
            {
                //GemKunde
                Customer newCustomer = new Customer(customerViewModel.CompanyName, customerViewModel.Name, customerViewModel.Email, customerViewModel.Phone);
                CustomerRepository repo = new CustomerRepository();
                repo.SaveCustomerToFile(newCustomer);

                customerViewModel.CompanyName = "";
                customerViewModel.Name = "";
                customerViewModel.Email = "";
                customerViewModel.Phone = "";

                //Når gemkunde er klikket så sættes den tilbage til udgangspunktet
              

            }

        }
    }
}
