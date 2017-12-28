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
    /// Interaction logic for addNanny2.xaml
    /// </summary>
    public partial class addNanny2 : Window
    {
        public BE.Nanny nannyToAdd;
        public BL.Ibl bl;


        public addNanny2()
        {
            InitializeComponent();
            nannyToAdd = new BE.Nanny();
            this.DataContext = nannyToAdd;
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addNanny(nannyToAdd);
                nannyToAdd = new BE.Nanny();
                this.DataContext = nannyToAdd;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
