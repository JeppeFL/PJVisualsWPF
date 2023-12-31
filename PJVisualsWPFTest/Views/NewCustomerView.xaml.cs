﻿using PJVisualsWPFTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PJVisualsWPFTest.ViewModels;

namespace PJVisualsWPFTest.Views
{
    /// <summary>
    /// Interaction logic for NyKampagneView.xaml
    /// </summary>
    public partial class NewCustomerView : Window
    {

        NewCustomerViewModel nkvm = new NewCustomerViewModel();

        public NewCustomerView()
        {
            InitializeComponent();
            DataContext = nkvm;
        }

       
        private void tbNyKundeVirksomhedsnavn_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Indtast virksomhedsnavn
            nkvm.CompanyName = tbNyKundeVirksomhedsnavn.Text;

        }

        private void tbNyKundeNavn_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Indtast navn
            nkvm.Name = tbNyKundeNavn.Text;
        }

        private void tbNyKundeEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Indtast email
            nkvm.Email = tbNyKundeEmail.Text;
        }

        private void tbNyKundeTelefonnummer_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Indtast telefonnummer
            nkvm.Phone = tbNyKundeTelefonnummer.Text;

        }

        private void btnNyKundeTilbage_Click(object sender, RoutedEventArgs e)
        {
            //Annuller - Gå tilbage til forrige skærm/Luk nuværende skærm'
            this.Close();
        }

      
    }
}
