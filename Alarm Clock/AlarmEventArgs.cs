using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows;

namespace Alarm_Clock
{
    public class AlarmEventArgs : EventArgs
    {
        public AlarmEventArgs()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\huynjm\Source\Repos\AlarmClock\Alarm Clock\Ringtones\Default.wav");
            player.Load();
            player.Play();
        }
      
    }

    
}
