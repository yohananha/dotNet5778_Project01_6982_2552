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
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for AddMotherWindow.xaml
    /// </summary>
    public partial class AddMotherWindow : Window
    {
        public BE.Mother momToAdd;
        public BL.Ibl bl;

        public AddMotherWindow()
        {
            InitializeComponent();
            momToAdd = new BE.Mother();
            momToAdd.startHour = new DateTime[6];
            momToAdd.endHour = new DateTime[6];
            momToAdd.DaysRequestMom = new bool[6];
            AddMomGrid.DataContext = momToAdd;
            bl = BL.FactoryBL.GetBL();
        }
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //    momToAdd.FirstNameMom = this.firstNameMomTextBox.Text;
                //    momToAdd.LasNameMom = this.lasNameMomTextBox.Text;
                //    momToAdd.IdMom = int.Parse(this.idMomTextBox.Text);
                //    momToAdd.PhoneMom = int.Parse(this.phoneMomTextBox.Text);
                //    momToAdd.AddressMom = this.addressMomTextBox.Text;
                //    momToAdd.AddressForNanny = this.addressForNannyTextBox.Text;

                //momToAdd.DaysRequestMom[0] = (bool)SunCheck.IsChecked;
                //momToAdd.DaysRequestMom[1] = (bool)MonCheck.IsChecked;
                //momToAdd.DaysRequestMom[2] = (bool)TueCheck.IsChecked;
                //momToAdd.DaysRequestMom[3] = (bool)WedCheck.IsChecked;
                //momToAdd.DaysRequestMom[4] = (bool)ThuCheck.IsChecked;
                //momToAdd.DaysRequestMom[5] = (bool)FriCheck.IsChecked;



                if ((bool)(SunCheck.IsChecked == true))
                {

                    var start = SunStart.Value;
                    var end = SunEnd.Value;
                    momToAdd.startHour[0] = Convert.ToDateTime(start);
                    momToAdd.endHour[0] = Convert.ToDateTime(end);
                }
                if ((bool)(MonCheck.IsChecked == true))
                {

                    var start = MonStart.Value;
                    var end = MonEnd.Value;
                    momToAdd.startHour[1] = Convert.ToDateTime(start);
                    momToAdd.endHour[1] = Convert.ToDateTime(end);
                }
                if ((bool)(TueCheck.IsChecked == true))
                {

                    var start = TueStart.Value;
                    var end = TueEnd.Value;
                    momToAdd.startHour[2] = Convert.ToDateTime(start);
                    momToAdd.endHour[2] = Convert.ToDateTime(end);
                }
                if ((bool)(WedCheck.IsChecked == true))
                {

                    var start = WedStart.Value;
                    var end = WedEnd.Value;
                    momToAdd.startHour[3] = Convert.ToDateTime(start);
                    momToAdd.endHour[3] = Convert.ToDateTime(end);
                }
                if ((bool)(ThuCheck.IsChecked == true))
                {

                    var start = ThuStart.Value;
                    var end = ThuEnd.Value;
                    momToAdd.startHour[4] = Convert.ToDateTime(start);
                    momToAdd.endHour[4] = Convert.ToDateTime(end);
                }
                if ((bool)(FriCheck.IsChecked == true))
                {

                    var start = FriStart.Value;
                    var end = FriEnd.Value;
                    momToAdd.startHour[5] = Convert.ToDateTime(start);
                    momToAdd.endHour[5] = Convert.ToDateTime(end);
                }


                bl.addMom(momToAdd);
                momToAdd = new BE.Mother();
                AddMomGrid.DataContext = momToAdd;
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

    }
}
