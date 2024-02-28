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
using System.Windows.Shapes;

namespace semproli.mattia._3h.Fantacalcio
{
    /// <summary>
    /// Logica di interazione per FinTut.xaml
    /// </summary>
    public partial class FinTut : Window
    {
        public FinTut()
        {
            InitializeComponent();
        }

        private void To_Home(object sender, RoutedEventArgs e)
        {
            Home HomeWPF = new Home();
            Close();
            HomeWPF.ShowDialog();
        }
    }
}
