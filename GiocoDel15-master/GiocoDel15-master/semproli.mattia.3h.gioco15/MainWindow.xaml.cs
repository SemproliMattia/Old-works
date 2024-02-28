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

namespace semproli.mattia._3h.gioco15
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const int rMax = 4, cMax = 4;
        string[,] campo = new string[rMax, cMax];
        int rvuoto, cvuoto, r, c, mosse;

        void EasyWin()
        {
            int pp = 0, p = 0;

            for (int r = 0; r < rMax; r++)
            {
                for (int c = 0; c < cMax; c++)
                {
                    pp++;

                    if (campo[r,c] == pp.ToString())
                    {
                        p++;

                        if (p == 15)
                        {
                            tbl.Text = $"hai vinto utilizzando {mosse} mosse";
                            mosse = 0;
                            mescolare();
                            stampa();
                        }
                    }
                }
            }
        }

        void riempi()
        {
            for (int r = 0; r < rMax; r++)
            {
                for (int c = 0; c < cMax; c++)
                {
                    campo[r, c] = Convert.ToString(c + 1 + r * rMax);
                }
            }
            campo[3, 3] = "";
        }

        void stampa()
        {
            b0.Content = campo[0, 0];
            b1.Content = campo[0, 1];
            b2.Content = campo[0, 2];
            b3.Content = campo[0, 3];
            b4.Content = campo[1, 0];
            b5.Content = campo[1, 1];
            b6.Content = campo[1, 2];
            b7.Content = campo[1, 3];
            b8.Content = campo[2, 0];
            b9.Content = campo[2, 1];
            b10.Content = campo[2, 2];
            b11.Content = campo[2, 3];
            b12.Content = campo[3, 0];
            b13.Content = campo[3, 1];
            b14.Content = campo[3, 2];
            b15.Content = campo[3, 3];

        }

        void tassellovuoto()
        {
            for (int r = 0; r < rMax; r++)
            {
                for (int c = 0; c < cMax; c++)
                {
                    if (campo[r, c] == "")
                    {
                        rvuoto = r;
                        cvuoto = c;
                    }
                }
            }
        }

        void mescolare()
        {
            Random rnd = new Random();
            for (int i = 0; i <= 100; i++)
            {
                int r1 = rnd.Next(0, rMax);
                int c1 = rnd.Next(0, cMax);
                int r2 = rnd.Next(0, rMax);
                int c2 = rnd.Next(0, cMax);
                string pass = campo[r1, c1];
                campo[r1, c1] = campo[r2, c2];
                campo[r2, c2] = pass;
            }
        }

        void mossa()
        {
            if (Math.Abs(r - rvuoto) + Math.Abs(c - cvuoto) == 1)
            {
                string pass = campo[r, c];
                campo[r, c] = campo[rvuoto, cvuoto];
                campo[rvuoto, cvuoto] = pass;
            }
            mosse++;
            tbl.Text = $"mosse effettuate: {mosse}";
        }

        public MainWindow()
        {
            InitializeComponent();
            riempi();
            mescolare();
            stampa();
            EasyWin();
        }

        private void b0_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 0;
            c = 0;
            mossa();
            stampa();
            EasyWin();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 0;
            c = 1;
            mossa();
            stampa();
            EasyWin();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 0;
            c = 2;
            mossa();
            stampa();
            EasyWin();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 0;
            c = 3;
            mossa();
            stampa();
            EasyWin();
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 1;
            c = 0;
            mossa();
            stampa();
            EasyWin();
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 1;
            c = 1;
            mossa();
            stampa();
            EasyWin();
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 1;
            c = 2;
            mossa();
            stampa();
            EasyWin();
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 1;
            c = 3;
            mossa();
            stampa();
            EasyWin();
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 2;
            c = 0;
            mossa();
            stampa();
            EasyWin();
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 2;
            c = 1;
            mossa();
            stampa();
            EasyWin();
        }

        private void b10_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 2;
            c = 2;
            mossa();
            stampa();
            EasyWin();
        }

        private void b11_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 2;
            c = 3;
            mossa();
            stampa();
            EasyWin();
        }

        private void b12_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 3;
            c = 0;
            mossa();
            stampa();
            EasyWin();
        }

        private void b13_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 3;
            c = 1;
            mossa();
            stampa();
            EasyWin();
        }

        private void b14_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 3;
            c = 2;
            mossa();
            stampa();
            EasyWin();
        }

        private void b15_Click(object sender, RoutedEventArgs e)
        {
            tassellovuoto();
            r = 3;
            c = 3;
            mossa();
            stampa();
            EasyWin();
        }
    }
}
