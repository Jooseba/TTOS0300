using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfCashMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //fieldies
        float sum = 0;

        public MainWindow()
        {
            InitializeComponent();
            FillItems();
        }
        
        private void FillItems()
        {
            //fill list with product objects
            lstItems.ItemsSource = Products.GetAllProducts();
        }
        //Event handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Add cliced product to list

            //cast object to button type
            Button pressed = (Button)sender;
            lstProducts.Items.Add(pressed.Content);

            //HillBilly style solution
            switch (pressed.Content)
            {
                case "Kahvi 1,50€":
                    sum += 1.5F;
                    break;
                case "Tee 1,10€":
                    sum += 1.1F;
                    break;
                case "Pulla 1,60€":
                    sum += 1.6F;
                    break;
                case "Sämpylä 2,50€":
                    sum += 2.5F;
                    break;
                case "Suklaa 1,30€":
                    sum += 1.3F;
                    break;
                default:
                    break;
            }
            txbTotal.Text = "Yhteensä: " + sum.ToString("C");
        }

        private void BtnPayCash_Click(object sender, RoutedEventArgs e)
        {
            //Open new window
            PayCash payCash = new PayCash();
            payCash.Mount = sum;
            payCash.ShowDialog();

            //clear list
            lstProducts.Items.Clear();
            sum = 0;
            txbTotal.Text = "Yhteensä 0,00 €";
        }

        private void LstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selected = lstItems.SelectedItem;
            //casting
            if (selected is Product)
            {
                Product product = (Product)selected;
                lstProducts.Items.Add(product);
                sum += product.Price;
                txbTotal.Text = "Yhteensä: " + sum.ToString("C");
            }
            lstItems.UnselectAll();
        }
    }
}
