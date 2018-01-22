using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public BE.Mother mom;
        public BL.Ibl bl;

        public ContractWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region addContractEvent
        private void addContractTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (comboBoxChooseChild.SelectedIndex == -1)
            {
                comboBoxChooseMom.ItemsSource = bl.getAllMothers();
                comboBoxChooseMom.DisplayMemberPath = "fullName";
                comboBoxChooseMom.SelectedValuePath = "IdMom";
                comboBoxChooseMom.SelectedIndex = -1;
            }
        }

        private void comboBoxChooseMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxChooseMom.SelectedIndex != -1)
            {
                comboBoxChooseChild.ItemsSource = bl.getKids(a => a.idMom == Convert.ToInt64(comboBoxChooseMom.SelectedValue));
                comboBoxChooseChild.DisplayMemberPath = "fullName";
                comboBoxChooseChild.SelectedValuePath = "idChild";
                comboBoxChooseChild.SelectedIndex = -1;
                contract = new BE.Contract();
                addContractTab.DataContext = contract;
                try
                {
                    new Thread(() =>
                       {
                           Dispatcher.Invoke(new Action(() =>
                     {
                         var copNanny = bl.getAllCompatibleNanny((BE.Mother)comboBoxChooseMom.SelectedItem);
                         dataGridDetalis.ItemsSource = copNanny;
                         dataGridDetalis.SelectedValuePath = "nannyId";
                     }));
                       }).Start();
                }
                catch (Exception n)
                {
                    MessageBox.Show(n.Message);
                }
            }
        }

        private void comboBoxChooseChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxChooseChild.SelectedIndex != -1)
            {
                contract.idChild = (long)comboBoxChooseChild.SelectedValue;

            }
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
                    contract.salaryPerHour = bl.getSalary(contract.idChild, nanny.nannyId, true, false);
                }
                contract.salaryPerMonth = bl.getSalary(contract.idChild, nanny.nannyId, false, false);
                contract.idNanny = nanny.nannyId;
            }
        }

        private void buttonAddContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract.nameChild = (bl.getChild(contract.idChild)).fullName;
                contract.nameNanny = nanny.fullName;
                if (contract.isHour)
                    contract.salaryAgreed = contract.salaryPerHour;
                else
                    contract.salaryAgreed = contract.salaryPerMonth;
                bl.addContract(contract);
                MessageBox.Show("חוזה נחתם בהצלחה");
                dataGridDetalis.ItemsSource = null;
                comboBoxChooseChild.SelectedIndex = -1;
                comboBoxChooseMom.SelectedIndex = -1;
                contract = new BE.Contract();
                addContractTab.DataContext = contract;

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
            comboBoxchooseChildDelete.ItemsSource = bl.getKids(a => a.idMom == Convert.ToInt64(comboBoxChooseMomdelete.SelectedValue));
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

        #region UpdateContractEvent
        private void updateContracTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (comboBoxchooseMomUPdate.SelectedIndex == -1)
            {
                comboBoxchooseMomUPdate.ItemsSource = bl.getAllMothers();
                comboBoxchooseMomUPdate.DisplayMemberPath = "fullName";
                comboBoxchooseMomUPdate.SelectedValuePath = "IdMom";
                comboBoxchooseMomUPdate.SelectedIndex = -1;
            }

        }

        private void comboBoxchooseMomUPdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxchooseMomUPdate.SelectedIndex != -1)
            {
                comboBoxChooseChildUpdate.ItemsSource = bl.getKids(a => a.idMom == Convert.ToInt64(comboBoxchooseMomUPdate.SelectedValue));
                comboBoxChooseChildUpdate.DisplayMemberPath = "fullName";
                comboBoxChooseChildUpdate.SelectedValuePath = "idChild";
                comboBoxChooseChildUpdate.SelectedIndex = -1;
            }
        }

        private void comboBoxChooseChildUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (comboBoxChooseChildUpdate.SelectedIndex != -1)
                {
                    contract = bl.getContract((long)comboBoxChooseChildUpdate.SelectedValue);
                    gridDetalisContract.DataContext = contract;
                    mom = bl.getMother((long)comboBoxchooseMomUPdate.SelectedValue);
                    gridHourMom.DataContext = mom;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void buttonUpdateMomhour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!bl.checkSchedule(bl.getNanny(contract.idNanny), mom))
                    throw new Exception("המטפלת לא עובדת בשעות הנדרשות");

                if (contract.isHour == true)
                    contract.salaryPerHour = bl.getSalary(contract.idChild, contract.idNanny, true, true);
                contract.salaryPerMonth = bl.getSalary(contract.idChild, contract.idNanny, false, true);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void buttonUpdateContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (contract.isHour)
                    contract.salaryAgreed = contract.salaryPerHour;
                else
                    contract.salaryAgreed = contract.salaryPerMonth;
                bl.updateContract(contract);
                MessageBox.Show("חוזה עודכן בהצלחה");
                comboBoxChooseChildUpdate.SelectedIndex = -1;
                comboBoxchooseMomUPdate.SelectedIndex = -1;
                contract = new BE.Contract();
                gridDetalisContract.DataContext = contract;
                mom = new BE.Mother();
                gridHourMom.DataContext = mom;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion


    }
}
