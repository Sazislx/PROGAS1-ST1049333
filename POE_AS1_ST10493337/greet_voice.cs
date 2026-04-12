using System;
using System.Media;
using System.Threading;
using System.Drawing;
namespace POE_AS1_ST10493337
{//start of namespace
    public class greet_voice
    {//start of class

        //auto path
        string path = AppDomain.CurrentDomain.BaseDirectory;


        public greet_voice()
        {//start constructor
            //call the voice method
            voice();
          

        }//end of constructor
        //method to voice greet the user
        private void voice()
        {//start of method

            //get the full path replace of Debug\bin\
            string fullpath = path.Replace(@"bin\Debug\", "");

            //Play The Sound
            string joined_path = fullpath + "greet.wav";

            //create an instance for the soundPlayer class
            SoundPlayer voice_play = new SoundPlayer(joined_path);

            voice_play.Load();
            //play till the end
            voice_play.PlaySync();




        }//end of method voice




    }//end ofclass


}//start of namespace