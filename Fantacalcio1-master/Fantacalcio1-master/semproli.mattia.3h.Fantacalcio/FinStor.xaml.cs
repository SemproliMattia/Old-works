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
    /// Logica di interazione per FinStor.xaml
    /// </summary>
    public partial class FinStor : Window
    {
        public string nWin, nDraw, nLost;

        //RETURN TO HOME
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public FinStor()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("ris.txt");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string r = sr.ReadLine();
                string[] dati = r.Split(';');
                nWin = dati[0];
                nLost = dati[1];
                nDraw = dati[2];
            }
            sr.Close();

            Win.Text = "Hai vinto: " + nWin + " volte";
            Draw.Text = "Hai pareggiato: " + nDraw + " volte";
            Lost.Text = "Hai perso: " + nLost + " volte";
        }
    }
}
