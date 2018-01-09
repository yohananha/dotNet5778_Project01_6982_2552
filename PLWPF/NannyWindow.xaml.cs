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
        public BE.Nanny nannyToAdd;
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
                bl.addNanny(nannyToAdd);
                nannyToAdd = new BE.Nanny();
                addNannyTab.DataContext = nannyToAdd;
                MessageBox.Show("המטפלת הוספה בהצלחה");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void addNannyTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            nannyToAdd = new BE.Nanny();
            nannyToAdd.startHour = new DateTime[6];
            nannyToAdd.endHour = new DateTime[6];
            nannyToAdd.daysWorkNanny = new bool[6];
            addNannyTab.DataContext = nannyToAdd;
        }



        #endregion

        private void deleteNannyTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            comboBoxNanny.ItemsSource = bl.getAllNanny();
            comboBoxNanny.DisplayMemberPath = "fullName";
            comboBoxNanny.SelectedValuePath = "nannyId";
        }

        private void buttonDeleteNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteNanny(Convert.ToInt64(comboBoxNanny.SelectedValue));
                MessageBox.Show("מטפלת נמחקה בהצלחה");
                comboBoxNanny.Items.Refresh();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
