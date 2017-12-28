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
            momToAdd.DaysRequestMom = new bool[6];
            momToAdd.ScheduleMom = new Schedule[6];
            this.AddMomGrid.DataContext = momToAdd;
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

                momToAdd.DaysRequestMom[0] = (bool)SunCheck.IsChecked;
                momToAdd.DaysRequestMom[1] = (bool)MonCheck.IsChecked;
                momToAdd.DaysRequestMom[2] = (bool)TueCheck.IsChecked;
                momToAdd.DaysRequestMom[3] = (bool)WedCheck.IsChecked;
                momToAdd.DaysRequestMom[4] = (bool)ThuCheck.IsChecked;
                momToAdd.DaysRequestMom[5] = (bool)FriCheck.IsChecked;

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
