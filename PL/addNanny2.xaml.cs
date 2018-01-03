using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for addNanny2.xaml
    /// </summary>
    public partial class addNanny2 : Window
    {
        public BE.Nanny nannyToAdd;
        public BL.Ibl bl;


        public addNanny2()
        {
            InitializeComponent();
            nannyToAdd = new BE.Nanny();
            nannyToAdd.startHour = new DateTime[6];
            nannyToAdd.endHour = new DateTime[6];
            nannyToAdd.daysWorkNanny = new bool[6];
            this.DataContext = nannyToAdd;
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {
                    nannyToAdd.daysWorkNanny[0] = true;
                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    nannyToAdd.startHour[0] = Convert.ToDateTime(start);
                    nannyToAdd.endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {
                    nannyToAdd.daysWorkNanny[1] = true;
                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    nannyToAdd.startHour[1] = Convert.ToDateTime(start);
                    nannyToAdd.endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {
                    nannyToAdd.daysWorkNanny[2] = true;
                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    nannyToAdd.startHour[2] = Convert.ToDateTime(start);
                    nannyToAdd.endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {
                    nannyToAdd.daysWorkNanny[3] = true;
                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    nannyToAdd.startHour[3] = Convert.ToDateTime(start);
                    nannyToAdd.endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {
                    nannyToAdd.daysWorkNanny[4] = true;
                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    nannyToAdd.startHour[4] = Convert.ToDateTime(start);
                    nannyToAdd.endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {
                    nannyToAdd.daysWorkNanny[5] = true;
                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    nannyToAdd.startHour[5] = Convert.ToDateTime(start);
                    nannyToAdd.endHour[5] = Convert.ToDateTime(end);
                }

                bl.addNanny(nannyToAdd);
                nannyToAdd = new BE.Nanny();
                this.DataContext = nannyToAdd;
                MessageBox.Show("המטפלת הוספה בהצלחה");
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
