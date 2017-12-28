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
    /// Interaction logic for DeleteMotherWindow.xaml
    /// </summary>
    public partial class DeleteMotherWindow : Window
    {
        public BE.Mother MomToDel;
        public BL.Ibl bl;

        public DeleteMotherWindow()
        {
            InitializeComponent();
            MomToDel = new BE.Mother();
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
            long tmpID = Convert.ToInt64(idMomTextBox.Text);
            bl.deleteMother(tmpID);
        }
    }
}
