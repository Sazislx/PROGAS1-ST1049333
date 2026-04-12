using System;
using System.Threading;
using System.Drawing;

namespace POE_AS1_ST10493337
{//start of namespace

    public class AskQuestion
    {//start of class

        public static void askQuestion()
        {//start of method
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------");
            Console.ResetColor();

            // display user prompt with color
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n" + askname.userName + ": ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string input = Console.ReadLine().ToLower().Trim();
            Console.ResetColor();

            // AI label
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nAI: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("I didn't quite understand that. Could you rephrase?");
            }
            else if (input.Contains("how are you"))
            {
                Console.WriteLine("I am doing great, " + askname.userName + "! Ready to help you stay safe online.");
            }
            else if (input.Contains("what is your purpose") || input.Contains("what's your purpose"))
            {
                Console.WriteLine("I am a Cybersecurity Awareness Bot designed to help you stay safe online.");
                Console.WriteLine("I educate users about the dangers and threats that exist on the internet.");
                Console.WriteLine("I can teach you how to create strong passwords to protect your accounts.");
                Console.WriteLine("I can explain what phishing is and how to avoid falling victim to it.");
                Console.WriteLine("I can guide you on how to browse the internet safely and securely.");
                Console.WriteLine("Think of me as your personal digital security guide, always here to help.");
            }
            else if (input.Contains("what can i ask"))
            {
                Console.WriteLine("You can ask me about passwords, phishing and safe browsing, " + askname.userName + "!");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("A strong password is your first line of defense against hackers.");
                Console.WriteLine("Always use at least 12 characters in your password.");
                Console.WriteLine("Mix uppercase, lowercase, numbers and special symbols like @, # or $.");
                Console.WriteLine("Never reuse the same password across multiple accounts.");
                Console.WriteLine("Use a password manager to safely store all your passwords.");
                Console.WriteLine("Enable two factor authentication wherever possible.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Phishing is when criminals disguise themselves as trustworthy sources.");
                Console.WriteLine("They pretend to be your bank or a popular website to trick you.");
                Console.WriteLine("Always check the senders email address carefully before clicking anything.");
                Console.WriteLine("Never click on suspicious links even if they look legitimate.");
                Console.WriteLine("Remember no legitimate company will ask for your password via email.");
            }
            else if (input.Contains("browsing") || input.Contains("safe browsing"))
            {
                Console.WriteLine("Always look for HTTPS and a padlock icon before entering any information.");
                Console.WriteLine("Avoid clicking on pop ups or ads that seem too good to be true.");
                Console.WriteLine("Never download files from websites you do not trust.");
                Console.WriteLine("Make sure your browser and antivirus are always up to date.");
                Console.WriteLine("Always use a VPN on public Wi-Fi to keep your connection secure.");
            }
            else if (input.Contains("exit") || input.Contains("quit"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Goodbye " + askname.userName + "! Stay safe online!");
                Console.ResetColor();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("I didn't quite understand that, " + askname.userName + ". Could you rephrase?");
            }

            Console.ResetColor();

        }//end of method

    }//end of class

}//end of namespace