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

        private Alarm al;
        public UserAlarm(int id, Alarm alarm)
        {
            InitializeComponent();
            this.id = id;
            al = alarm;

        }

        public void setAlarm(Alarm alarm)
        {
            this.al = alarm;
        }

        public Alarm getAlarm()
        {
            return al;
        }

        private void alarm_button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.slideMenu.Visibility = Visibility.Visible;

            win.setAlarm_save.Visibility = Visibility.Hidden;
            win.editAlarm_save.Visibility = Visibility.Visible;

            win.setCurrentAlarm(this);
            // Finding the position of the alarm in the alarms linked list
               
           win.setAlarm_hours.Content = al.getHour();
                    
           // Loads previous alarm values
           int getmin = al.getMin();
           if (getmin < 10)
           {
                win.setAlarm_minutes.Content = "0" + al.getMin();
           }
           else
           {
                win.setAlarm_minutes.Content = al.getMin();
           }


           if (al.getAMPM() == 0)
           {
                win.setAlarm_amORpm.Content = " AM";
           }
           else
           {
               win.setAlarm_amORpm.Content = " PM";
           }

                    //  set changed alarm values for the alrm in alarms linked list


               // }
       }

                
          

        }

    }

