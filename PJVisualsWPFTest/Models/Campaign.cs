using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJVisualsWPFTest.Models
{
    public class Campaign
    {
        private static int idCount = 0;

        public int Id { get; }
        public Customer Customer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool PaymentStatus { get; set; }

        public Campaign(Customer customer, string name, string description, double amount, DateTime dueDate, bool paymentStatus)
        {
            this.Id = idCount++;
            this.Customer = customer;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.DueDate = dueDate;
            this.PaymentStatus = paymentStatus;
        }

        public string MakeTitle()
        {
            return $"{Customer.CompanyName},{Name},{Description},{Amount},{DueDate},{PaymentStatus}";
        }
    }
}
