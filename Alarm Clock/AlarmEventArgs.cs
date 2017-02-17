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
            // get path of persons account
            SoundPlayer player = new SoundPlayer(@"C:\Users\hannah.rueb\Source\Repos\AlarmClock\Alarm Clock\Ringtones\Default.wav");
            player.Load();
            player.Play();
        }
      
    }

    
}
