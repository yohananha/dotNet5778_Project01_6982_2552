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
            this.DataContext = nannyToUpdate;
            nannyToUpdate.startHour = new DateTime[6];
            nannyToUpdate.endHour = new DateTime[6];
            nannyToUpdate.daysWorkNanny = new bool[6];
            bl = BL.FactoryBL.GetBL();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                nannyToUpdate = bl.getNanny(Convert.ToInt64(nannyIdTextBox.Text));

                this.DataContext = nannyToUpdate;

                if (nannyToUpdate.daysWorkNanny[0] == true)
                {
                    SunCheck.IsChecked = true;
                    SunStart.Value = nannyToUpdate.startHour[0].ToLocalTime();
                    SunEnd.Value = nannyToUpdate.endHour[0].ToLocalTime();
                }
                if (nannyToUpdate.daysWorkNanny[1] == true)
                {
                    MonCheck.IsChecked = true;
                    MonStart.Value = nannyToUpdate.startHour[1].ToLocalTime();
                    MonEnd.Value = nannyToUpdate.endHour[1].ToLocalTime();
                }
                if (nannyToUpdate.daysWorkNanny[2] == true)
                {
                    TueCheck.IsChecked = true;
                    TueStart.Value = nannyToUpdate.startHour[2].ToLocalTime();
                    TueEnd.Value = nannyToUpdate.endHour[2].ToLocalTime();
                }
                if (nannyToUpdate.daysWorkNanny[3] == true)
                {
                    WedCheck.IsChecked = true;
                    WedStart.Value = nannyToUpdate.startHour[3].ToLocalTime();
                    WedEnd.Value = nannyToUpdate.endHour[3].ToLocalTime();
                }
                if (nannyToUpdate.daysWorkNanny[4] == true)
                {
                    ThuCheck.IsChecked = true;
                    ThuStart.Value = nannyToUpdate.startHour[4].ToLocalTime();
                    ThuEnd.Value = nannyToUpdate.endHour[4].ToLocalTime();
                }
                if (nannyToUpdate.daysWorkNanny[5] == true)
                {
                    FriCheck.IsChecked = true;
                    FriStart.Value = nannyToUpdate.startHour[5].ToLocalTime();
                    FriEnd.Value = nannyToUpdate.endHour[5].ToLocalTime();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {
                    nannyToUpdate.daysWorkNanny[0] = true;
                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    nannyToUpdate.startHour[0] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {
                    nannyToUpdate.daysWorkNanny[1] = true;
                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    nannyToUpdate.startHour[1] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {
                    nannyToUpdate.daysWorkNanny[2] = true;
                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    nannyToUpdate.startHour[2] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {
                    nannyToUpdate.daysWorkNanny[3] = true;
                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    nannyToUpdate.startHour[3] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {
                    nannyToUpdate.daysWorkNanny[4] = true;
                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    nannyToUpdate.startHour[4] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {
                    nannyToUpdate.daysWorkNanny[5] = true;
                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    nannyToUpdate.startHour[5] = Convert.ToDateTime(start);
                    nannyToUpdate.endHour[5] = Convert.ToDateTime(end);
                }

                bl.updateNanny(nannyToUpdate);
                nannyToUpdate = new BE.Nanny();
                this.DataContext = nannyToUpdate;
                MessageBox.Show("פרטי המטפלת עודכנו");
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
