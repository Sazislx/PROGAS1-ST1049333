using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ST10493337_Part2
{
    public class SoundGreet
    {
        //Constructure of sound bot
        public SoundGreet()
        {//added sound code
            string paths = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\", @"\greet.wav");
        
            SoundPlayer greet = new SoundPlayer(paths);
            greet.Play();
        }

    }
}
