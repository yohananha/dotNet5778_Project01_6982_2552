using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MomWindow.xaml
    /// </summary>
    public partial class MomWindow : Window
    {
        public BE.Mother mother;
        public BL.Ibl bl;
        public MomWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region addMomTab
        private void addMomTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mother = new BE.Mother();
            mother.startHour = new DateTime[6];
            mother.endHour = new DateTime[6];
            mother.DaysRequestMom = new bool[6];
            addMomTab.DataContext = mother;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addMom(mother);
                mother = new BE.Mother();
                addMomTab.DataContext = mother;
                MessageBox.Show("אם נוספה בהצלחה");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region updateMomTab
        private void updateMomTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (motherUpdateCombo.SelectedIndex == -1)
            {
                motherUpdateCombo.ItemsSource = bl.getAllMothers();
                motherUpdateCombo.DisplayMemberPath = "fullName";
                motherUpdateCombo.SelectedIndex = -1;
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (motherUpdateCombo.SelectedIndex != -1)
            {
                button3.IsEnabled = true;
                mother = (BE.Mother)motherUpdateCombo.SelectedItem;
                updateMomTab.DataContext = mother;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateMother(mother);
                MessageBox.Show("פרטי האם עודכנו");
                motherUpdateCombo.SelectedIndex = -1;
                mother = new BE.Mother();
                updateMomTab.DataContext = mother;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

        #region deleteMomTab
        private void delMomTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (deleteMomCombo.SelectedIndex == -1)
            {
                deleteMomCombo.ItemsSource = bl.getAllMothers();
                deleteMomCombo.DisplayMemberPath = "fullName";
                deleteMomCombo.SelectedIndex = -1;
            }
        }


        private void deleteMomCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (deleteMomCombo.SelectedIndex != -1)
            {
                mother = (BE.Mother)deleteMomCombo.SelectedItem;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteMother(mother.IdMom);
                MessageBox.Show("אם נמחקה מהמערכת");
                deleteMomCombo.Items.Refresh();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

    }
}
