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
    /// Interaction logic for upChild.xaml
    /// </summary>
    public partial class upChild : Window
    {
        public BE.Child childToUpdate;
        public BL.Ibl bl;

        public upChild()
        {
            InitializeComponent();
            UpdateChild.DataContext = childToUpdate;
            bl = BL.FactoryBL.GetBL();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource childViewSource =
                ((System.Windows.Data.CollectionViewSource) (this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                childToUpdate = bl.getChild(Convert.ToInt64(idChildTextBox.Text));

                UpdateChild.DataContext = childToUpdate;

            }
            catch (Exception exception)
            {
                MessageBox.Show("Please check your input");
                throw;
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                childToUpdate = UpdateChild.DataContext as Child;
               bl.updateChild(childToUpdate);
                MessageBox.Show("פרטי ילד עודכנו בהצלחה");
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please check your input");
                throw;
            }

        }
    }
}
