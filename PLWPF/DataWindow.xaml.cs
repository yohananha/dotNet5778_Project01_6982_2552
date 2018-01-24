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
        IEnumerable<IGrouping<int, BE.Nanny>> list1;
        List<BE.Nanny> nannyListByAge;
        List<BE.Nanny> nannyListByDistance;
        ListCollectionView collection;


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
                                from b in bl.getKids(b => b.isSpecialNeed == true)
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

        #region momTabEvent
        private void buttonSearchMom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                momList = bl.getAllMothers();

                if (CheckBoxArrangedMom.IsChecked == true)
                    momList = from item in momList
                              let x = item.IdMom
                              where ((bl.getKids(a => a.idMom == x)).ToList().Count) == (from k in bl.getKids(k => k.idMom == x)
                                                                                         let y = k.idChild
                                                                                         from c in bl.getContracts()
                                                                                         where y == c.idChild
                                                                                         select k).ToList().Count
                              select item;

                if (checkBoxNotArrangedMom.IsChecked == true)
                    momList = from item in momList
                              let x = item.IdMom
                              where ((bl.getKids(a => a.idMom == x)).ToList().Count) != (from k in bl.getKids(k => k.idMom == x)
                                                                                         let y = k.idChild
                                                                                         from c in bl.getContracts()
                                                                                         where y == c.idChild
                                                                                         select k).ToList().Count
                              select item;

                if (checkBoxMomByNumChild.IsChecked == true)
                    momList = from item in momList
                              let x = item.IdMom
                              where bl.getKids(a => a.idMom == x).ToList().Count == int.Parse(numChildTextBox.Text)
                              select item;

                dataGridMomDetails.ItemsSource = momList;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

        #region nannyTabEvent
        private void checkBoxNannyByMom_Checked(object sender, RoutedEventArgs e)
        {

            if (comboBoxChoosMomNanny.SelectedIndex == -1)
            {
                comboBoxChoosMomNanny.ItemsSource = bl.getAllMothers();
                comboBoxChoosMomNanny.DisplayMemberPath = "fullName";
                comboBoxChoosMomNanny.SelectedValuePath = "AddressMom";
                comboBoxChoosMomNanny.SelectedIndex = -1;
            }
        }

        private void comboBoxChoosMomNanny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxChoosMomNanny.SelectedIndex != -1)
                mom = (BE.Mother)comboBoxChoosMomNanny.SelectedItem;
        }

        private void buttonSearchNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nannyList = bl.getAllNanny();

                if (checkBoxNannyByTamt.IsChecked == true)
                    nannyList = from a in nannyList
                                where a.isTamatNanny == true
                                select a;

                if (checkBoxNannyByHour.IsChecked == true)
                    nannyList = from a in nannyList
                                where a.isByHourNanny == true
                                select a;

                dataGridNanny.Visibility = Visibility.Visible;
                dataGridNanny.ItemsSource = nannyList;

                if (checkBoxNannyByAge.IsChecked == true)
                {

                    dataGridNanny.Visibility = Visibility.Hidden;
                    dataGridGrouping.Visibility = Visibility.Visible;
                    nannyListByAge = new List<BE.Nanny>();
                    if (checkBoxGroupByMax.IsChecked == true)
                        list1 = bl.getChildByAgeRange(false, true);
                    else
                        list1 = bl.getChildByAgeRange(true, true);
                    foreach (var it in list1)
                    {
                        if (it != null)
                        {
                            foreach (var item in it)
                            {
                                string tmp = (it.Key * 3).ToString();
                                string tmp2 = ((it.Key * 3) - 3).ToString();
                                string tmp3 = tmp2 + "-" + tmp + " Months";
                                item.KayGroupAge = tmp3.ToString();
                                nannyListByAge.Add(item);
                            }
                        }
                    }

                    collection = new ListCollectionView(nannyListByAge);
                    collection.GroupDescriptions.Add(new PropertyGroupDescription("KayGroupAge"));
                    dataGridGrouping.ItemsSource = collection;
                }



                if (checkBoxNannyByMom.IsChecked == true)
                {
                    dataGridNanny.Visibility = Visibility.Hidden;
                    dataGridGrouping.Visibility = Visibility.Hidden;
                    dataGridGroupingByDistance.Visibility = Visibility.Visible;

                    new Thread(() =>
                    {
                        nannyListByDistance = new List<BE.Nanny>();
                        list1 = bl.getNannyByDistance(mom.AddressMom, true);

                        foreach (var it in list1)
                        {
                            if (it != null)
                            {
                                foreach (var item in it)
                                {
                                    string tmp = ((it.Key + 1) * 500).ToString();
                                    string tmp2 = (((it.Key + 1) * 500) - 500).ToString();
                                    string tmp3 = tmp2 + "-" + tmp + " מטר";
                                    item.KayGroupDistance = tmp3.ToString();
                                    nannyListByDistance.Add(item);
                                }
                            }
                        }
                        Dispatcher.Invoke(new Action(() =>
                        {
                            collection = new ListCollectionView(nannyListByDistance);
                            collection.GroupDescriptions.Add(new PropertyGroupDescription("KayGroupDistance"));
                            dataGridGroupingByDistance.ItemsSource = collection;
                        }));
                    }).Start();
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        #endregion


    }
}