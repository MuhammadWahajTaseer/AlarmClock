using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm_Clock
{
    public class Alarm
    {
        private int id;
        private int hour;
        private int minute;
        private int ampm;
        public bool dismissed;
        private bool repeating;

        //variables for snooze
        private bool snooze = false;
        private int rang = 0;

        // Arrray for which days to ring, STARTS ON SUNDAY
        private bool[] days = { false, false, false, false, false, false, false };

        // path for the ringer sound file
        private String ringerPath = null;

        // Linnking to user conrol (user alarm)
        private UserAlarm  userAlarm =  null;


        // Constructor initializes the time
        public Alarm(int hour, int minute, int ampm, bool repeating)
        {
            this.hour = hour;
            this.minute = minute;
            this.ampm = ampm;


        }

        // Constructor that initializes the time as well as days 
        public Alarm(int hour, int minute, int ampm, bool repeating, bool[] days)
        {
            this.hour = hour;
            this.minute = minute;
            this.ampm = ampm;

            this.repeating = repeating;
            this.days = days;
        }


        // Constructor that initializes the time as well as days 
        public Alarm(int hour, int minute, int ampm, bool repeating, bool[] days, String ringerPath)
        {
            this.hour = hour;
            this.minute = minute;
            this.ampm = ampm;

            this.repeating = repeating;
            this.days = days;
            this.ringerPath = ringerPath;
        }

        // Getters
        public int getRang()
        {
            return this.rang;
        }
        public bool getSnooze()
        {
            return this.snooze;
        }
        public int getID()
        {
            return id;
        }

        public int getHour()
        {
            return hour;
        }

        public int getMin()
        {
            return minute;
        }

        public int getAMPM()
        {
            return ampm;
        }

        public bool getRepeating()
        {
            return repeating;
        }

        public bool[] getDays()
        {
            return days;
        }

        public String getRingerPath()
        {
            return ringerPath;
        }

        public UserAlarm getUAlarm()
        {
            return userAlarm;
        }

        public String getString()
        {

            String tempMin = minute.ToString();
            if (minute < 10)
            {
                tempMin = "0" + tempMin;
            }
           
            String temp = this.getHour() + ":" + tempMin;
               
            if (this.getAMPM() == 0)
            {
                temp += " AM";
            }
            else
            {
                temp += " PM";
            }
            return temp;
        }

        // Setters
        public void setSnooze(bool snooze)
        {
            this.snooze = snooze;
        }
        public void setUserAlarm(UserAlarm userAlarm)
        {
            this.userAlarm = userAlarm;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public void setHour(int hour)
        {
            this.hour = hour;
        }

        public void setMin(int mins)
        {
            this.minute = mins;
        }
        public void setAMPM(int amopm)
        {
            this.ampm = amopm;
        }
        //....................
        public void setRingerPath(String path)
        {
            ringerPath = path;
        }
        
    }
}
