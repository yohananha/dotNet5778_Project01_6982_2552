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

namespace PL
{
    /// <summary>
    /// Interaction logic for UpdateNannyWindow.xaml
    /// </summary>
    public partial class UpdateNannyWindow : Window
    {
        public BE.Nanny nannyToUpdate;
        public BL.Ibl bl;

        public UpdateNannyWindow()
        {
            InitializeComponent();
            nannyToUpdate = new BE.Nanny();
            nannyToUpdate.startHour = new DateTime[6];
            nannyToUpdate.endHour = new DateTime[6];
            nannyToUpdate.daysWorkNanny = new bool[6];
            updateNannyDeatails.DataContext = nannyToUpdate;
            bl = BL.FactoryBL.GetBL();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            nannyToUpdate = bl.getNanny(Convert.ToInt64(nannyIdTextBox.Text));

            lastNameNannyTextBox.Text = nannyToUpdate.lastNameNanny;
            firstNameNannyTextBox.Text = nannyToUpdate.firstNameNanny;
            dateNannyDatePicker.DataContext = nannyToUpdate.dateNanny;
            phoneNannyTextBox.Text = Convert.ToString(nannyToUpdate.phoneNanny);
            addressNannyTextBox.Text = nannyToUpdate.addressNanny;
            elevatorNannyCheckBox.IsChecked = nannyToUpdate.elevatorNanny;
            floorNannyTextBox.Text = Convert.ToString(nannyToUpdate.floorNanny);
            experienceNannyTextBox.Text = Convert.ToString(nannyToUpdate.experienceNanny);
            maxChildNannyTextBox.Text = Convert.ToString(nannyToUpdate.maxChildNanny);
            minAgeChildNannyTextBox.Text = Convert.ToString(nannyToUpdate.minAgeChildNanny);
            maxAgeChildNannyTextBox.Text = Convert.ToString(nannyToUpdate.maxAgeChildNanny);
            isByHourNannyCheckBox.IsChecked = nannyToUpdate.isByHourNanny;
            rateHourNannyTextBox.Text = Convert.ToString(nannyToUpdate.rateHourNanny);
            rateMonthNannyTextBox.Text = Convert.ToString(nannyToUpdate.rateMonthNanny);
            isTamatNannyCheckBox.IsChecked = nannyToUpdate.isTamatNanny;
            recommendationsNannyTextBox.Text = nannyToUpdate.recommendationsNanny;
    }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {

                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    nannyToUpdate.startHour[0] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {

                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    nannyToUpdate.startHour[1] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {

                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    nannyToUpdate.startHour[2] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {

                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    nannyToUpdate.startHour[3] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {

                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    nannyToUpdate.startHour[4] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {

                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    nannyToUpdate.startHour[5] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[5] = Convert.ToDateTime(end);
                }

                bl.addNanny(nannyToUpdate);
                nannyToUpdate = new BE.Nanny();
                this.DataContext = nannyToUpdate;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
