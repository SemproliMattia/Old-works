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
    /// Logica di interazione per FinLaMiaSq.xaml
    /// </summary>
    public partial class FinLaMiaSq : Window
    {
        //VARIABILI
        Giocatori[] giocatore = new Giocatori[10];
        Giocatori[] rimasti = new Giocatori[5];
        int idx = 0;
        bool premuto1 = false, premuto2 = false, premuto3 = false;
        bool premuto4 = false, premuto5 = false, premuto6 = false;
        bool premuto7 = false, premuto8 = false, premuto9 = false;
        bool premuto10 = false, premuto11 = false, premuto12 = false;
        bool premuto13 = false, premuto14 = false, premuto15 = false;
        bool aperta, caricato = false;

        public FinLaMiaSq()
        {
            InitializeComponent();

            //SCRIVO IL NOME SUI BOTTONI
            b1.Content = "Mark Evans";
            b2.Content = "Nathan Swift";
            b3.Content = "Jack Wallside";
            b4.Content = "Hurley Kane";
            b5.Content = "Tod Ironside";
            b6.Content = "Scott Banyan";
            b7.Content = "Archer Hawkins";
            b8.Content = "Caleb Stonewall";
            b9.Content = "Shawn Froste";
            b10.Content = "Axel Blaze";
            b11.Content = "Austin Hobbes";
            b12.Content = "Kevin Dragonfly";
            b13.Content = "Jordan Greenway";
            b14.Content = "Jude Sharp";
            b15.Content = "Xavier Foster";

            //CONTROLLO SE E' GIA STATA APERTA IN PRECEDENZA QUESTA FINESTRA
            StreamReader isOpened = new StreamReader("FinestraAperta.txt");
            for (int i = 0; !isOpened.EndOfStream; i++)
            {
                string r = isOpened.ReadLine();
                aperta = Convert.ToBoolean(r);
            }
            isOpened.Close();

            //ISTANZO L'ARRAY DELLA DATAGRID
            for (int i = 0; i < giocatore.Length; i++)
            {
                giocatore[i] = new Giocatori();
            }

            //SE ERA GIA STATA APERTA PRIMA, CARICO GIA LA SQUADRA CREATA PRECEDENTEMENTE
            if (aperta == true)
            {
                StreamReader miasq = new StreamReader("LaMiaSquadra.txt");
                for (int i = 0; !miasq.EndOfStream; i++)
                {
                    string r = miasq.ReadLine();
                    string[] dati = r.Split(';');
                    giocatore[0].nome = dati[0];
                    giocatore[0].cognome = dati[1];

                    giocatore[1].nome = dati[2];
                    giocatore[1].cognome = dati[3];

                    giocatore[2].nome = dati[4];
                    giocatore[2].cognome = dati[5];

                    giocatore[3].nome = dati[6];
                    giocatore[3].cognome = dati[7];

                    giocatore[4].nome = dati[8];
                    giocatore[4].cognome = dati[9];

                    giocatore[5].nome = dati[10];
                    giocatore[5].cognome = dati[11];

                    giocatore[6].nome = dati[12];
                    giocatore[6].cognome = dati[13];

                    giocatore[7].nome = dati[14];
                    giocatore[7].cognome = dati[15];

                    giocatore[8].nome = dati[16];
                    giocatore[8].cognome = dati[17];

                    giocatore[9].nome = dati[18];
                    giocatore[9].cognome = dati[19];

                    idx = 10;
                    caricato = true;
                }
                miasq.Close();
                dgDati.ItemsSource = giocatore;
            }
            else
            {
                dgDati.ItemsSource = giocatore;
            }
        }

        //QUANDO SI CARICA LA FINESTRA SI APRE UNA MESSAGEBOX CON UNA AVVERTENZA
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ogni giocatore è 'un pulsante' premilo per agggiungerlo in squadra, " +
                            "ATTENZIONE una volta cliccato non puoi cambiarlo, quindi scegli attentamente");
        }

        //LE FUNZIONI DEI BOTTONI:
        //RIPETUTA PER I 15 BOTTONI
        //CONTROLLO CHE NON ABBIA GIA INSERITO IL NUMERO MASSIMO DI GIOCATORI OVVERO 10
        //E CHE IL PULSANTE NON SIA GIA STATO PREMUTO
        //SE ALMENO UNA DELLE DUE NON E' VERIFICATA, APRO UNA MESSAGEBOX CHE AVVISERA L'INDISPONIBILITA' DI POSTI O DI UN GIOCATORE GIA INSERITO
        //E INFINE OLTRE AL REFRESH E AL SOURCE, GLI LANCIO LA FUNZIONE Load() SPIEGATA SUCCESSIVAMENTE
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto1 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Mark";
                G.cognome = "Evans";
                giocatore[idx++] = G;
                premuto1 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto2 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Nathan";
                G.cognome = "Swift";
                giocatore[idx++] = G;
                premuto2 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto3 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Jack";
                G.cognome = "Wallside";
                giocatore[idx++] = G;
                premuto3 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto4 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Hurley";
                G.cognome = "Kane";
                giocatore[idx++] = G;
                premuto4 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto5 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Tod";
                G.cognome = "Ironside";
                giocatore[idx++] = G;
                premuto5 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto6 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Scott";
                G.cognome = "Banyan";
                giocatore[idx++] = G;
                premuto6 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        //RETURN TO HOME
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto7 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Archer";
                G.cognome = "Hawkins";
                giocatore[idx++] = G;
                premuto7 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto8 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Caleb";
                G.cognome = "Stonewall";
                giocatore[idx++] = G;
                premuto8 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B9_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto9 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Shawn";
                G.cognome = "Froste";
                giocatore[idx++] = G;
                premuto9 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B10_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto10 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Axel";
                G.cognome = "Blaze";
                giocatore[idx++] = G;
                premuto10 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B11_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto11 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Austin";
                G.cognome = "Hobbes";
                giocatore[idx++] = G;
                premuto11 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B12_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto12 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Kevin";
                G.cognome = "Dragonfly";
                giocatore[idx++] = G;
                premuto12 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B13_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto13 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Jordan";
                G.cognome = "Greenway";
                giocatore[idx++] = G;
                premuto13 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B14_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto14 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Jude";
                G.cognome = "Sharp";
                giocatore[idx++] = G;
                premuto14 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        private void B15_Click(object sender, RoutedEventArgs e)
        {
            if (idx < giocatore.Length && premuto15 == false)
            {
                Giocatori G = new Giocatori();
                G.nome = "Xavier";
                G.cognome = "Foster";
                giocatore[idx++] = G;
                premuto15 = true;
            }
            else
            {
                MessageBox.Show("Giocatore già inserito o numero massimo di giocatori inseriti raggiunto");
            }
            Load();
            dgDati.ItemsSource = giocatore;
            dgDati.Items.Refresh();
        }

        //FUNZIONE Load()
        //FUNZIONE APPLICATA SU OGNI BOTTONE
        //CONTROLLO PRIMA DI TUTTO SE HA COMPLETATO LA SQUADRA CIOE' SE HA RIEMPITO TUTTI I POSTI DISPONIBILI
        //POI SE LA FINESTRA ERA GIA STATA LANCIATA OVVERO ERA GIA STATO EFFETTUATO UN CARICAMENTO, DISATTIVO QUESTA FUNZIONE( "Load()" ) PERCHE NON SERVE RICARICARE
        //SE INVECE NON ERA MAI STATA APERTA E QUINDI E' LA PRIMA VOLTA:
        //CARICO I GIOCATORI DELLA SQUADRA SU UN FILE LAMIASQUADRA
        //E CONTROLLO QUALI BOTTONI NON SONO STATI PREMUTI, IN TEORIA 5 (perche 15 gioc totali - 10 della squadra = 5) E CARICO I CORRISPETTIVI IN UN FILE GIOCATORIRIMANENTI
        private void Load()
        {
            if (idx == giocatore.Length)
            {
                if (caricato == false)
                {
                    StreamWriter sw = new StreamWriter("LaMiaSquadra.txt");
                    for (int i = 0; i < giocatore.Length; i++)
                    {
                        sw.Write($"{giocatore[i].nome};{giocatore[i].cognome};");
                    }
                    sw.Close();

                    for (int i = 0; i < rimasti.Length; i++)
                    {
                        if (premuto1 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Mark";
                            G.cognome = "Evans";
                            rimasti[i++] = G;
                        }
                        if (premuto2 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Natha";
                            G.cognome = "Swift";
                            rimasti[i++] = G;
                        }
                        if (premuto3 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Jack";
                            G.cognome = "Wallside";
                            rimasti[i++] = G;
                        }
                        if (premuto4 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Hurley";
                            G.cognome = "Kane";
                            rimasti[i++] = G;
                        }
                        if (premuto5 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Tod";
                            G.cognome = "Ironside";
                            rimasti[i++] = G;
                        }
                        if (premuto6 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Scott";
                            G.cognome = "Banyan";
                            rimasti[i++] = G;
                        }
                        if (premuto7 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Archer";
                            G.cognome = "Hawkins";
                            rimasti[i++] = G;
                        }
                        if (premuto8 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Caleb";
                            G.cognome = "Stonewall";
                            rimasti[i++] = G;
                        }
                        if (premuto9 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Shawn";
                            G.cognome = "Froste";
                            rimasti[i++] = G;
                        }
                        if (premuto10 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Axel";
                            G.cognome = "Blaze";
                            rimasti[i++] = G;
                        }
                        if (premuto11 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Austin";
                            G.cognome = "Hobbes";
                            rimasti[i++] = G;
                        }
                        if (premuto12 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Kevin";
                            G.cognome = "Dragonfly";
                            rimasti[i++] = G;
                        }
                        if (premuto13 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Jordan";
                            G.cognome = "Greenway";
                            rimasti[i++] = G;
                        }
                        if (premuto14 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Jude";
                            G.cognome = "Sharp";
                            rimasti[i++] = G;
                        }
                        if (premuto15 == false)
                        {
                            Giocatori G = new Giocatori();
                            G.nome = "Xavier";
                            G.cognome = "Foster";
                            rimasti[i++] = G;
                        }
                    }
                    StreamWriter ws = new StreamWriter("GiocatoriRimanenti.txt");
                    for (int i = 0; i < 5; i++)
                    {
                        ws.Write($"{rimasti[i].nome};{rimasti[i].cognome};");
                    }
                    ws.Close();
                }
                else
                {

                }
            }
        }

        //QUANDO L'UTENTE CLICCA LA X PER CHIUDERE LA FINESTRA, CONTROLLO SE IL NUMERO DI GIOCATORI IN SQUADRA E' MINORE DI 10 OVVERO IL TOTALE
        //SE E' MINORE DI 10 SIGNIFICA CHE L'UTENTE NON HA INSERITO TUTTI I GIOCATORI POSSIBILI E NON HA COMPLETATO LA SQUADRA, QUINDI "GLI DICO DI COMPLETARE IL TEAM PRIMA DI USCIRE" E LA FINESTRA NON SI CHIUDE
        //INVECE SE IL N. DI GIOCATORI E' 10:
        //PRIMA DI CHIUDERE LA FINESTRA, CARICO SU UN FILE FINESTRAAPERTA, IL VALORE TRUE DI OPENED IN MODO CHE SE IN FUTURO SARA' RIAPERTA QUESTA FINESTRA, TRAMITE IL CONTROLLO ALL'INIZIO CAPIREMO SE ERA GIA STATA APERTA O NO
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (idx != 10)
            {
                MessageBox.Show("La tua squadra deve essere obbligatoriamente composta da 10 giocatori");
                e.Cancel = true;
            }
            bool opened = true;
            StreamWriter open = new StreamWriter("FinestraAperta.txt");
            open.WriteLine($"{opened}");
            open.Close();
        }
    }
}
