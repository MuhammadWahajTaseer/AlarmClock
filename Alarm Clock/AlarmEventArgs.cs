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
        private bool dismissed = false;
        SoundPlayer player;
        public AlarmEventArgs(bool ring)
        {
            player = new SoundPlayer(@"C:\Users\jgelay\Source\Repos\AlarmClock\Alarm Clock\Ringtones\Default.wav");
            player.Load();
          
        }
        private void playSound()
        {
            player.Play();
        }

        private void stopSound()
        {
            player.Stop();
        }
 
      
    }

    
}
