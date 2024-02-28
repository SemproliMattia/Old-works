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
using semproli.mattia._3h.Fantacalcio.Model;

namespace semproli.mattia._3h.Fantacalcio
{
    /// <summary>
    /// Logica di interazione per FinGioc.xaml
    /// </summary>
    public partial class FinGioc : Window
    {
        //VARIABILI
        int win, draw, lose;
        Giocatori[] sq1 = new Giocatori[9];
        Giocatori[] sq2 = new Giocatori[9];

        //RETURN TO HOME
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public FinGioc()
        {
            InitializeComponent();

            //LEGGO I RISULTATI
            StreamReader sr = new StreamReader("ris.txt");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string r = sr.ReadLine();
                string[] dati = r.Split(';');
                win = Convert.ToInt32(dati[0]);
                lose = Convert.ToInt32(dati[1]);
                draw = Convert.ToInt32(dati[2]);
            }
            sr.Close();

            //ISTANZIO GLI ARRAY
            for (int i = 0; i < sq1.Length; i++)
            {
                sq1[i] = new Giocatori();
            }

            for (int j = 0; j < sq2.Length; j++)
            {
                sq2[j] = new Giocatori();
            }
            sq2[0].nome = "Byron";
            sq2[0].cognome = "Love";     

            sq2[1].nome = "Victor";
            sq2[1].cognome = "Blade";

            sq2[2].nome = "Riccardo";
            sq2[2].cognome = "Di Rigo";

            sq2[3].nome = "Jean";
            sq2[3].cognome = "Pierre Lapin";

            sq2[4].nome = "Samguk ";
            sq2[4].cognome = "Han";

            sq2[5].nome = "RISERVE:";
            sq2[5].cognome = "";

            sq2[6].nome = "Lucian";
            sq2[6].cognome = "Dark";

            sq2[7].nome = "Arion";
            sq2[7].cognome = "Sherwind";

            sq2[8].nome = "Gabriel";
            sq2[8].cognome = "Garcia";

            //LEGGE I GIOCATORI DELLA MIA FORMAZIONE E LI SCRIVE NELLA DATAGRID
            StreamReader sr1 = new StreamReader("Formazione.txt");
            for (int i = 0; !sr1.EndOfStream; i++)
            {
                string r = sr1.ReadLine();
                string[] dati = r.Split(';');
                sq1[0].cognome = dati[0];
                sq1[0].nome = dati[1];

                sq1[1].cognome = dati[2];
                sq1[1].nome = dati[3];

                sq1[2].cognome = dati[4];
                sq1[2].nome = dati[5];

                sq1[3].cognome = dati[6];
                sq1[3].nome = dati[7];

                sq1[4].cognome = dati[8];
                sq1[4].nome = dati[9];

                sq1[5].nome = "RISERVE:";
                sq1[5].cognome = "";

                sq1[6].cognome = dati[10];
                sq1[6].nome = dati[11];

                sq1[7].cognome = dati[12];
                sq1[7].nome = dati[13];

                sq1[8].cognome = dati[14];
                sq1[8].nome = dati[15];
            }
            sr1.Close();

            dgS1.ItemsSource = sq1;
            dgS2.ItemsSource = sq2;
        }

        //GENERA DUE NUMERI RANDOM CHE STABILIRANNO IL PUNTEGGIO
        private void Gioca_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int Ris1 = rnd.Next(0, 7);
            int Ris2 = rnd.Next(0, 7);
            lblRis1.Text = $"{Ris1} - {Ris2}";
            if (Ris1 > Ris2)
            {
                win++;
                StreamWriter sw = new StreamWriter("ris.txt");
                sw.WriteLine($"{win};{lose};{draw};");
                sw.Close();

            }
            if (Ris1 < Ris2)
            {
                lose++;
                StreamWriter sw = new StreamWriter("ris.txt");
                sw.WriteLine($"{win};{lose};{draw};");
                sw.Close();
            }
            if (Ris1 == Ris2)
            {
                draw++;
                StreamWriter sw = new StreamWriter("ris.txt");
                sw.WriteLine($"{win};{lose};{draw};");
                sw.Close();
            }
        }
    }
}
