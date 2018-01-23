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
                comboBoxNanny.SelectedIndex=-1;
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
                comboBoxNannyUpdate.Items.Refresh();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        #endregion
    }
}
