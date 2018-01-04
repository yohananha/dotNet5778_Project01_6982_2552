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
using BL;
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for updateContractWindow.xaml
    /// </summary>
    public partial class updateContractWindow : Window
    {
        public BL.Ibl bl;
        public BE.Mother mom;
        public BE.Contract contract;
        public BE.Child child;

        public updateContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            this.DataContext = contract;
            bl = BL.FactoryBL.GetBL();
        }

        private void buttonSearchContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            contract = bl.getContract(Convert.ToInt32(idChildTextBox.Text));
            this.DataContext = contract;
            mom = bl.getMother(bl.getChild(Convert.ToInt64(idChildTextBox.Text)).idMom);
            if (mom.DaysRequestMom[0] == true)
            {
                SunCheck.IsChecked = true;
                SunStart.Value = mom.startHour[0].ToUniversalTime();
                SunEnd.Value = mom.endHour[0].ToUniversalTime();
            }
            if (mom.DaysRequestMom[1] == true)
            {
                MonCheck.IsChecked = true;
                MonStart.Value = mom.startHour[1].ToUniversalTime();
                MonEnd.Value = mom.endHour[1].ToUniversalTime();
            }
            if (mom.DaysRequestMom[2] == true)
            {
                TueCheck.IsChecked = true;
                TueStart.Value = mom.startHour[2].ToUniversalTime();
                TueEnd.Value = mom.endHour[2].ToUniversalTime();
            }
            if (mom.DaysRequestMom[3] == true)
            {
                WedCheck.IsChecked = true;
                WedStart.Value = mom.startHour[3].ToUniversalTime();
                WedEnd.Value = mom.endHour[3].ToUniversalTime();
            }
            if (mom.DaysRequestMom[4] == true)
            {
                ThuCheck.IsChecked = true;
                ThuStart.Value = mom.startHour[4].ToUniversalTime();
                ThuEnd.Value = mom.endHour[4].ToUniversalTime();
            }
            if (mom.DaysRequestMom[5] == true)
            {
                FriCheck.IsChecked = true;
                FriStart.Value = mom.startHour[5].ToUniversalTime();
                FriEnd.Value = mom.endHour[5].ToUniversalTime();
            }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)(SunCheck.IsChecked == true))
                {
                    mom.DaysRequestMom[0] = true;
                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    mom.startHour[0] = Convert.ToDateTime(start);
                    mom.endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {
                    mom.DaysRequestMom[1] = true;
                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    mom.startHour[1] = Convert.ToDateTime(start);
                    mom.endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {
                    mom.DaysRequestMom[2] = true;
                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    mom.startHour[2] = Convert.ToDateTime(start);
                    mom.endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {
                    mom.DaysRequestMom[3] = true;
                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    mom.startHour[3] = Convert.ToDateTime(start);
                    mom.endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {
                    mom.DaysRequestMom[4] = true;
                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    mom.startHour[4] = Convert.ToDateTime(start);
                    mom.endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {
                    mom.DaysRequestMom[5] = true;
                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    mom.startHour[5] = Convert.ToDateTime(start);
                    mom.endHour[5] = Convert.ToDateTime(end);
                }
                bl.updateMother(mom);

                if (!bl.checkSchedule(bl.getNanny(Convert.ToInt64(idNannyTextBox.Text)), mom))
                    throw new Exception("המטפלת לא עובדת בשעות הנדרשות");

                if (isHourCheckBox.IsChecked == true)
                    salaryPerHourTextBox.Text = Convert.ToString(bl.getSalary(Convert.ToInt32(idChildTextBox.Text), Convert.ToInt64(idNannyTextBox.Text), true));
                salaryPerMonthTextBox.Text = Convert.ToString(bl.getSalary(Convert.ToInt32(idChildTextBox.Text), Convert.ToInt64(idNannyTextBox.Text), false));

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateContract(contract);
                MessageBox.Show("חוזה עודכן בהצלחה");
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
