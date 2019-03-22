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

namespace WpfPwdCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PsbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //show count of different kind of marks
            int cntTotal = psbPassword.Password.Length;
            txtTotal.Text = "Merkkejä: " + cntTotal;

            //change label color and text
            string msg;
            Color color;
            if (cntTotal > 15)
            {
                msg = "Salasana on vahva";
                color = Colors.Green;
            }
            else if (cntTotal > 8)
            {
                msg = "Salasana on välttävä";
                color = Colors.Yellow;
            }
            else
            {
                msg = "Salasana on huono";
                color = Colors.Red;
            }

            lblMessage.Content = msg;
            SolidColorBrush brush = new SolidColorBrush(color);
            lblMessage.Background = brush;
        }
    }
}
