using System;
using System.Linq;
using System.Threading;

namespace POE_AS1_ST10493337
{//start of namespace
    public class askname
    {//start of class
        public static void TypeMessage(string message)
        {//how fast will the message be written by bot
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }

        public static string userName = "";

        public static void AskName()
        {//start of method
            bool validName = false;

            while (!validName)
            {//start of while loop
                Console.Write("Before we begin, what is your name? ");
                userName = Console.ReadLine().Trim();

                if (userName.Length <= 1)
                {
                    Console.WriteLine("Please enter a proper name, a single letter is not allowed.\n");
                }
                else if (userName.Any(char.IsDigit))
                {
                    Console.WriteLine("Numbers are not allowed in your name, please try again.\n");
                }
                else
                {
                    validName = true;
                }//end of while loop
            }

            TypeMessage("\nWelcome, " + userName + "! I'm your Cybersecurity Awareness Bot.");
            TypeMessage("I am a chatbot that will help you understand the internet, phishing, creating a strong password and safe browsing.So Ask Me Anything  " + userName + ". Let's get started!\n");
        }//end of method

    }//end of class

}//end of nmespace
