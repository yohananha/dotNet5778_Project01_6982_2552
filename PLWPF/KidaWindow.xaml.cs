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
    /// Interaction logic for KidaWindow.xaml
    /// </summary>
    public partial class KidaWindow : Window
    {
        public BE.Child child;
        public BE.Mother mom;
        public BL.Ibl bl;

        public KidaWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #region add child event
        private void addChildTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            comboBoxMom.ItemsSource = bl.getAllMothers();
            comboBoxMom.DisplayMemberPath = "fullName";
            comboBoxMom.SelectedIndex = -1;
            child = new BE.Child();
            addChildTab.DataContext = child;
        }

        private void comboBoxMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mom = (BE.Mother)comboBoxMom.SelectedItem;
            if (mom != null)
            {
                idMomTextBox.Text = Convert.ToString(mom.IdMom);
                child.idMom = mom.IdMom;
            }

        }

        private void addChildButtom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                child.lastName = mom.LasNameMom;
                bl.addChild(child);
                MessageBox.Show("ילד נוסף בהצלחה");
                child = new BE.Child();
                addChildTab.DataContext = child;
                comboBoxMom.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

        #region delete child event
        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            comboBoxMomDelete.ItemsSource = bl.getAllMothers();
            comboBoxMomDelete.DisplayMemberPath = "fullName";
            comboBoxMomDelete.SelectedValuePath = "IdMom";
            comboBoxMomDelete.SelectedIndex = -1;
        }

        private void comboBoxMomDelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idCheck = Convert.ToInt64(comboBoxMomDelete.SelectedValue);
            comboBoxChild.ItemsSource = bl.getKids(a => a.idMom == idCheck);
            comboBoxChild.DisplayMemberPath = "fullName";
            comboBoxChild.SelectedValuePath = "idChild";
            comboBoxChild.SelectedIndex = -1;
        }

        private void buttonDeleteChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteChild(Convert.ToInt64(comboBoxChild.SelectedValue));
                MessageBox.Show("הילד/ה נמחק/ה בהצלחה");
                comboBoxChild.SelectedIndex = -1;
                comboBoxMomDelete.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        #endregion

        private void updateChildTab_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            comboBoxChoseMom.ItemsSource = bl.getAllMothers();
            comboBoxChoseMom.DisplayMemberPath = "fullName";
            comboBoxChoseMom.SelectedValuePath = "IdMom";
            comboBoxChoseMom.SelectedIndex = -1;
        }

        private void comboBoxChoseMom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            comboBoxChoseChild.ItemsSource = bl.getKids(a => a.idMom == Convert.ToInt64(comboBoxChoseMom.SelectedValue));
            comboBoxChoseChild.DisplayMemberPath = "fullName";
            comboBoxChoseChild.SelectedValuePath = "idChild";
            comboBoxChoseChild.SelectedIndex = -1;
        }

        private void comboBoxChoseChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            child = (BE.Child)comboBoxChoseChild.SelectedItem;
            updateChildTab.DataContext = child;
            buttonupdateChild.IsEnabled = true;
        }

        private void buttonupdateChild_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                buttonupdateChild.IsEnabled = true;
                bl.updateChild(child);
                MessageBox.Show("פרטי ילד עודכנו בהצלחה");
                comboBoxChoseChild.SelectedIndex = -1;
                comboBoxChoseMom.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void comboBoxChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonDeleteChild.IsEnabled = true;
        }
    }
}
