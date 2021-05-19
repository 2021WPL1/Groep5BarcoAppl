using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BarcoApplicatie
{
    public partial class Login : Window
    {

        private void btnSendJob_Click()
        {
            string Name = txtNaam.Text;
            string Division = txtDivisie.Text;
            string Functie = txtFunctie.Text;

            RegistryKey request = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\BarRequest");


            if (request != null)
            {
                request.SetValue("Name", Name);
                request.SetValue("Division", Division);
                request.SetValue("Functie", Functie);
                request.Close();
            }

            RegistryKey control = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\BarControl");
            if (control != null)
            {
                control.SetValue("Name", Name);
                control.SetValue("Functie", Functie);
                control.Close();
            }

            RegistryKey test = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\BarTest");
            if (test != null)
            {
                test.SetValue("Name", Name);
                test.SetValue("Division", Division);
                test.Close();
            }
        }
    }

}