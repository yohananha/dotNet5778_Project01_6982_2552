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
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        #region addMomTab
        private void addMomTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mother == null)
            {
                mother = new BE.Mother();
                mother.startHour = new DateTime[6];
                mother.endHour = new DateTime[6];
                mother.DaysRequestMom = new bool[6];
                addMomTab.DataContext = mother;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addMom(mother);
                mother = null;
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
                deleteMomCombo.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }
        #region input func check

        public bool stringCheck(string str, string type)
        {
            switch (type)
            {
                case "string":
                    foreach (char item in str)
                    {
                        if (char.IsDigit(item))
                        {
                            MessageBox.Show("נא להכניס אותיות בלבד");
                            return false;
                        }
                    }
                    break;
                case "int":
                    foreach (char item in str)
                    {
                        if (!char.IsDigit(item))
                        {
                            MessageBox.Show("נא להכניס מספרים בלבד");
                            return false;
                        }
                    }
                    break;
            }

            return true;
        }

        #endregion

        #region add mother input check

        private void firstNameMomTextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(firstNameMomTextBox.Text, "string"))
                firstNameMomTextBox.Text = "";
        }

        private void lasNameMomTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(firstNameMomTextBox.Text, "string"))
                firstNameMomTextBox.Text = "";
        }

        private void idMomTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(idMomTextBox.Text, "int"))
                idMomTextBox.Text = "";
        }

        private void phoneMomTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(phoneMomTextBox.Text, "int"))
                phoneMomTextBox.Text = "";
        }




        #endregion

        #region update mother input check

        private void firstNameMomTextBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(firstNameMomTextBox1.Text, "string"))
                firstNameMomTextBox1.Text = "";
        }

        private void lasNameMomTextBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(lasNameMomTextBox1.Text, "string"))
                lasNameMomTextBox1.Text = "";
        }

        private void phoneMomTextBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(phoneMomTextBox1.Text, "int"))
                phoneMomTextBox1.Text = "";
        }

        #endregion

    }
}
