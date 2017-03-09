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
using System.Windows.Media.Animation;


namespace Alarm_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        
        
        //these are the objects of the min, hour, and second hand for the analog clock
        private RotateTransform MinHandTr = new RotateTransform();
        private RotateTransform HourHandTr = new RotateTransform();
        private RotateTransform SecHandTr = new RotateTransform();

        private UserAlarm currAlarm;

        private int createAlarmHour = 12; 
        private int createAlarmMin = 0;
        private int createAlarmAMPM = 0;

        private System.Media.SoundPlayer player;
        private bool alarmState;

        public LinkedList<Alarm> alarms = new LinkedList<Alarm>();
        public LinkedList<UserAlarm> uAlarms = new LinkedList<UserAlarm>();

        AlarmRing ring = new AlarmRing();

        public MainWindow()
        {
            //initalizes the clock  
            InitializeComponent();
            alarmState = false;
           

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            dispatcherTimer.Interval = new TimeSpan(0, 0,1);
            dispatcherTimer.Start();

            ring.AlarmRings += Ring_AlarmRings;

            this.KeyUp += MainWindow_KeyUp;

        }

        private void Ring_AlarmRings(object sender, AlarmEventArgs e)
        {
            if (e.currAl.dismissed == false) {
                e.currAl.dismissed = true;
                player = new System.Media.SoundPlayer(e.currAl.getRingerPath());
                player.Load();
                player.Play();
                this.alertCanvas1.Visibility = Visibility.Visible;
                this.alertCanvas2.Visibility = Visibility.Visible;
            }
        }

       

        /* this method is an event driven system for analog and digital clock
         * event is called every "tick" which is one second
         * it also updates the clocks each second
         */
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var myDate = DateTime.Now;

                /* digital clock
                 * displays the time, date and am
                 */
                digitalTime.Content = myDate.ToString("hh:mm:ss"); //hours:minutes: seconds   
                amORpm.Content = myDate.ToString("tt"); //AM or PM 
                date.Content = myDate.ToString("MMM dd, yyyy"); //month day, year 


                //analog clock
                //calculates angles for the minute, hour and second hand 
                MinHandTr.Angle = (myDate.Minute * 6);
                HourHandTr.Angle = (myDate.Hour * 30) + (myDate.Minute * 0.5);
                SecHandTr.Angle = (myDate.Second * 6);

            //moves the minute, second and hour hand  
            MinuteHand.RenderTransform = MinHandTr; 
            HourHand.RenderTransform = HourHandTr;
            SecondHand.RenderTransform = SecHandTr;


           alarmCheck(ring);
        }

        // Animates the slide menu. Will be buddy for sliding in because i didn't test dat.
        public static void moveSlideMenu(Canvas slideMenu)
        {
            TranslateTransform trans = new TranslateTransform();
            slideMenu.RenderTransform = trans;
            DoubleAnimation anim = null;

            if (slideMenu.IsVisible)
            {
                anim = new DoubleAnimation(600, 0, TimeSpan.FromSeconds(0.5));
            }
            else
            {
               anim = new DoubleAnimation(0, 600, TimeSpan.FromSeconds(0.5));
            }

            trans.BeginAnimation(TranslateTransform.XProperty, anim);
        }


 

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            editAlarm_save.Visibility = Visibility.Hidden;
            setAlarm_save.Visibility = Visibility.Visible;
            if (slideMenu.IsVisible)
            {
                //hide the slideMenu
                slideMenu.Visibility = System.Windows.Visibility.Hidden;
                //update the button to open/close the window
                plusButton.Content = " + ";

                //reset the create alarm to inital values
                createAlarmAMPM = 0;
                createAlarmHour = 12;
                createAlarmMin = 0;
                //update the visuals for the reset values
                setAlarm_minutes.Content = "0" + "0";
                setAlarm_hours.Content = 12;
                setAlarm_amORpm.Content = "AM";

            }
            else
            {
                slideMenu.Visibility = System.Windows.Visibility.Visible;
                moveSlideMenu(slideMenu);
                //update the button to open/close the window
                plusButton.Content = " - ";
            }
        }
       
        /* This method closes the program down if the escape key is hit
         */
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }

        }


        //**When creating a new alarm** - decriment of the mins button  
        private void setAlarm_decMinutes_Click(object sender, RoutedEventArgs e)
        {

            //if there are 0 mins in the label clicking up will change it to 59 mins
            if (createAlarmMin == 0)
            {
                createAlarmMin = 59;
                setAlarm_minutes.Content = createAlarmMin.ToString();
            }
            //if the minutes are inbetween or equal to 0 and 9 then add an extra "0" to format it 
            else if (createAlarmMin >= 0 && createAlarmMin < 11)
            {
                createAlarmMin -= 1;
                setAlarm_minutes.Content = "0" + createAlarmMin.ToString();

            }
            //otherwise just update the current minutes and update the label 
            else
            {
                createAlarmMin -= 1;
                setAlarm_minutes.Content = createAlarmMin.ToString();

            }

        }


        //**When creating a new alarm** - increment of the the mins button
        private void setAlarm_incMinutes_Click(object sender, RoutedEventArgs e)
        {

            //if there are 59 mins in the label clicking up will change it to 00 mins
            if (createAlarmMin == 59)
            {
                createAlarmMin = 0;
                setAlarm_minutes.Content = "0" + createAlarmMin.ToString();
            }
            //if the minutes are inbetween or equal to 0 and 9 then add an extra "0" to format it 
            else if (createAlarmMin >= 0 && createAlarmMin < 9)
            {
                createAlarmMin += 1;
                setAlarm_minutes.Content = "0" + createAlarmMin.ToString();

            }
            //otherwise just update the current minutes and update the label 
            else
            {
                createAlarmMin += 1;
                setAlarm_minutes.Content = createAlarmMin.ToString();

            }
        }


        //**When creating a new alarm** - decriment of the the hours button 
        private void setAlarm_decHours_Click(object sender, RoutedEventArgs e)
        {
            //if there are 0 hours in the label clicking down will change it to 12 mins
            if (createAlarmHour == 0 || createAlarmHour == 1)
            {
                createAlarmHour = 12;
                setAlarm_hours.Content = createAlarmHour.ToString();
            }
            /*
            //if the hours are inbetween or equal to 0 and 9 then add an extra "0" to format it
            */
            //otherwise just update the current hours and update the label 
            else
            {
                createAlarmHour -= 1;
                setAlarm_hours.Content = createAlarmHour.ToString();

            }
        }

        //**When creating a new alarm** - increment of the hours button
        private void setAlarm_incHours_Click_1(object sender, RoutedEventArgs e)
        {

            //if there are 12 hours in the label clicking up will change it to 00 mins
            if (createAlarmHour == 12)
            {
                createAlarmHour = 1;

                //setAlarm_hours.Content = "0" + createAlarmHour.ToString();
                setAlarm_hours.Content = createAlarmHour.ToString();
            }
          
            //if the hours are inbetween or equal to 0 and 9 then add an extra "0" to format it 
       
            else
            {
                createAlarmHour += 1;
                setAlarm_hours.Content = createAlarmHour.ToString();

            }

        }

        //**When creating a new alarm** - changing from "am -> pm" or "pm -> am"
        private void setAlarm_amORpm_Click(object sender, RoutedEventArgs e)
        {
            //if the button is on AM it will change to PM
            if (createAlarmAMPM == 0)
            {
                createAlarmAMPM = 1;
                setAlarm_amORpm.Content = "PM";
            }

            //otherwise the button is on PM and it will change to AM
            else
            {
                createAlarmAMPM = 0;
                setAlarm_amORpm.Content = "AM";
            }

        }

        public void setAlarm_save_Click(object sender, RoutedEventArgs e)
        {
            // ** Need to also check if it's repeating and send the last bool acordingly

            Alarm myAlarm = new Alarm(createAlarmHour, createAlarmMin, createAlarmAMPM, false);
            myAlarm.setID(alarms.Count+1);
            myAlarm.dismissed = false;

            //*listBox.FontSize = 60;

            //Getting the String and putting it in the linked lisst
            String temp = myAlarm.getString();
            alarms.AddLast(myAlarm);

            // Creating new User Alarm and adding it to linked list
            UserAlarm userAlarm = new UserAlarm(alarms.Count + 1, myAlarm);
            userAlarm.getAlarm().setRingerPath(@"C:\Users\jgelay\Source\Repos\AlarmClock\Alarm Clock\Ringtones\Default.wav");
            userAlarm.alarm_button.Content = temp;
      
            uAlarms.AddLast(userAlarm);

            // Updating Stack Panel
            stacky.Children.Add(userAlarm);

            // Linking the user alarm to the alarm object
            myAlarm.setUserAlarm(userAlarm);
            userAlarm.setAlarm(myAlarm);
            
            slideMenu.Visibility = System.Windows.Visibility.Hidden; 
            
        }

        private void setAlarm_delete_Click(object sender, RoutedEventArgs e)
        {
            if (alarms.Count != 0)
            {

            }
        }

        
        private void alarmCheck(AlarmRing ring)
        {
            // Getting the alarm itme in "hh:mm" format
           if (uAlarms.Last != null) {
              foreach(UserAlarm uAlarm in uAlarms)
                {
                    String ampm = null;
                    String min = null;
                    ampm = (uAlarm.getAlarm().getAMPM() == 1 ?  "PM" : "PM");
                    if (uAlarm.getAlarm().getMin().ToString().Length == 1) {
                        min = "0" + uAlarm.getAlarm().getMin().ToString();
                    }
                    else
                    {
                        min = uAlarm.getAlarm().getMin().ToString();
                    }
                    String checker = uAlarm.getAlarm().getHour().ToString() + ":" + min + " " + ampm;
                    ring.compareTime(uAlarm.getAlarm(), checker);
                 
                        

                }
            }

        }

        private void alarm_change(object sender, MouseButtonEventArgs e) {
            if (alarms.Count == 0)
            {
                return;
            }
            Alarm edited = alarms.Last();
            
            slideMenu.Visibility = Visibility.Visible;
            setAlarm_hours.Content = edited.getHour();

            int getmin = edited.getMin();
            if(getmin < 10)
            {
                setAlarm_minutes.Content = "0" + edited.getMin();
            }else {
                setAlarm_minutes.Content = edited.getMin();
            }


            if (edited.getAMPM() == 0)
            {
                setAlarm_amORpm.Content = " AM";
            }else {
                setAlarm_amORpm.Content = " PM";
            }

            createAlarmHour = edited.getHour();

            createAlarmMin = edited.getMin();
            if (edited.getAMPM() == 0)
            {
                setAlarm_amORpm.Content = " AM";
            } else
            {
                setAlarm_amORpm.Content = " PM";
            }


        }

        public void setCurrentAlarm(UserAlarm al)
        {
            currAlarm = al;
        }

        private void editAlarm_save_Click(object sender, RoutedEventArgs e)
        {
            foreach (Alarm ala in alarms)
            {
                if(ala.getID() == currAlarm.getAlarm().getID())
                {
                    currAlarm.getAlarm().setHour(createAlarmHour);
                    currAlarm.getAlarm().setMin(createAlarmMin);
                    currAlarm.getAlarm().setAMPM(createAlarmAMPM);

                    ala.setHour(createAlarmHour);
                    ala.setMin(createAlarmMin);
                    ala.setAMPM(createAlarmAMPM);
                    
                    currAlarm.alarm_button.Content = ala.getString();

                    //currAlarm.alarm_button.Content = currAlarm.getAlarm().getString();
                    //currAlarm.alarm_button.Content = "meow";
                }
            }
            
            slideMenu.Visibility = System.Windows.Visibility.Hidden;
        }

        // Deleting the alarm
        private void dismiss_Click(object sender, RoutedEventArgs e)
        {
            this.alarmEventCanvas.Visibility = Visibility.Hidden;
        }
        public void setCurrentHour(int hour)
        {
            createAlarmHour = hour;
        }
        public void setCurrentMin(int min)
        {
            createAlarmMin = min;
        }
        public void setCurrentAMPM(int ampm)
        {
            createAlarmAMPM = ampm;
        }

        private void dismiss1_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            this.alertCanvas1.Visibility = Visibility.Hidden;
            this.alertCanvas2.Visibility = Visibility.Hidden;
        }
    }
}

