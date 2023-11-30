using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJVisualsWPFTest.Models
{
    class CampaignRepository
    {
        private ObservableCollection<Campaign> campaigns = new ObservableCollection<Campaign>();
        private CustomerRepository customerRepository;

        public CampaignRepository()
        {
            LoadCampaignsFromFile();
        }
        public CampaignRepository(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
            LoadCampaignsFromFile();
        }

       
        public void SaveCampaignToFile(Campaign campaign)
        {
            string filePath = "CampaignRepository.txt";
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(campaign.MakeTitle());
            }
        }

        public void LoadCampaignsFromFile()
        {
            string filePath = "CampaignRepository.txt";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 6)
                        {

                            Customer customer = customerRepository.FindCustomerByCompanyName(parts[0]);

                            double amount = double.Parse(parts[3]);
                            DateTime dueDate = DateTime.Parse(parts[4]);
                            bool paymentStatus = bool.Parse(parts[5]);

                            this.Add(customer, parts[1], parts[2], amount, dueDate, paymentStatus);
                        }
                        else
                        {
                            Console.WriteLine("Warning: Line does not contain enough data" + line);
                        }

                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Campaign Add(Customer kunde, string name, string description, double amount, DateTime dueDate, bool paymentStatus)
        {
            if (kunde != null && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                Campaign result = new Campaign(kunde, name, description, amount, dueDate, paymentStatus);
                campaigns.Add(result);
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid arguments for creating a campaign");
            }
        }

        // Eventuelt tilføje en GetAll metode, hvis nødvendigt
        public ObservableCollection<Campaign> GetAll()
        {
            return campaigns;
        }
    }
}
