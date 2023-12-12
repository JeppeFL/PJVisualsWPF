using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJVisualsWPFTest.Models
{
    public class Campaign
    {
        public string CustomerCampaign { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool PaymentStatus { get; set; }

        public Campaign(string customerCampaign, string name, string description, double amount, DateTime dueDate, bool paymentStatus)
        {
           
            this.CustomerCampaign = customerCampaign;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.DueDate = dueDate;
            this.PaymentStatus = paymentStatus;
        }

        public string MakeTitle()
        {
            return $"{CustomerCampaign},{Name},{Description},{Amount},{DueDate},{PaymentStatus}";
        }
    }
}
