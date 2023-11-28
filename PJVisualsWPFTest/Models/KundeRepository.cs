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
    public class KundeRepository
    {

        private ObservableCollection<Kunde> kundeListe = new ObservableCollection<Kunde>();

        
        public KundeRepository()
        {
            HentKundeFraFil();
        }
        

        //Filstien på min computer
      

        //Gemmer kunden til tekstfil
        public void GemKundeTilFil(Kunde kunde)
        {
            string filSti = "C:\\Users\\lefal\\Desktop\\PJVisualRepository\\KundeRepository.txt";

            using (StreamWriter nyKunde = new StreamWriter(filSti, true))
            {
                nyKunde.WriteLine(kunde.MakeTitle());
            }
        }

        //Henter kunden fra 
        public void HentKundeFraFil()
        {
            string filSti = "C:\\Users\\lefal\\Desktop\\PJVisualRepository\\KundeRepository.txt";

            try
            {
                using (StreamReader hentKunde = new StreamReader(filSti))
                {
                    String line = hentKunde.ReadLine();

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


                        line = hentKunde.ReadLine();

                    }
                }
            }
            catch (IOException)
            {
                throw;

            }
        }
        

        public Kunde Add(string virksomhedsnavn, string navn, string email, string telefonnummer)
        {
            Kunde result = null;

            if (!string.IsNullOrEmpty(virksomhedsnavn) &&
                !string.IsNullOrEmpty(navn) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(telefonnummer))
            {

                result = new Kunde()
                {
                    VirksomhedsNavn = virksomhedsnavn,
                    Navn = navn,
                    Email = email,
                    Telefonnummer = telefonnummer

                };

                kundeListe.Add(result);

            }
            else
                throw (new ArgumentException("!"));
            return result;

        }

        public ObservableCollection<Kunde> GetAll()
        {
            return kundeListe; 
        }

    }
}
