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
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyWindow.xaml
    /// </summary>
    public partial class NannyWindow : Window
    {
        public BE.Nanny nanny;
        public BL.Ibl bl;

        public NannyWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        #region addNannyEvent
        private void button_buttonBackMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void button_Click_buttonAddNanny(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addNanny(nanny);
                nanny = new BE.Nanny();
                addNannyTab.DataContext = nanny;
                MessageBox.Show("המטפלת הוספה בהצלחה");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void addNannyTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            nanny = new BE.Nanny();
            nanny.startHour = new DateTime[6];
            nanny.endHour = new DateTime[6];
            nanny.daysWorkNanny = new bool[6];
            nanny.dateNanny = new DateTime(1990, 1, 1);
            addNannyTab.DataContext = nanny;
        }



        #endregion

        #region deleteNannyEvent
        private void deleteNannyTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            comboBoxNanny.ItemsSource = bl.getAllNanny();
            comboBoxNanny.DisplayMemberPath = "fullName";
            comboBoxNanny.SelectedValuePath = "nannyId";
            comboBoxNanny.SelectedIndex = -1;
        }

        private void buttonDeleteNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteNanny(Convert.ToInt64(comboBoxNanny.SelectedValue));
                MessageBox.Show("מטפלת נמחקה בהצלחה");
                comboBoxNanny.ItemsSource = bl.getAllNanny();
                comboBoxNanny.DisplayMemberPath = "fullName";
                comboBoxNanny.SelectedValuePath = "nannyId";
                comboBoxNanny.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion

        #region updateNannyEvent
        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            comboBoxNannyUpdate.ItemsSource = bl.getAllNanny();
            comboBoxNannyUpdate.DisplayMemberPath = "fullName";
            comboBoxNannyUpdate.SelectedIndex = -1;
        }

        private void comboBoxNannyUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonUpdateNanny.IsEnabled = true;
            nanny = (BE.Nanny)comboBoxNannyUpdate.SelectedItem;
            updateNannyTab.DataContext = nanny;
        }

        private void buttonUpdateNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateNanny(nanny);
                MessageBox.Show("פרטי המטפלת עודכנו");
                comboBoxNannyUpdate.SelectedIndex = -1;
                nanny = new Nanny();
                updateNannyTab.DataContext = nanny;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion

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

        #region add nanny input check

        private void nannyIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(nannyIdTextBox.Text, "int"))
                nannyIdTextBox.Text = "";
        }

        private void firstNameNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(firstNameNannyTextBox.Text, "string"))
                firstNameNannyTextBox.Text = "";
        }

        private void lastNameNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(lastNameNannyTextBox.Text, "string"))
                lastNameNannyTextBox.Text = "";
        }

        private void phoneNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(phoneNannyTextBox.Text, "int"))
                phoneNannyTextBox.Text = "";
        }

        private void experienceNannyTextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(phoneNannyTextBox.Text, "int"))
                phoneNannyTextBox.Text = "";
        }

        private void maxChildNannyTextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(maxChildNannyTextBox.Text, "int"))
                maxChildNannyTextBox.Text = "";
        }

        private void minAgeChildNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(minAgeChildNannyTextBox.Text, "int"))
                minAgeChildNannyTextBox.Text = "";
        }

        private void maxAgeChildNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(maxAgeChildNannyTextBox.Text, "int"))
                maxAgeChildNannyTextBox.Text = "";
        }

        private void floorNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(floorNannyTextBox.Text, "int"))
                floorNannyTextBox.Text = "";
        }

        private void rateHourNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(rateHourNannyTextBox.Text, "int"))
                rateHourNannyTextBox.Text = "";
        }

        private void rateMonthNannyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(rateMonthNannyTextBox.Text, "int"))
                rateMonthNannyTextBox.Text = "";
        }


        #endregion

        #region update nanny input check

        private void firstNameNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(firstNameNannyTextBoxUpdate.Text, "string"))
                firstNameNannyTextBoxUpdate.Text = "";
        }

        private void lastNameNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(lastNameNannyTextBoxUpdate.Text, "string"))
                lastNameNannyTextBoxUpdate.Text = "";
        }

        private void phoneNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(phoneNannyTextBoxUpdate.Text, "int"))
                phoneNannyTextBoxUpdate.Text = "";
        }

        private void minAgeChildNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(minAgeChildNannyTextBoxUpdate.Text, "int"))
                minAgeChildNannyTextBoxUpdate.Text = "";
        }

        private void maxAgeChildNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(maxAgeChildNannyTextBoxUpdate.Text, "int"))
                maxAgeChildNannyTextBoxUpdate.Text = "";
        }

        private void floorNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(floorNannyTextBoxUpdate.Text, "int"))
                floorNannyTextBoxUpdate.Text = "";
        }

        private void rateHourNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(rateHourNannyTextBoxUpdate.Text, "int"))
                rateHourNannyTextBoxUpdate.Text = "";
        }

        private void rateMonthNannyTextBoxUpdate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!stringCheck(rateMonthNannyTextBoxUpdate.Text, "int"))
                rateMonthNannyTextBoxUpdate.Text = "";
        }

        #endregion


    }
}
