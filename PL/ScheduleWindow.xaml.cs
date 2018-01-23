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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;

namespace PL
{
    /// <summary>
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : UserControl
    {
        public bool tmpCheck;
       // public Schedule tmpSched;
        public ScheduleWindow()
        {
            InitializeComponent();
            bool [] tmpCheck = new bool[6];
     //       Schedule[] tmpSched = new Schedule[6];
        }



    }
}
