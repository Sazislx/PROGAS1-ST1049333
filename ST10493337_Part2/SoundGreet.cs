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
        public SoundGreet()
{
    string paths = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\", @"\greet.wav");

    SoundPlayer greet = new SoundPlayer(paths);
    greet.Play();
}

    }
}
