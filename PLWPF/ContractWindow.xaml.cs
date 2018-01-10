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
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        public BE.Nanny nanny;
        public BE.Child child;
        public BE.Contract contract;
        public BL.Ibl bl;

        public ContractWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            comboBoxChooseMom.ItemsSource = bl.getAllMothers();
            comboBoxChooseMom.DisplayMemberPath = "fullName";
            comboBoxChooseMom.SelectedValuePath = "IdMom";
            comboBoxChooseMom.SelectedIndex = -1;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region addContractEvent
        private void comboBoxChooseMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxChooseChild.ItemsSource = bl.getKidsByMoms(a => a.idMom == Convert.ToInt64(comboBoxChooseMom.SelectedValue));
            comboBoxChooseChild.DisplayMemberPath = "fullName";
            comboBoxChooseChild.SelectedValuePath = "idChild";
            comboBoxChooseChild.SelectedIndex = -1;
            contract = new BE.Contract();
            addContractTab.DataContext = contract;
           
        }

        private void comboBoxChooseChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contract.idChild = (long)comboBoxChooseChild.SelectedValue;
            dataGridDetalis.ItemsSource = bl.getAllCompatibleNanny((BE.Mother)comboBoxChooseMom.SelectedItem);
            dataGridDetalis.SelectedValuePath = "nannyId";
        }

        private void dataGridDetalis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dg = sender as DataGrid;
            if (dg.SelectedIndex > -1)
            {
                nanny = dg.SelectedItem as BE.Nanny;
                contract.isHour = nanny.isByHourNanny;
                if (nanny.isByHourNanny)
                {
                    contract.salaryPerHour = bl.getSalary(contract.idChild, nanny.nannyId, true);
                }
                contract.salaryPerMonth = bl.getSalary(contract.idChild, nanny.nannyId, false);
                contract.idNanny = nanny.nannyId;
            }
        }

        private void buttonAddContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addContract(contract);
                MessageBox.Show("חוזה נחתם בהצלחה");
                contract = new BE.Contract();
                addContractTab.DataContext = contract;
                dataGridDetalis.ItemsSource = null;
                comboBoxChooseChild.SelectedIndex = -1;
                comboBoxChooseMom.SelectedIndex = -1;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }



        #endregion

        #region deleteContractEvent
        private void deleteContractTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            comboBoxChooseMomdelete.ItemsSource = bl.getAllMothers();
            comboBoxChooseMomdelete.DisplayMemberPath = "fullName";
            comboBoxChooseMomdelete.SelectedValuePath = "IdMom";
            comboBoxChooseMomdelete.SelectedIndex = -1;
        }

        private void comboBoxChooseMomdelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxchooseChildDelete.ItemsSource = bl.getKidsByMoms(a => a.idMom == Convert.ToInt64(comboBoxChooseMomdelete.SelectedValue));
            comboBoxchooseChildDelete.DisplayMemberPath = "fullName";
            comboBoxchooseChildDelete.SelectedValuePath = "idChild";
            comboBoxchooseChildDelete.SelectedIndex = -1;
        }

        private void comboBoxchooseChildDelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            child = (BE.Child)comboBoxchooseChildDelete.SelectedItem;
        }

        private void buttonDeleteContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteContract(child.idChild);
                MessageBox.Show("חוזה נמחק בהצלחה");
                comboBoxchooseChildDelete.SelectedIndex = -1;
                comboBoxChooseMomdelete.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion


    }
}
