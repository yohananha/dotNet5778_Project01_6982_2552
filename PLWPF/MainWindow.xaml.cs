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
using BL;
using BE;

namespace PLWPF
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

        private void momSbutton_Click(object sender, RoutedEventArgs e)
        {
            var mom = new MomWindow();
            mom.ShowDialog();
        }

        private void kids_Click(object sender, RoutedEventArgs e)
        {
            var kid = new KidaWindow();
            kid.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var nanny = new NannyWindow();
            nanny.ShowDialog();
        }

        private void contract_Click(object sender, RoutedEventArgs e)
        {
            var contract = new ContractWindow();
            contract.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var data = new DataWindow();
            data.ShowDialog();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            var about = new aboutWindow();
            about.ShowDialog();
        }
    }
}
