using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Alarm_Clock
{
    [Serializable]
    public class Alarm : ISerializable
    {
        private int id;
        private int hour;
        private int minute;
        private int ampm;
        private int origHour;
        private int origMinute;
        private int origAmpm;
        public bool dismissed;
        private bool repeating;
        private String descript;

        //variables for snooze
        private bool snooze = false;
        private int rang = 0;

        // Arrray for which days to ring, STARTS ON SUNDAY
        // SUN MON TUES WED THURS SAT
        private bool[] days = { false, false, false, false, false, false, false };

        // path for the ringer sound file
        private String ringerPath = null;

        // Linnking to user conrol (user alarm)
        private UserAlarm  userAlarm =  null;


        // Constructor initializes the time
        protected Alarm(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new System.ArgumentNullException("info");
            this.id = (int)info.GetValue("AlarmID", typeof(int));
            this.hour = (int)info.GetValue("AlarmHour", typeof(int));
            this.minute = (int)info.GetValue("AlarmMin", typeof(int));
            this.ampm = (int)info.GetValue("AlarmAMPM", typeof(int));
            this.ringerPath = (string)info.GetValue("AlarmRingerPath", typeof(String));
            this.origHour = (int)info.GetValue("AlarmOriginalHour", typeof(int));
            this.origMinute = (int)info.GetValue("AlarmOriginalMin", typeof(int));
            this.origAmpm = (int)info.GetValue("AlarmOriginalAMPM", typeof(int));
            this.descript = (string)info.GetValue("AlarmDescription", typeof(string));
        }
        public Alarm(int hour, int minute, int ampm, bool repeating, string words,bool[]days)
        {
            this.hour = hour;
            this.minute = minute;
            this.ampm = ampm;
            this.origHour = hour;
            this.origMinute = minute;
            this.origAmpm = ampm;
            this.descript = words;
            this.days = days;

        }

        // Constructor that initializes the time as well as days 
        public Alarm(int hour, int minute, int ampm, bool repeating, bool[] days)
        {
            this.hour = hour;
            this.minute = minute;
            this.ampm = ampm;
            this.origHour = hour;
            this.origMinute = minute;
            this.origAmpm = ampm;

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
        public int getOrigHour()
        {
            return this.origHour;
        }
        public int getOrigMinute()
        {
            return this.origMinute;
        }
        public int getorigAmpm()
        {
            return this.origAmpm;
        }
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

        public String getName()
        {
            return descript;
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

        public string getDescription()
        {
            return this.descript;
        }
        public String getRingerPath()
        {
            return ringerPath;
        }

        public UserAlarm getUAlarm()
        {
            return userAlarm;
        }

        public void setName(String words)
        {
            this.descript = words;
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
        public void setOrigHour(int hour)
        {
             this.origHour = hour;
        }

        public void setDays(bool[] day)
        {
            this.days = day;
        }
        public void setOrigMinute(int mint)
        {
            this.origMinute = mint;
        }
        public void setorigAmpm(int ampm)
        {
            this.origAmpm  = ampm;
        }
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AlarmID", this.id);
            info.AddValue("AlarmHour", this.hour);
            info.AddValue("AlarmMin", this.minute);
            info.AddValue("AlarmAMPM", this.ampm);
            info.AddValue("AlarmRingerPath", this.ringerPath);
            info.AddValue("AlarmOriginalHour", this.origHour);
            info.AddValue("AlarmOriginalMin", this.origMinute);
            info.AddValue("AlarmOriginalAMPM", this.origAmpm);
            info.AddValue("AlarmDescription", this.descript);
        }
    }
}
