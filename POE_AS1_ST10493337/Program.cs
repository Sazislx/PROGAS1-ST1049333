using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_AS1_ST10493337
{//Start Of Namespace


    public class Program
    {//start of class
   static void Main(string[] args)
        {//start of method

            //creating an instance for the greet_voice class
            //class with contructor

            new greet_voice() { };

            //creating an instance for the asii_logo class
            //with a contructor

            new ascii_logo() { };

            //creating an instant for the class greey_and_name
            //with an object name greeting_and_name

            greet_and_name greeting_and_name = new greet_and_name();
            //calling the welcome method
            greeting_and_name.welcome();
            greeting_and_name.ask_name();

            //CALLING AskQuestion method
            while (true)
            {
                AskQuestion.askQuestion();
            }


        } //end of method
    }//end of class
}




