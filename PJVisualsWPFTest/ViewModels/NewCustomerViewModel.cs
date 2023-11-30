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
    public class NewCustomerViewModel : INotifyPropertyChanged
    {

        private Customer customer;

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public NewCustomerViewModel(Customer customer)
        {
            CompanyName = customer.CompanyName;
            Name = customer.Name;
            Email = customer.Email;
            Phone = customer.Phone;


        }

        public ICommand SaveCustomerCmd { get; set; } = new SaveCustomerCommand();

        private CustomerRepository customerRepository = new CustomerRepository();
        public ObservableCollection<NewCustomerViewModel> NewCustomerVM { get; set; } = new ObservableCollection<NewCustomerViewModel>();

        public NewCustomerViewModel() 
        {
            foreach (Customer customer in customerRepository.GetAll())
            {
                NewCustomerVM.Add(new NewCustomerViewModel(customer));
            }
        
        }

        //SelectedKunde
        private NewCustomerViewModel selectedCustomer;


        //Til lister
        public NewCustomerViewModel SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
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
