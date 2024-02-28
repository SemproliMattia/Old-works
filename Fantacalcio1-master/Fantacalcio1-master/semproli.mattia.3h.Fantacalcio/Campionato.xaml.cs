using System;
using System.Collections.Generic;
using System.IO;
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

namespace semproli.mattia._3h.Fantacalcio
{
    /// <summary>
    /// Logica di interazione per Campionato.xaml
    /// </summary>
    public partial class Campionato : Window
    {
        int pt1, pt2;
        string nTeamU;

        public Campionato()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("championship.txt");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string r = sr.ReadLine();
                string[] dati = r.Split(';');
                pt1 = Convert.ToInt32(dati[0]);
                pt2 = Convert.ToInt32(dati[1]);

            }
            sr.Close();

            StreamReader sr1 = new StreamReader("dati.txt");
            for (int i = 0; !sr1.EndOfStream; i++)
            {
                string r = sr1.ReadLine();
                string[] dati = r.Split(';');
                nTeamU = dati[1];

            }
            sr1.Close();

            if (pt1 > pt2)
            {
                punti1.Content = $"1# {nTeamU} con {pt1} pt.";
                punti2.Content = $"2# TEAM BOT con {pt2} pt.";
            }
            else if (pt2 > pt1)
            {
                punti1.Content = $"1# TEAM BOT con {pt2} pt.";
                punti2.Content = $"2# {nTeamU} con {pt1} pt.";
            }            
            else
            {
                punti1.Content = $"1# {nTeamU} con {pt1} pt.";
                punti2.Content = $"1# TEAM BOT con {pt2} pt.";
            }
        }

        //RETURN TO HOME
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }        
    }
}
