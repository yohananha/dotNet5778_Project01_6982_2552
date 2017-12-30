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
    /// Interaction logic for deleteNannyWindow.xaml
    /// </summary>
    public partial class deleteNannyWindow : Window
    {
        public BL.Ibl bl;
        public deleteNannyWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteNanny(int.Parse(textBox.Text));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
