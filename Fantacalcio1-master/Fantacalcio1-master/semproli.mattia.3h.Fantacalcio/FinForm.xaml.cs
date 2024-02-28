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
    /// Logica di interazione per FinForm.xaml
    /// </summary>
    public partial class FinForm : Window
    {
        public string giocatoreSelN, giocatoreSelC, f = "", fA, m1 = "", m1A, m2 = "", m2A, d = "", dA, p = "", pA, c1 = "", c1A, c2 = "", c2A, c3 = "", c3A;

        Giocatori[] MiaSquadra = new Giocatori[10];

        bool canPress = true, canQuit = false;

        public FinForm()
        {
            InitializeComponent();

            //ISTANZO L'ARRAY
            for (int i = 0; i < MiaSquadra.Length; i++)
            {
                MiaSquadra[i] = new Giocatori();
            }

            //LEGGO I GIOCATORI SCELTI NELLA MIA SQUADRA E LI METTO NELLA DATAGRID DEI MIEI GIOCATORI
            StreamReader sr = new StreamReader("LaMiaSquadra.txt");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string r = sr.ReadLine();
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
            }
            sr.Close();
            dgGiocatori.ItemsSource = MiaSquadra;
        }

        //SALVO LA FORMAZIONE SE TUTTI I BOTTONI SONO RIEMPITI
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (m1 != "" && m2 != "" && d != "" && f != "" && p != "" && c1 != "" && c2 != "" && c3 != "")
            {
                canPress = false;
                StreamWriter sw = new StreamWriter("Formazione.txt");
                sw.WriteLine($"{f};{fA};{m1};{m1A};{m2};{m2A};{d};{dA};{p};{pA};{c1};{c1A};{c2};{c2A};{c3};{c3A};");
                sw.Close();
                canQuit = true;
            }
            else
            {
                MessageBox.Show("Completa la formazione prima di salvare!!!");
            }
        }

        //PER MODIFICARE LA FORMAZZA
        private void modi_Click(object sender, RoutedEventArgs e)
        {
            canPress = true;
        }

        //RETURN TO HOME
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (m1 != "" && m2 != "" && d != "" && f != "" && p != "" && c1 != "" && c2 != "" && c3 != "")
            {
                if (canQuit)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Salva la formazione prima di uscire!!!");
                }
            }
            else
            {
                MessageBox.Show("Completa la formazione prima di uscire!!!");
            }
        }

        //SE SI STA CHIUDENDO LA FINESTRA SENZA SALVARE O SENZA COMPLETARE LA FORMAZIONE NON LA FA CHIUDERE
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (m1 != "" && m2 != "" && d != "" && f != "" && p != "" && c1 != "" && c2 != "" && c3 != "")
            {
                if (canQuit)
                {

                }
                else
                {
                    MessageBox.Show("Salva la formazione prima di uscire!!!");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("Completa la formazione prima di uscire!!!");
                e.Cancel = true;
            }
        }

        //INSERISCE IL NOME DEL GIOCATORE NEL PULSANTE SE NON E' GIA STATO MESSO
        private void Formazione_Click(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == m1 || giocatoreSelC == m2 || giocatoreSelC == d || giocatoreSelC == p || giocatoreSelC == c1 || giocatoreSelC == c2 || giocatoreSelC == c3)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    f = giocatoreSelC;
                    fA = giocatoreSelN;
                    forward.Content = $"{f}";
                }
            }
        }

        private void Formazione_Click1(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == f || giocatoreSelC == m2 || giocatoreSelC == d || giocatoreSelC == p || giocatoreSelC == c1 || giocatoreSelC == c2 || giocatoreSelC == c3)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    m1 = giocatoreSelC;
                    m1A = giocatoreSelN;
                    mid1.Content = $"{m1}";
                }
            }
        }

        private void Formazione_Click2(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == m1 || giocatoreSelC == f || giocatoreSelC == d || giocatoreSelC == p || giocatoreSelC == c1 || giocatoreSelC == c2 || giocatoreSelC == c3)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    m2 = giocatoreSelC;
                    m2A = giocatoreSelN;
                    mid2.Content = $"{m2}";
                }
            }
        }

        private void Formazione_Click3(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == m1 || giocatoreSelC == m2 || giocatoreSelC == f || giocatoreSelC == p || giocatoreSelC == c1 || giocatoreSelC == c2 || giocatoreSelC == c3)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    d = giocatoreSelC;
                    dA = giocatoreSelN;
                    defender.Content = $"{d}";
                }
            }
        }

        private void Formazione_Click4(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == m1 || giocatoreSelC == m2 || giocatoreSelC == d || giocatoreSelC == f || giocatoreSelC == c1 || giocatoreSelC == c2 || giocatoreSelC == c3)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    p = giocatoreSelC;
                    pA = giocatoreSelN;
                    por.Content = $"{p}";
                }
            }
        }

        private void Formazione_Click5(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == m1 || giocatoreSelC == m2 || giocatoreSelC == d || giocatoreSelC == p || giocatoreSelC == f || giocatoreSelC == c2 || giocatoreSelC == c3)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    c1 = giocatoreSelC;
                    c1A = giocatoreSelN;
                    casacca1.Content = $"{c1}";
                }
            }
        }

        private void Formazione_Click6(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == m1 || giocatoreSelC == m2 || giocatoreSelC == d || giocatoreSelC == p || giocatoreSelC == c1 || giocatoreSelC == f || giocatoreSelC == c3)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    c2 = giocatoreSelC;
                    c2A = giocatoreSelN;
                    casacca2.Content = $"{c2}";
                }
            }
        }

        private void Formazione_Click7(object sender, RoutedEventArgs e)
        {
            if (canPress)
            {
                if (giocatoreSelC == m1 || giocatoreSelC == m2 || giocatoreSelC == d || giocatoreSelC == p || giocatoreSelC == c1 || giocatoreSelC == c2 || giocatoreSelC == f)
                {
                    MessageBox.Show($"Giocatore gia inserito");
                }
                else
                {
                    c3 = giocatoreSelC;
                    c3A = giocatoreSelN;
                    casacca3.Content = $"{c3}";
                }
            }
        }

        //PRENDE I DATI DEL GIOCATORE SELEZIONATO
        private void DgGiocatori_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Giocatori g = dgGiocatori.SelectedItem as Giocatori;

            if (g != null)
            {
                giocatoreSelN = g.nome;
                giocatoreSelC = g.cognome;
            }
        }
    }
}
