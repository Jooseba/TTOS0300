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

namespace WpfAutotalli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Auto> autos = new List<Auto>();
        public MainWindow()
        {
            InitializeComponent();

            ShowPicture("autotalli.png");

            //List<string> brands = new List<string>() { "Audi", "Volvo", "Renault" };
        }

        private void BtnGetAutos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //autos = Garage.GetTestAutos().OrderBy(c => c.Brand).ToList();
                autos = SQL.GetAutosDB();
                dgAutos.ItemsSource = autos;

                var result = autos.Select(b => b.Brand).Distinct().OrderBy(b => b);
                cmbBranches.ItemsSource = result;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ShowPicture(string picturename)
        {
            //näytetään Image-kontrollissa haluttu kuva jos kuvatiedosto löytyy polusta
            string path = @"D:/Herkut/";
            string filename = path + picturename;

            if (System.IO.File.Exists(filename))
            {
                //Kuvan näyttö
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filename);
                bitmap.EndInit();
                imgAuto.Stretch = Stretch.Fill;
                imgAuto.Source = bitmap;
            }
        }

        private void DgAutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //huom olemme itse täyttäneet DaraGridin auto-olioilla
            //joten kukin rivi on siis Auto-olio
            object obj = dgAutos.SelectedItem;

            if (obj != null)
            {
                Auto auto = (Auto)obj;
                ShowPicture(auto.URL);
            }
        }

        private void BtnGetAudis_Click(object sender, RoutedEventArgs e)
        {
            var result = autos.Where(c => c.Brand == "Audi");
            dgAutos.ItemsSource = result;
        }

        private void CmbBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //näytetään vain valitun merkin autot
            string brand = cmbBranches.SelectedValue.ToString();
            var result = autos.Where(b => b.Brand.Contains(brand));
            dgAutos.ItemsSource = result;
            ShowPicture("autotalli.png");
        }
    }
}
