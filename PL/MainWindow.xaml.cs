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
using BL;
using BE;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Mother moth  = new Mother() ;
            moth.ShowDialog();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            var nann = new Nanny();
            nann.ShowDialog();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DataSearchWindoe data = new DataSearchWindoe();
            data.ShowDialog();
        }
    }
}
