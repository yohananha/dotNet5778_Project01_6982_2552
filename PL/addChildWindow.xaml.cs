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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for addChildWindow.xaml
    /// </summary>
    public partial class addChildWindow : Window
    {
        public BE.Child childToAdd;
        public BL.Ibl bl;

        public addChildWindow()
        {
            InitializeComponent();
            childToAdd = new BE.Child();
            this.DataContext = childToAdd;
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addChild(childToAdd);
                childToAdd = new BE.Child();
                this.DataContext = childToAdd;
                MessageBox.Show("ילד נוסף בהצלחה");
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
