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
        public Kunde kunde {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool PaymentStatus { get; set; }

        public Campaign (Kunde kunde, string name, string description, double amount, DateTime DueDate, bool PaymentStatus)
        {
            this.kunde = kunde;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.DueDate = DueDate;
            this.PaymentStatus = PaymentStatus;

        }

        public string MakeTitle()
        {
            return $"{kunde.VirksomhedsNavn},{Name},{Description},{Amount},{DueDate},{PaymentStatus}";
        }

        public Campaign()
        {
            idCount++;
        }



    }
}
