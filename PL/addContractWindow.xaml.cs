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
        public BE.Contract contract;
        public BE.Nanny nanny;
        public BE.Child child;
        public IEnumerable<BE.Child> childList;
        public IEnumerable<BE.Nanny> nannyList;  
        public addContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            grid1.DataContext = contract;
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

        private void dataGridChildList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg.SelectedIndex > -1)
            {
                child = dg.SelectedItem as BE.Child;
                idChildTextBox.Text = Convert.ToString(child.idChild);
                contract.idChild = child.idChild;
            }
        }

        private void dataGridNannyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg.SelectedIndex > -1)
            {
                nanny = dg.SelectedItem as BE.Nanny;
                idNannyTextBox.Text = Convert.ToString(nanny.nannyId);
                isHourCheckBox.IsChecked = nanny.isByHourNanny;
                if (nanny.isByHourNanny)
                    salaryPerHourTextBox.Text = Convert.ToString(bl.getSalary(child.idChild, nanny.nannyId, true));
                salaryPerMonthTextBox.Text = Convert.ToString(bl.getSalary(child.idChild, nanny.nannyId, false));
                contract.idNanny = nanny.nannyId;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addContract(contract);
                MessageBox.Show("חוזה נחתם בהצלחה");
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
