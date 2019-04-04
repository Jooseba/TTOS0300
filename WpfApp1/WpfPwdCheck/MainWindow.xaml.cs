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
            int cntDiffer = 0;

            int cntTotal = psbPassword.Password.Length;

            int cntUpperLetters = psbPassword.Password.Count(char.IsUpper);
            int cntLowerLetters = psbPassword.Password.Count(char.IsLower);
            int cntDigits = psbPassword.Password.Count(char.IsDigit);
            int cntSpecialmarks = psbPassword.Password.Count(x => !Char.IsLetterOrDigit(x));
            if (cntLowerLetters > 0)
            {
                cntDiffer++;
            }
            if (cntUpperLetters > 0)
            {
                cntDiffer++;
            }
            if (cntDigits > 0)
            {
                cntDiffer++;
            }
            if (cntSpecialmarks > 0)
            {
                cntDiffer++;
            }
            txtTotal.Text = "Merkkejä: " + cntTotal;

            txtUpper.Text = $"Isojakirjamia: {cntUpperLetters}";
            txtLower.Text = $"Pieniäkirjaimia: {cntLowerLetters}";
            txtNumber.Text= $"Numeroita: {cntDigits}";
            txtSpecial.Text = $"Erikoismerkkejä: {cntSpecialmarks}";

            //change label color and text
            string msg;
            Color color;
            if (cntTotal > 15 && cntDiffer == 4)
            {
                msg = "Salasana on vahva";
                color = Colors.Green;
            }
            else if (cntTotal < 16 && cntDiffer >= 3)
            {
                msg = "Salasana on ok";
                color = Colors.PowderBlue;
            }
            else if (cntTotal < 12 && cntDiffer >= 2)
            {
                msg = "Salasana on välttävä";
                color = Colors.Yellow;
            }
            else if (cntTotal < 8 && cntDiffer >= 1)
            {
                msg = "Salasana on huono";
                color = Colors.Red;
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
