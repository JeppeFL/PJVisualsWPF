using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace PJVisualsWPFTest.Models
{
    public class Kunde
    {
        private static int idCount = 0;

        public int Id { get; }
        public string VirksomhedsNavn { get; set; } = "Intet angivet";
        public string Navn { get; set; } = "Intet angivet";
        public string Email { get; set; } = "Intet angivet";
        public string Telefonnummer { get; set; } = "Intet angivet";


        public Kunde(string virksomhedsNavn, string navn, string email, string telefonNummer)
        {
            this.VirksomhedsNavn = virksomhedsNavn;     
            this.Navn = navn;
            this.Email = email;
            this.Telefonnummer = telefonNummer;

        }                                                                                            

        public string MakeTitle()
        {
            return $"{VirksomhedsNavn},{Navn},{Email},{Telefonnummer}";
        }

        public Kunde() 
        { 
            Id = idCount++;
        }
    }
}
