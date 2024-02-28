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
    /// Logica di interazione per FinMerc.xaml
    /// </summary>
    public partial class FinMerc : Window
    {
        //VARIABILI
        Giocatori[] MiaSquadra = new Giocatori[10];
        Giocatori[] Mercato = new Giocatori[5];
        int idx = 0, rim = 0;
        string nome, cognome;

        public FinMerc()
        {
            InitializeComponent();

            //ISTANZO L'ARRAY
            for (int i = 0; i < Mercato.Length; i++)
            {
                Mercato[i] = new Giocatori();
            }

            //LEGGO I GIOCATORI NON SCELTI NELLA MIA SQUADRA E LI METTO NELLA DATAGRID DEI GIOCATORI DA ACQUISTARE
            StreamReader sr = new StreamReader("GiocatoriRimanenti.txt");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string r = sr.ReadLine();
                string[] dati = r.Split(';');
                Mercato[0].nome = dati[0];
                Mercato[0].cognome = dati[1];

                Mercato[1].nome = dati[2];
                Mercato[1].cognome = dati[3];

                Mercato[2].nome = dati[4];
                Mercato[2].cognome = dati[5];

                Mercato[3].nome = dati[6];
                Mercato[3].cognome = dati[7];

                Mercato[4].nome = dati[8];
                Mercato[4].cognome = dati[9];
            }
            sr.Close();
            dgMercato.ItemsSource = Mercato;

            //ISTANZO L'ARRAY
            for (int i = 0; i < MiaSquadra.Length; i++)
            {
                MiaSquadra[i] = new Giocatori();
            }

            //LEGGO I GIOCATORI SCELTI NELLA MIA SQUADRA E LI METTO NELLA DATAGRID DEI MIEI GIOCATORI
            StreamReader sr1 = new StreamReader("LaMiaSquadra.txt");
            for (int i = 0; !sr1.EndOfStream; i++)
            {
                string r = sr1.ReadLine();
                string[] dati = r.Split(';');
                MiaSquadra[0].nome = dati[0];
                MiaSquadra[0].cognome = dati[1];

                MiaSquadra[1].nome = dati[2];
                MiaSquadra[1].cognome = dati[3];

                MiaSquadra[2].nome = dati[4];
                MiaSquadra[2].cognome = dati[5];

                MiaSquadra[3].nome = dati[6];
                MiaSquadra[3].cognome = dati[7];

                MiaSquadra[4].nome = dati[8];
                MiaSquadra[4].cognome = dati[9];

                MiaSquadra[5].nome = dati[10];
                MiaSquadra[5].cognome = dati[11];

                MiaSquadra[6].nome = dati[12];
                MiaSquadra[6].cognome = dati[13];

                MiaSquadra[7].nome = dati[14];
                MiaSquadra[7].cognome = dati[15];

                MiaSquadra[8].nome = dati[16];
                MiaSquadra[8].cognome = dati[17];

                MiaSquadra[9].nome = dati[18];
                MiaSquadra[9].cognome = dati[19];

                idx = 10;
            }
            sr1.Close();
            dgSquadraMia.ItemsSource = MiaSquadra;
        }

        //PULSANTE RIMUOVI, NON TE NE FA RIMUOVERE PIU DI 5
        private void RIM_Click(object sender, RoutedEventArgs e)
        {
            if (rim < 5)
            {
                int ind = dgSquadraMia.SelectedIndex;

                if (ind == -1)
                {

                }
                else
                {
                    MiaSquadra[ind] = new Giocatori();

                    for (int i = ind; i < MiaSquadra.Length - 1; i++)
                    {
                        MiaSquadra[i] = MiaSquadra[i + 1];
                    }

                    MiaSquadra[MiaSquadra.Length - 1] = new Giocatori();
                    idx--;
                    rim++;

                    dgSquadraMia.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show($"Se rimuovi un altro giocatore, ti ritroverai con un buco vuoto siccome hai già inserito tutti i giocatori disponibili");
            }
        }

        //GIOCATORE SELEZIONATO
        private void DgMercato_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Giocatori g = dgMercato.SelectedItem as Giocatori;

            if (g != null)
            {
                nome = g.nome;
                cognome = g.cognome;
            }
        }

        //RETURN TO HOME
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //BOTTONE AGGIUNGI
        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (idx < MiaSquadra.Length)
            {
                Giocatori gi = new Giocatori();
                gi.nome = nome;
                gi.cognome = cognome;

                if (gi.nome != MiaSquadra[idx - 1].nome && gi.nome != MiaSquadra[idx - 2].nome && gi.nome != MiaSquadra[idx - 3].nome && gi.nome != MiaSquadra[idx - 4].nome && gi.nome != MiaSquadra[idx - 5].nome)
                {
                    MiaSquadra[idx++] = gi;
                }
                else
                {
                    MessageBox.Show($"Giocatore già inserito");
                }
            }
            else
            {
                MessageBox.Show($"Numero massimo di giocatori inseribili ({MiaSquadra.Length}) raggiunto...");
            }
            dgSquadraMia.ItemsSource = MiaSquadra;
            dgSquadraMia.Items.Refresh();
            salva();
        }

        //FUNZIONE SALVA, DETTO IN BREVE, AGGIORNA LA MIA SQUADRA CON GLI ACQUISTI
        private void salva()
        {
            if (idx == MiaSquadra.Length)
            {
                StreamWriter sw = new StreamWriter("LaMiaSquadra.txt");
                for (int i = 0; i < MiaSquadra.Length; i++)
                {
                    sw.Write($"{MiaSquadra[i].nome};{MiaSquadra[i].cognome};");
                }
                sw.Close();
            }
        }
    }
}
