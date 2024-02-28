using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.IO;

namespace semproli.mattia._3h.Fantacalcio
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            if(namePlayer.Text != "" && nameTeam.Text != "")
            {
                string nm = namePlayer.Text;
                string tm = nameTeam.Text;

                StreamWriter sw = new StreamWriter("dati.txt");
                sw.WriteLine($"{nm};{tm};");
                sw.Close();

                Home HomeWPF = new Home();
                Close();
                HomeWPF.ShowDialog();
            }
            else
            {
                MessageBox.Show("EH no, mi spiace devi prima inserire nome e nome squadra");
            }
        }

        private void Si_Click(object sender, RoutedEventArgs e)
        {
            if (namePlayer.Text != "" && nameTeam.Text != "")
            {
                string nm = namePlayer.Text;
                string tm = nameTeam.Text;

                StreamWriter sw = new StreamWriter("dati.txt");
                sw.WriteLine($"{nm};{tm};");
                sw.Close();

                FinTut t = new FinTut();
                Close();
                t.ShowDialog();
            }
            else
            {
                MessageBox.Show("EH no, mi spiace devi prima inserire nome e nome squadra");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("ris.txt");
            sw.WriteLine($"0;0;0;");
            sw.Close();

            StreamWriter sw1 = new StreamWriter("LaMiaSquadra.txt");
            sw1.WriteLine($"");
            sw1.Close();

            StreamWriter sw2 = new StreamWriter("GiocatoriRimanenti.txt");
            sw2.WriteLine($"");
            sw2.Close();

            StreamWriter sw3 = new StreamWriter("Formazione.txt");
            sw3.WriteLine($"");
            sw3.Close();

            StreamWriter sw4 = new StreamWriter("championship.txt");
            sw4.WriteLine($"0;0;");
            sw4.Close();

            StreamWriter sw5 = new StreamWriter("partite.txt");
            sw5.WriteLine($"");
            sw5.Close();
        }
    }
}
