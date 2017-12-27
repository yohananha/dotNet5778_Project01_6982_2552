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
    }
}
