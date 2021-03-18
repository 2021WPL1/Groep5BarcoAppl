using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BarcoApplicatie
{
    class ErrorHandling
    {
        public void ControlInput(string canBe, TextBox box)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(box.Text, canBe))
            {
                box.Text = box.Text.Remove(box.Text.Length - 1);
            
            }
        }

        //Check if checkbox is empty for datePicker
        public void dateEmpty(DatePicker DateEut, CheckBox cbEmcEut, CheckBox cbEnviromental, CheckBox cbReliability, CheckBox cbProductSafety, CheckBox cbPackaging, CheckBox cbGreenCompilance)
        {
            if (cbEmcEut.IsChecked == false && cbEnviromental.IsChecked == false && cbReliability.IsChecked == false && cbProductSafety.IsChecked == false && cbPackaging.IsChecked == false && cbGreenCompilance.IsChecked == false)
            {
                DateEut.IsEnabled = false;
            }
            else
            {
                DateEut.IsEnabled = true;
            }
        }

        //Check if text is empty
        public void EmptyTextBox(TextBox txtname, string text, Label label)
        {
            if (txtname.Text.Length == 0)
            {
                label.Content = "Please fill in " + text;
            }
            else
            {
                label.Content = "";
            }
            
        }
        public void EmptyComboBox(ComboBox cmbname, string text, Label label)
        {
            if (cmbname.SelectedIndex == -1)
            {
                label.Content = "Please fill in " + text;
            }
            else
            {
                label.Content = "";
            }
        }

    }
}