using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        public BE.Mother mom;
        public BL.Ibl bl;

        public UpdateMotherWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            mom = new BE.Mother();
            mom.startHour = new DateTime[6];
            mom.endHour = new DateTime[6];
            mom.DaysRequestMom = new bool[6];
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //mom.IdMom = Convert.ToInt64(idMomTextBox.Text);
                mom = bl.getMother(Convert.ToInt64(idMomTextBox.Text));


                firstNameMomTextBox.Text = mom.FirstNameMom;
                lasNameMomTextBox.Text = mom.LasNameMom;
                addressForNannyTextBox.Text = mom.AddressForNanny;
                addressMomTextBox.Text = mom.AddressMom;
                phoneMomTextBox.Text = mom.PhoneMom;

                if (mom.DaysRequestMom[0] == true)
                {
                    SunCheck.IsChecked = true;
                    SunStart.Value = mom.startHour[0].ToLocalTime();
                    SunEnd.Value = mom.endHour[0].ToLocalTime();
                }
                if (mom.DaysRequestMom[1] == true)
                {
                    MonCheck.IsChecked = true;
                    MonStart.Value = mom.startHour[1].ToLocalTime();
                    MonEnd.Value = mom.endHour[1].ToLocalTime();
                }
                if (mom.DaysRequestMom[2] == true)
                {
                    TueCheck.IsChecked = true;
                    TueStart.Value = mom.startHour[2].ToLocalTime();
                    TueEnd.Value = mom.endHour[2].ToLocalTime();
                }
                if (mom.DaysRequestMom[3] == true)
                {
                    WedCheck.IsChecked = true;
                    WedStart.Value = mom.startHour[3].ToLocalTime();
                    WedEnd.Value = mom.endHour[3].ToLocalTime();
                }
                if (mom.DaysRequestMom[4] == true)
                {
                    ThuCheck.IsChecked = true;
                    ThuStart.Value = mom.startHour[4].ToLocalTime();
                    ThuEnd.Value = mom.endHour[4].ToLocalTime();
                }
                if (mom.DaysRequestMom[5] == true)
                {
                    FriCheck.IsChecked = true;
                    FriStart.Value = mom.startHour[5].ToLocalTime();
                    FriEnd.Value = mom.endHour[5].ToLocalTime();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("check your input and try again");
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //mom.IdMom = Convert.ToInt64(idMomTextBox.Text);
                mom = bl.getMother(Convert.ToInt64(idMomTextBox.Text));


                mom.FirstNameMom = firstNameMomTextBox.Text;
                mom.LasNameMom = lasNameMomTextBox.Text;
                mom.AddressForNanny = addressForNannyTextBox.Text;
                mom.AddressMom = addressMomTextBox.Text;
                mom.PhoneMom = phoneMomTextBox.Text;

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
                MessageBox.Show("פרטי האם עודכנו");
                this.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show("check your input and try again");
            }
        }
    }
}
