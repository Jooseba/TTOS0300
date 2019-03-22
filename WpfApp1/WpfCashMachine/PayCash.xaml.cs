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
using System.Windows.Shapes;

namespace WpfCashMachine
{
    /// <summary>
    /// Interaction logic for PayCash.xaml
    /// </summary>
    public partial class PayCash : Window
    {
        //Props
        public float Mount { get; set; }
        public PayCash()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //Show amount of payment
            txtSum.Text = "Yhteensä: " + Mount.ToString("C");
        }

        private void BtnPaid_Click(object sender, RoutedEventArgs e)
        {
            //save transcription
            this.Close(); //sulkee itsensä
        }

        private void TxtCash_TextChanged(object sender, TextChangedEventArgs e)
        {
            //count change amount
            float money = 0;
            if (float.TryParse(txtSum.Text, out money))
            {
                txtChange.Text = "Takaisin: " + (money - Mount).ToString("C");
            }
        }
    }
}
