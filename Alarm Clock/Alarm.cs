using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm_Clock
{
    class Alarm
    {
        private int hour;
        private int minute;
        private int ampm;

        private bool repeating;

        // Arrray for which days to ring, STARTS ON SUNDAY
        private bool[] days = { false, false, false, false, false, false, false };

        // path for the ringer sound file
        private String ringerPath = null;


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

    }
}
