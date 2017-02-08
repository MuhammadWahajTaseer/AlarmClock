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
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            AlarmEventArgs e = new AlarmEventArgs();
            OnAlarm(e);

            this.KeyUp += MainWindow_KeyUp;
        }

        
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            } 
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            digitalTime.Content = DateTime.Now.ToString("hh:mm:ss");
            amORpm.Content = DateTime.Now.ToString("tt");
            date.Content = DateTime.Now.ToString("MMM dd, yyyy");
        }

       

        protected virtual void OnAlarm(AlarmEventArgs e)
        {
            if (Alarm != null)
                Alarm(this, e);
        }
    }
}
