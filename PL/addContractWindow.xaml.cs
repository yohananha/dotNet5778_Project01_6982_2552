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
using BL;
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for addContractWindow.xaml
    /// </summary>
    public partial class addContractWindow : Window
    {
        public BL.Ibl bl;
        public BE.Mother mom;
        public IEnumerable<BE.Child> childList;
        public IEnumerable<BE.Nanny> nannyList;  
        public addContractWindow()
        {
            InitializeComponent();

            bl = BL.FactoryBL.GetBL();
        }

        private void buttonSerchChildNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            mom = bl.getMother(Convert.ToInt64(textBoxMom.Text));
            childList = bl.getKidsByMoms(a => a.idMom == mom.IdMom);
            dataGridChildList.ItemsSource = childList;

            nannyList = bl.getAllCompatibleNanny(mom);
            dataGridNannyList.ItemsSource = nannyList;

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
    }
}
