using System;
using System.IO;
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
using System.Windows.Shapes;

namespace semproli.mattia._3h.Fantacalcio
{
    /// <summary>
    /// Logica di interazione per Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        //VARIABILI
        int click = 0, clickForm = 0;
        bool mercato;

        public Home()
        {
            InitializeComponent();

            //LEGGO NOME UTENTE E NOME TEAM E LI SCRIVO NELL APPOSITO SPAZIO
            StreamReader sr = new StreamReader("dati.txt");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string r = sr.ReadLine();
                string[] dati = r.Split(';');
                nome.Content = $"NOME: {dati[0]}";
                squadra.Content = $"NOME TEAM: {dati[1]}";
            }
            sr.Close();
        }

        //COMUNICO ALL'UTENTE CHE LA FINESTRA DEL MERCATO POTRA' ESSERE APERTA UNA SOLA VOLTA
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            champ.Content = "      GIOCA\nCAMPIONATO";
            MessageBox.Show("ATTENZIONE, RICORDA CHE IL MERCATO NELL'APPOSITA SEZIONE POTRA' ESSERE EFFETTUATO UNA SOLA VOLTA, DOPODICHE' NON POTRA' PIU' ESSERE APERTO, PERCHE' LA SESSIONE DI MERCATO E' UNA SOLA");
        }

        //ASSEGNO AI VARI BOTTONI LE RISPETTIVE FINESTRE DA APRIRE
        private void Stor_Click(object sender, RoutedEventArgs e)
        {
            FinStor stor = new FinStor();
            stor.ShowDialog();
        }

        //QUESTA E' "LA FINESTRA PIU' IMPORTANTE" PERCHE' E' QUELLA IN CUI CREERAI LA SQUADRA
        //SE CLICK E' 0 SIGNIFICA CHE NON E' MAI STATA APERTA E QUINDI CARICA SU FINESTRAAPERTA IL VALORE FALSE CHE SERVIRA' PIU' AVANTI APPUNTO NELLA FINESTRA "LAMIASQ"
        //POI ASSEGNA A CLICK IL VALORE 1 INDICANDO COSI' CHE E' STATA GIA APERTA
        private void LaMiaSq_Click(object sender, RoutedEventArgs e)
        {
            if (click == 0)
            {
                StreamWriter open = new StreamWriter("FinestraAperta.txt");
                open.WriteLine($"false");
                open.Close();
            }

            click = 1;
            FinLaMiaSq sq = new FinLaMiaSq();
            sq.ShowDialog();
        }

        //NEI 3 SEGUENTI PULSANTI CHE APRIRANNO LE RISPETTIVE FINESTRE
        //E' OBBLIGATORIO CONTROLLARE CHE L'UTENTE SIA GIA "PASSATO" DALLA FINESTRA PER CREARE LA ROSA SE NO LA FINESTRA DEL MERCATO, DELLA FORMAZIONE E DEL GIOCA NON POTRANNO ESSERE APERTE ED UTILIZZATE NON AVENDO UNA SQUADRA CREATA
        //QUINDI, SE CLICK OVVERO LA VARIABILE USATA SOPRA PER IDENTIFICARE LA FINESTRA DELLA SQUADRA, E' 1, VORRA' DIRE CHE L'UTENTE HA CREATO LA SQUADRA E QUINDI LE FINESTRE POTRANNO ESSERE APERTE CORRETTAMENTE
        //SE NO USCIRA UN MESSAGGIO CON SCRITTO CHE PRIMA DI APRIRE QUESTA/E FINESTRA/E DEVI CREARE UNA SQUADRA NELL'APPOSITA SEZIONE
        private void Gioc_Click(object sender, RoutedEventArgs e)
        {
            if (clickForm == 1)
            {
                FinGioc gi = new FinGioc();
                gi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Devi schierare una formazione nell'apposita sezione prima di poter giocare");
            }
        }

        private void Champ_Click(object sender, RoutedEventArgs e)
        {
            if (clickForm == 1)
            {
                FinChamp ch = new FinChamp();
                ch.ShowDialog();
            }
            else
            {
                MessageBox.Show("Devi schierare una formazione nell'apposita sezione prima di poter giocare il campionato");
            }
        }

        private void Merc_Click(object sender, RoutedEventArgs e)
        {
            if (click == 1)
            {
                if (mercato == false)
                {
                    mercato = true;
                    FinMerc mer = new FinMerc();
                    mer.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mi spiace, come avevo detto, il mercato poteva essere usato una sola volta");
                }
            }
            else
            {
                MessageBox.Show("Devi prima creare la tua squadra nell'apposita sezione(Bottone centrale)");
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Form_Click(object sender, RoutedEventArgs e)
        {
            if (click == 1)
            {
                FinForm fo = new FinForm();
                fo.ShowDialog();
                clickForm = 1;
            }
            else
            {
                MessageBox.Show("Devi prima creare la tua squadra nell'apposita sezione(Bottone centrale)");
            }
        }
    }
}
