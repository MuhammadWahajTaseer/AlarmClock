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

namespace Alarm_Clock
{
    /// <summary>
    /// Interaction logic for UserAlarm.xaml
    /// </summary>
    public partial class UserAlarm : UserControl
    {
        private int id;
        public UserAlarm(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void alarm_button_Click(object sender, RoutedEventArgs e)
        {
            

           
        }

    }
}
