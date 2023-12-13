using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace PJVisualsWPFTest.Models 
{
    public class CustomerRepository //Holder på data om oprettede kunder
    {

        //Listen customList opretter en ny ObservableCollection af klassen Customer 
        private ObservableCollection<Customer> customerList = new ObservableCollection<Customer>();

        
        //Opretter en constructor, med en metode i constructorkroppen. 
        public CustomerRepository()
        {
            GetCustomerFromFile();
        }

        
        //Gemmer kunden til tekstfil
        public void SaveCustomerToFile(Customer customer)
        {
            string filePath = "KundeRepository.txt";

            using (StreamWriter newCustomer = new StreamWriter(filePath, true))
            {
                newCustomer.WriteLine(customer.MakeTitle());
            }
        }

        //Henter kunden fra tekstfil
        public void GetCustomerFromFile()
        {
            string filePath = "KundeRepository.txt";

            try
            {
                using (StreamReader getCustomer = new StreamReader(filePath))
                {
                    String line = getCustomer.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length >= 4)
                        {
                            this.Add(parts[0], parts[1], parts[2], parts[3]);
                        }
                        else
                        {
                            // Handle the error or log it
                            Console.WriteLine("Warning: Line does not contain enough data: " + line);
                        }

                        line = getCustomer.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }
        

        public Customer Add(string companyName, string name, string email, string phone)
        {
            Customer result = null;

            if (!string.IsNullOrEmpty(companyName) &&
                !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(phone))
            {

                result = new Customer()
                {
                    CompanyName = companyName,
                    Name = name,
                    Email = email,
                    Phone = phone

                };

                customerList.Add(result);

            }
            else
                throw (new ArgumentException("!"));
            return result;

        }

        public ObservableCollection<Customer> GetAll()
        {
            return customerList; 
        }

        /*Finder kunde baseret ud fra virksomhedsnavn, bliver hentet i CampaignRepo
        public Customer FindCustomerByCompanyName(string companyName)
        {
            return customerList.FirstOrDefault(customer => customer.CompanyName == companyName);
        }
        */
    }
}
