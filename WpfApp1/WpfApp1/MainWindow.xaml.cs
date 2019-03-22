using System;
using Microsoft.Win32;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //fieldies
        private enum MusicState
        {
            Stop,
            Play,
            Pause
        }

        MusicState musicState;

        //Props

        //consts

        
        public MainWindow()
        {
            InitializeComponent();
            musicState = MusicState.Stop; //Playing is stopped when app starts
        }

        //events

        //Meths
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check if file source exists
                if (txtFilename.Text != "")
                {
                    if (System.IO.File.Exists(txtFilename.Text))
                    {
                        //Load file to media element
                        if (musicState == MusicState.Stop)
                        {
                            medElement.Source = new Uri(txtFilename.Text);
                        }
                        medElement.Play(); //Play file 
                        musicState = MusicState.Play;
                        SetButtons();

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Stops media if its playing
                medElement.Stop();
                musicState = MusicState.Stop;
                SetButtons();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                medElement.Pause();
                musicState = MusicState.Pause;
                SetButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetButtons()
        {
            try
            {
                switch (musicState)
                {
                    case MusicState.Stop:
                        btnPlay.IsEnabled = true;
                        btnPause.IsEnabled = false;
                        btnStop.IsEnabled = false;
                        break;
                    case MusicState.Play:
                        btnPlay.IsEnabled = false;
                        btnPause.IsEnabled = true;
                        btnStop.IsEnabled = true;
                        break;
                    case MusicState.Pause:
                        btnPlay.IsEnabled = true;
                        btnPause.IsEnabled = false;
                        btnStop.IsEnabled = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get browsed file name in text box

                //Show windows open-dialog
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    txtFilename.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
