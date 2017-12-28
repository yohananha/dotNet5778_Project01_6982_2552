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

namespace PL
{
    /// <summary>
    /// Interaction logic for Nanny.xaml
    /// </summary>
    public partial class Nanny : Window
    {
        public Nanny()
        {
            InitializeComponent();
        }

        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
            addNanny2 add = new addNanny2();
            add.Show();
        }

        private void DelNanny_Click(object sender, RoutedEventArgs e)
        {
            deleteNannyWindow deleteNanny = new deleteNannyWindow();
            deleteNanny.Show();
        }
    }
}
