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
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for DataSearchWindoe.xaml
    /// </summary>
    public partial class DataSearchWindoe : Window
    {
        public BL.Ibl bl;

        public IEnumerable<BE.Mother> momList;
        public IEnumerable<BE.Nanny> nannyList;
        public IEnumerable<BE.Child> childList;
        public IEnumerable<BE.Contract> contractList;

        public DataSearchWindoe()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
 

        private void NannyList_Click_1(object sender, RoutedEventArgs e)
        {
            nannyList = bl.getAllNanny();
            dataGrid.ItemsSource = nannyList;
        }

        private void Momlist_Click(object sender, RoutedEventArgs e)
        {
            momList = bl.getAllMothers();
            dataGrid.ItemsSource = momList;
        }

        private void MomsKids_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt64(idMomTextBox.Text) == 0)
                    throw new Exception();
                else
                {
                    childList = bl.getKids(a=>a.idMom == Convert.ToInt64(idMomTextBox.Text));
                    if (childList == null)
                        MessageBox.Show("לא נמצאו ילדים לאמא");
                    else dataGrid.ItemsSource = childList;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("נא הכנס תז של האם");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        private void AllContracts_Click(object sender, RoutedEventArgs e)
        {
            contractList = bl.getContracts();
            dataGrid.ItemsSource = contractList;
        }

        private void alltamat_Click(object sender, RoutedEventArgs e)
        {
            nannyList = bl.getTamatNanny();
            dataGrid.ItemsSource = nannyList;
        }

        private void allNoNannyKids_Click(object sender, RoutedEventArgs e)
        {
            childList = bl.getAllChildWithoutNanny();
            dataGrid.ItemsSource = childList;
        }
    }
}
