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
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        public BE.Mother momToUpdate;
        public BL.Ibl bl;

        public UpdateMotherWindow()
        {
            InitializeComponent();
            momToUpdate = new BE.Mother();
            momToUpdate.startHour = new DateTime[6];
            momToUpdate.endHour = new DateTime[6];
            momToUpdate.DaysRequestMom = new bool[6];
            updateMomDeatails.DataContext = momToUpdate;
            bl = BL.FactoryBL.GetBL();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            momToUpdate = bl.getMother(Convert.ToInt64(idMomTextBox.Text));
            
        }
    }
}
