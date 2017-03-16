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

        public void compareTime(UserAlarm userAl, String timeStr)
        {
            if (DateTime.Now.ToString("h:mm tt") == timeStr)
            {
                AlarmEventArgs args = new AlarmEventArgs();
                args.currAl = userAl;
                OnAlarmRings(args);
            }
        }
    }
}
