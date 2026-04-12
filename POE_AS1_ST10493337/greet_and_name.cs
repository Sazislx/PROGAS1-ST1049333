using System;
using System.Threading;
using System.Drawing;

using System.Linq;




namespace POE_AS1_ST10493337
{
    public class greet_and_name
    {
        // This will store whatever name the user enters
        private string username = string.Empty;

        // Displays the welcome banner
        public void welcome()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Welcome to CHATBOT]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================");

            // Reset back to default color so other text looks normal
            Console.ResetColor();
        }

        // Ask the user for their name and make sure it's valid
        public void ask_name()
        {
            bool validName = false;

            // Show bot name at the start
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AI NAME: CyberShield Cybersecurity Awareness Bot");
            Console.ResetColor();

            // Keep looping until the user enters a proper name
            while (!validName)
            {
                Console.WriteLine("Hey Enter Your Name.");

                // Prompt the user
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("User: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                username = Console.ReadLine();
                Console.ResetColor();

                // Basic validation checks
                if (username.Length <= 1)
                {
                    Console.WriteLine("Please enter a proper name, a single letter is not allowed.\n");
                }
                else if (username.Any(char.IsDigit))
                {
                    Console.WriteLine("Numbers are not allowed in your name, please try again.\n");
                }
                else
                {
                    // If it passes all checks, we’re good
                    validName = true;
                }
            }

            Console.WriteLine();

            // Once we have a valid name, greet the user
            isEmpty();
        }

        // This just checks if the name exists and prints the intro message
        private bool isEmpty()
        {
            if (username != "")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("AI Name:");
                Console.ForegroundColor = ConsoleColor.Green;

                // Friendly intro message from the bot
                Console.WriteLine("Hey " + username + "! I'm your Cybersecurity Awareness Bot.");
                Console.WriteLine("I am a chatbot that will help you understand the internet,");
                Console.WriteLine("phishing, creating a strong password and safe browsing.");
                Console.WriteLine("So Ask Me Anything " + username + ". Let's get started!");

                Console.ResetColor();
                return true;
            }
            else
            {
                // This would only happen if somehow the name is empty
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("AI Name:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter your name");

                Console.ResetColor();
                return false;
            }
        }
    }
}