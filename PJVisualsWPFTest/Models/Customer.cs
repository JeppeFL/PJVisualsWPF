using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace PJVisualsWPFTest.Models
{
    public class Customer
    {
        public string CompanyName { get; set; } = "Intet angivet";
        public string Name { get; set; } = "Intet angivet";
        public string Email { get; set; } = "Intet angivet";
        public string Phone { get; set; } = "Intet angivet";


        public Customer(string companyName, string name, string email, string phone)
        {
            this.CompanyName = companyName;     
            this.Name = name;
            this.Email = email;
            this.Phone = phone;

        }

        public Customer()
        {
        }

        public string MakeTitle()
        {
            return $"{CompanyName},{Name},{Email},{Phone}";
        }

    }
}
