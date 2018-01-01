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
    /// Interaction logic for Mother.xaml
    /// </summary>
    public partial class Mother : Window
    {
        public Mother()
        {
            InitializeComponent();
        }

        private void AddMother_Click(object sender, RoutedEventArgs e)
        {
            AddMotherWindow addMom = new AddMotherWindow();
            addMom.Show();
        }

        private void DelMother_Click(object sender, RoutedEventArgs e)
        {
            DeleteMotherWindow delMom = new DeleteMotherWindow();
            delMom.Show();
        }

        private void addChild_Click(object sender, RoutedEventArgs e)
        {
            addChildWindow addChild = new addChildWindow();
            addChild.Show();
        }

        private void deleteChild_Click(object sender, RoutedEventArgs e)
        {
            deleteChildWindow delChild = new deleteChildWindow();
            delChild.Show();
        }

        private void UpdateMother_Click(object sender, RoutedEventArgs e)
        {
            UpdateMotherWindow upMom = new UpdateMotherWindow();
            upMom.Show();
        }

        

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            upChild upchild = new upChild();
            upchild.Show();
        }
    }
}
