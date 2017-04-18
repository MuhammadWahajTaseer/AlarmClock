using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm_Clock
{
    class AlarmRing
    {
        public event EventHandler<AlarmEventArgs> AlarmRings;

        protected virtual void OnAlarmRings(AlarmEventArgs e)
        {
            EventHandler<AlarmEventArgs> handler = AlarmRings;
            if(handler != null)
            {
                handler(this, e);
            }

        }

        public void compareTime(UserAlarm userAl, String timeStr, DateTime currDate)
        {
            if (currDate.ToString("h:mm tt") == timeStr && this.getDays(userAl, currDate))
            {
                AlarmEventArgs args = new AlarmEventArgs();
                args.currAl = userAl;
                OnAlarmRings(args);
            }
        }
        public bool getDays(UserAlarm userAl, DateTime currDate)
        {
            bool[] currDays = userAl.getAlarm().getDays();
            return currDays[(int)currDate.DayOfWeek];
        }
    }
}
