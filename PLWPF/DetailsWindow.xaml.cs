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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {

        public DetailsWindow(object obj)
        {
            InitializeComponent();
            if (obj is BE.Child)
            {
                gridChild.Visibility = Visibility.Visible;
                gridChild.DataContext = (BE.Child)obj;
            }
            if (obj is BE.Contract)
            {
                gridContract.Visibility = Visibility.Visible;
                gridContract.DataContext = (BE.Contract)obj;
            }
            if (obj is BE.Mother)
            {
                gridMom.Visibility = Visibility.Visible;
                gridMom.DataContext = (BE.Mother)obj;
            }
            if (obj is BE.Nanny)
            {
                gridNanny.Visibility = Visibility.Visible;
                gridNanny.DataContext = (BE.Nanny)obj;
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
