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
        private const string FilePath = "CampaignRepository.txt";
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
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    sw.WriteLine(campaign.MakeTitle());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving campaign to file: {ex.Message}");
            }
        }

        public void LoadCampaignsFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
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
            catch (IOException ex)
            {
                Console.WriteLine($"Error loading campaigns from file: {ex.Message}");
            }
        }

        public Campaign Add(Customer customer, string name, string description, double amount, DateTime dueDate, bool paymentStatus)
        {
            if (customer != null && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                Campaign result = new Campaign(customer, name, description, amount, dueDate, paymentStatus);
                campaigns.Add(result);
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid arguments for creating a campaign");
            }
        }

        public ObservableCollection<Campaign> GetAll()
        {
            return campaigns;
        }
    }
}
