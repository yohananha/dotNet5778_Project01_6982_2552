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
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public BL.Ibl bl;
        public BE.Mother mom;
        public BE.Nanny nanny;
        public IEnumerable<BE.Mother> momList;
        public IEnumerable<BE.Nanny> nannyList;
        public IEnumerable<BE.Child> childList;
        public IEnumerable<BE.Contract> contractList;


        public DataWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region ChildTabEvent
        private void dataChildTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (comboBoxChildByMom.SelectedIndex == -1)
            {
                comboBoxChildByMom.ItemsSource = bl.getAllMothers();
                comboBoxChildByMom.DisplayMemberPath = "fullName";
                comboBoxChildByMom.SelectedValuePath = "IdMom";
                comboBoxChildByMom.SelectedIndex = -1;
            }
        }

        private void comboBoxChildByMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxChildByMom.SelectedIndex != -1)
                mom = (BE.Mother)comboBoxChildByMom.SelectedItem;
        }

        private void buttonSearchChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkBoxChildByMom.IsChecked == true)
                    childList = bl.getKids(a => a.idMom == (long)comboBoxChildByMom.SelectedValue);
                else
                    childList = bl.getKids();

                if (checkBoxNotNanny.IsChecked == true)
                    childList = from a in childList
                                let x = a.idChild
                                from b in bl.getAllChildWithoutNanny()
                                where x == b.idChild
                                select a;

                if (checkBoxWithSpaiclNeed.IsChecked == true)
                    childList = from a in childList
                                let x = a.idChild
                                from b in bl.getKids(a => a.isSpecialNeed == true)
                                where x == b.idChild
                                select a;

                dataGridDetailsChild.ItemsSource = childList;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

        #region ConractTabEvent

        private void dataContractTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (comboBoxContractByNanny.SelectedIndex == -1)
            {
                comboBoxContractByNanny.ItemsSource = bl.getAllNanny();
                comboBoxContractByNanny.DisplayMemberPath = "fullName";
                comboBoxContractByNanny.SelectedValuePath = "IdMom";
                comboBoxContractByNanny.SelectedIndex = -1;
            }
            if (comboBoxContractByMom.SelectedIndex == -1)
            {
                comboBoxContractByMom.ItemsSource = bl.getAllMothers();
                comboBoxContractByMom.DisplayMemberPath = "fullName";
                comboBoxContractByMom.SelectedValuePath = "IdMom";
                comboBoxContractByMom.SelectedIndex = -1;
            }
        }

        private void comboBoxContractByNanny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxContractByNanny.SelectedIndex != -1)
                nanny = (BE.Nanny)comboBoxContractByNanny.SelectedItem;
        }

        private void comboBoxContractByMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxContractByMom.SelectedIndex != -1)
                mom = (BE.Mother)comboBoxContractByMom.SelectedItem;
        }

        private void buttonSearchContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkBoxContractByMom.IsChecked == true && checkBoxContractByNanny.IsChecked == true)
                    throw new Exception("choose mom or nanny");

                if (checkBoxContractByMom.IsChecked == true)
                {
                    contractList = from a in bl.getKids(a => a.idMom == mom.IdMom)
                                   let x = a.idChild
                                   from b in bl.getContracts()
                                   where x == b.idChild
                                   select b;
                }
                else
                {
                    if (checkBoxContractByNanny.IsChecked == true)
                        contractList = bl.getContracts(a => a.idNanny == nanny.nannyId);
                    else
                        contractList = bl.getContracts();
                }

                if (checkBoxContractBySalery.IsChecked == true)
                    contractList = from a in contractList
                                   where ((a.salaryAgreed >= double.Parse(minTextBox.Text)) && (a.salaryAgreed <= double.Parse(maxTextBox.Text)))
                                   select a;

                if (checkBoxContractByHour.IsChecked == true)
                    contractList = from a in contractList
                                   where a.isHour == true
                                   select a;

                dataGridContractDetails.ItemsSource = contractList;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        private void buttonSearchMom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                momList = bl.getAllMothers();

                if (CheckBoxArrangedMom.IsChecked == true)
                    momList = from a in momList
                              let x = a.IdMom
                              where ((bl.getKids(a => a.idMom == x)).ToList().Count) == (from k in bl.getKids(a => a.idMom == x)
                                                                                         let y = k.idChild
                                                                                         from c in bl.getContracts()
                                                                                         where y == c.idChild
                                                                                         select k).ToList().Count
                              select a;

                if (checkBoxNotArrangedMom.IsChecked == true)
                    momList = from a in momList
                              let x = a.IdMom
                              where ((bl.getKids(a => a.idMom == x)).ToList().Count) != (from k in bl.getKids(a => a.idMom == x)
                                                                                         let y = k.idChild
                                                                                         from c in bl.getContracts()
                                                                                         where y == c.idChild
                                                                                         select k).ToList().Count
                              select a;

                if (checkBoxMomByNumChild.IsChecked == true)
                    momList = from a in momList
                              let x = a.IdMom
                              where bl.getKids(a => a.idMom == x).ToList().Count == int.Parse(numChildTextBox.Text)
                              select a;

                dataGridMomDetails.ItemsSource = momList;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}