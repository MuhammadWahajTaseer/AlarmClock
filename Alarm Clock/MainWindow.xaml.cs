using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Threading;

namespace Alarm_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);
        public event AlarmEventHandler Alarm;
        //these are the objects of the min, hour, and second hand
        private RotateTransform MinHandTr = new RotateTransform();
        private RotateTransform HourHandTr = new RotateTransform();
        private RotateTransform SecHandTr = new RotateTransform();

        public MainWindow()
        {
            //initalizes the clock  
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            AlarmEventArgs e = new AlarmEventArgs();
            OnAlarm(e);

            this.KeyUp += MainWindow_KeyUp;
        }

        /* this method is an event driven system for analog and digital clock
         * event is called every "tick" which is one second
         * it also updates the clocks each second
         */
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            /* digital clock
             * displays the time, date and am
             */ 
            digitalTime.Content = DateTime.Now.ToString("hh:mm:ss"); //hours:minutes: seconds   
            amORpm.Content = DateTime.Now.ToString("tt"); //AM or PM 
            date.Content = DateTime.Now.ToString("MMM dd, yyyy"); //month day, year 



            //analog clock
            //calculates angles for the minute, hour and second hand 
            MinHandTr.Angle = (DateTime.Now.Minute * 6); 
            HourHandTr.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5); 
            SecHandTr.Angle = (DateTime.Now.Second * 6); 

            //moves the minute, second and hour hand  
            MinuteHand.RenderTransform = MinHandTr; 
            HourHand.RenderTransform = HourHandTr;
            SecondHand.RenderTransform = SecHandTr;
        }

       

        protected virtual void OnAlarm(AlarmEventArgs e)
        {
            if (Alarm != null)
                Alarm(this, e);
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            if (slideMenu.IsVisible)
            {
                slideMenu.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                slideMenu.Visibility = System.Windows.Visibility.Visible;
            }
        }
        /* This method closes the program down if the escape key is hit
         */ 
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Application.Current.Shutdown();

            }
            
        }

    }
}
