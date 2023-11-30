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

        private Kunde kunde;
        private ObservableCollection<Campaign> campaigns = new ObservableCollection<Campaign>();

        public CampaignRepository() 
        {

            GetCustomerFromFile();
        
        }

        public void SaveCampaignToFile(Campaign campaign)
        {
            string filePath = "CampaignRepository.txt";
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(campaign.MakeTitle());
            }
        }

        public void GetCustomerFromFile()
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
                        if (parts.Length >= 6)
                        {
                            this.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
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

        public Campaign Add((Kunde kunde, string name, string description, double amount, DateTime DueDate, bool PaymentStatus)
            {
            Campaign result = null;

            if (!string.IsNullOrEmpty(kunde) &&
                !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(description) &&
                !string.IsNullOrEmpty(amount) &&
                !string.IsNullOrEmpty(dueDate) &&
                !string.IsNullOrEmpty(paymentStatus))
            {
                result = new Campaign();
                {
                    Kunde = kunde,
                    Name = name, 
                    Description = description,
                    Amount = amount,
                    DueDate = dueDate,
                    PaymentStatus = paymentStatus

                };
                campaigns.Add(result);
            }
            else
                throw (new ArgumentException("!"));
            return result;
        }



                
                
                
                
                
                
                





    }
}
