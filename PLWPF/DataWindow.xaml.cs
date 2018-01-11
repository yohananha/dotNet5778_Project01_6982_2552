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

        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
    }
}
