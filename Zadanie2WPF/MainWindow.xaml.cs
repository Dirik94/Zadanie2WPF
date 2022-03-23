using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Order order;

        public MainWindow()
        {
            InitializeComponent();
            order = new Order();
        }

        private void DisplaySummary()
        {
            TextBox_Summary.Text = order.ToString();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Dziękujemy za złożenie zamówienia", "Zamówienie Przyjęto", MessageBoxButton.OK);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ColorPaper_Check(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((CheckBox)sender).IsChecked ?? false;
            if (isChecked)
            {
                ComboBox_Colors.IsEnabled = isChecked;
                order.Bonus += 0.5;
            }
            DisplaySummary();
        }

        private void ColorPaper_Uncheck(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((CheckBox)sender).IsChecked ?? false;
            if (isChecked == false)
            {
                ComboBox_Colors.IsEnabled = isChecked;
                order.Bonus -= 0.5;
            }
            DisplaySummary();
        }

        private void BonusCheck(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.IsChecked == true)
            {
                order.Bonus += double.Parse(cb.Tag.ToString());
            }
            else
            {
                order.Bonus -= double.Parse(cb.Tag.ToString());
            }
            DisplaySummary();
        }
        private void ZmianaGramatury(object sender, RoutedEventArgs e)
        {

            if (((RadioButton)sender).Tag == "80")
            {
                order.NumerGramatury = 1;
            }
            else if (((RadioButton)sender).Tag == "120")
            {
                order.NumerGramatury = 2;
            }
            else if (((RadioButton)sender).Tag == "200")
            {
                order.NumerGramatury = 2.5;
            }
            else
            {
                order.NumerGramatury = 3;
            }
                order.Gramatura = ((RadioButton)sender).Tag + " g/m²";
            DisplaySummary();
        }

        private void ZmianaCzasWykonania(object sender, RoutedEventArgs e)
        {
            if(((RadioButton)sender).Tag.ToString() == "true"){
                order.CzasWykonaniaAddedCost = 15;
                order.CzasWykonania = "Ekspresowy";
            }
            else
            {
                order.CzasWykonaniaAddedCost = 0;
                order.CzasWykonania = "Standardowy";
            }
            DisplaySummary();
        }

        private void ZmianaKoloruDruku(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.IsEnabled == false && order.Color != "Biały")
            {
                order.Color = "Biały";
            }
            else
            {
                cb.IsEnabled = true;
                order.Color = cb.SelectedItem.ToString();
            }
            DisplaySummary();
        }

        private void ZmianaNaSlider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            order.BasePrice = 0.2;

            if (Math.Round(((Slider)sender).Value) == 0)
            {
                Label_Format.Content = "A" + "0" + " - cena " + order.BasePrice * 100 + "gr/szt.";
            }
            else if (Math.Round(((Slider)sender).Value) == 1)
            {
                order.BasePrice *= 2.5;
                Label_Format.Content = "A" + "1" + " - cena " + order.BasePrice * 100 + "gr/szt.";
            }
            else if(Math.Round(((Slider)sender).Value) == 2)
            {
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                Label_Format.Content = "A" + "2" + " - cena " + order.BasePrice + "zł/szt.";
            }
            else if (Math.Round(((Slider)sender).Value) == 3)
            {
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                Label_Format.Content = "A" + "3" + " - cena " + Math.Round(order.BasePrice,2) + "zł/szt.";
            }
            else if (Math.Round(((Slider)sender).Value) == 4)
            {
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                Label_Format.Content = "A" + "4" + " - cena " + Math.Round(order.BasePrice,2) + "zł/szt.";
            }
            else if (Math.Round(((Slider)sender).Value) == 5)
            {
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                order.BasePrice *= 2.5;
                Label_Format.Content = "A" + "5" + " - cena " + Math.Round(order.BasePrice,2) + "zł/szt.";
            }
            DisplaySummary();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                TextBox_Summary.Text = "";
            }
            else
            {
                order.Count = int.Parse(textBox.Text);
                DisplaySummary();
            }
        }

        private void ValidateText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
