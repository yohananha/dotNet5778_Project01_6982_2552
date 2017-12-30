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
            this.DataContext = nannyToAdd;
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nannyToAdd.ScheduleNanny = new BE.Schedule[6];
                
                nannyToAdd.ScheduleNanny[0].startHour = DateTime.ParseExact("0001-01-01" + SunStart.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                 System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[0].endHour = DateTime.ParseExact("0001-01-01" + SunEnd.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[1].startHour = DateTime.ParseExact("0001-01-01" + MonStart.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[1].endHour = DateTime.ParseExact("0001-01-01" + MonEnd.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[2].startHour = DateTime.ParseExact("0001-01-01" + TueStart.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[2].endHour = DateTime.ParseExact("0001-01-01" + TueEnd.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[3].startHour = DateTime.ParseExact("0001-01-01" + WedStart.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[3].endHour = DateTime.ParseExact("0001-01-01" + WedEnd.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[4].startHour = DateTime.ParseExact("0001-01-01" + ThrStart.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[4].endHour = DateTime.ParseExact("0001-01-01" + ThuEnd.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[5].startHour = DateTime.ParseExact("0001-01-01" + FriStart.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                nannyToAdd.ScheduleNanny[5].endHour = DateTime.ParseExact("0001-01-01" + FriEnd.Text + ",000", "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);

                bl.addNanny(nannyToAdd);
                nannyToAdd = new BE.Nanny();
                this.DataContext = nannyToAdd;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
