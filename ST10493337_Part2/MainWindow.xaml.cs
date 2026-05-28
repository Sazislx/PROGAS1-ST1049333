using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10493337_Part2
{//start of namespace
    public partial class MainWindow : Window
    {
        // Observable collection to store and display chat messages
        private ObservableCollection<ChatMessage> messages = new ObservableCollection<ChatMessage>();

        // Stores the current user's name for use across methods
        private string currentUserName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            new SoundGreet() { };
            // Bind the chat history list to the messages collection
            chat_history_list.ItemsSource = messages;
        }

        private void start_ai(object sender, RoutedEventArgs e)
        {
            // Hide logo grid and show username entry grid
            Logo_grid.Visibility = Visibility.Hidden;
            username_grid.Visibility = Visibility.Visible;
        }

        private void Submit_username(object sender, RoutedEventArgs e)
        {
            string name = username.Text;

            // Check if name contains numbers — show specific error
            if (name.Any(char.IsDigit))
            {
                MessageBox.Show("Numbers are not allowed in your name.");
                username.Clear();
                return;
            }

            // Check minimum length of 4 characters
            if (name.Length < 4)
            {
                MessageBox.Show("Error: Name must be at least 4 characters long.");
                username.Clear();
                return;
            }

            if (isUsernameVaild(name))
            {
                // Save the username so interests can be recalled later
                currentUserName = name;

                // Hide username grid and show chatbot grid
                username_grid.Visibility = Visibility.Hidden;
                chatbot_grid.Visibility = Visibility.Visible;

                // Build the intro greeting
                string intro = "Hello " + name + " I'm The Ashbourne Cybersecurity Awareness Bot. So Ask Me Anything!\n"
                    + "I am here to help you understand the internet, phishing, strong passwords and safe browsing. Start searching to get started.";

                // Check if this user has saved interests and remind them on login
                string filename = "interested_topic.txt";
                if (File.Exists(filename))
                {
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        // Case-insensitive match on the saved name
                        if (line.ToLower().StartsWith(name.ToLower() + " interested in:"))
                        {
                            // Extract the interests after the colon
                            string savedInterests = line.Substring(line.IndexOf(':') + 1).Trim();
                            intro += "\n\nWelcome back! I remember you're interested in: " + savedInterests + ".";
                            break;
                        }
                    }
                }

                BotMessage(intro);
            }
            else
            {
                MessageBox.Show("Error");
                username.Clear();
            }
        }

        // Validates that the username is not empty, contains no digits, and is at least 4 characters
        public bool isUsernameVaild(string username)
        {
            if (String.IsNullOrEmpty(username))
                return false;

            if (username.Any(char.IsDigit))
                return false;

            // Minimum 4 characters required
            if (username.Length < 4)
                return false;

            return true;
        }

        // Detects the emotional sentiment of the user's input
        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
                return "worried";
            if (input.Contains("frustrated") || input.Contains("confused") || input.Contains("lost"))
                return "frustrated";
            if (input.Contains("curious") || input.Contains("interested") || input.Contains("learn"))
                return "curious";

            return "neutral";
        }

        // Returns an empathetic prefix based on the detected sentiment
        private string GetSentimentPrefix(string sentiment, string name)
        {
            if (sentiment == "worried")
                return $"It's okay to feel that way, {name}. You're not alone. ";
            if (sentiment == "frustrated")
                return $"I understand, {name}. Let's take it step by step. ";
            if (sentiment == "curious")
                return $"Great curiosity, {name}! Here's what you should know: ";

            return "";
        }

        // Stores the current multi-step bot response lines
        private string[] currentLines = new string[0];
        // Tracks which step the user is on in a multi-step response
        private int currentStep = 0;

        public void UserInput(string input)
        {
            string name = username.Text.Trim();
            string rawInput = input.Trim();
            // Lowercase input for keyword matching
            input = input.ToLower();

            // FIX: if the user submits nothing, tell them to enter something
            if (string.IsNullOrWhiteSpace(rawInput))
            {
                BotMessage("Please enter something, " + name + ".");
                return;
            }

            UserMessage(rawInput);

            string sentiment = DetectSentiment(input);
            string prefix = GetSentimentPrefix(sentiment, name);

            if (input.Contains("what can i ask"))
            {
                // Tell the user what topics are available
                BotMessage(prefix + "You can ask me about passwords, phishing and safe browsing, " + name + "!");
            }
            else if (input.Contains("password"))
            {
                // Load multi-step password advice
                currentLines = new string[] {
                    prefix + "A strong password is your first line of defense against hackers.",
                    "Use at least 12 characters.\nMix uppercase, lowercase, numbers and symbols.\nNever reuse passwords.\nUse a password manager.",
                    "Passwords are the keys to your digital life. A weak password can be cracked in seconds using automated tools, putting your personal data, finances, and privacy at serious risk. That's why choosing a strong, unique password for every account is one of the most important steps you can take to stay secure online."
                };
                currentStep = 0;
                BotMessage(currentLines[currentStep++]);
            }
            else if (input.Contains("phishing"))
            {
                // Load multi-step phishing advice
                currentLines = new string[] {
                    prefix + "Phishing is when criminals trick you into giving your information.",
                         "They use fake emails or websites.\nNever click suspicious links.\nNo real company will ask for your password by email.",
                        "Phishing attacks are one of the most common forms of cybercrime, targeting millions of people every day. Criminals craft convincing messages that appear to come from trusted sources like your bank, employer, or a popular website. Always verify the sender's email address, look for spelling mistakes, and go directly to a website by typing it in your browser instead of clicking links in emails."
                };
                currentStep = 0;
                BotMessage(currentLines[currentStep++]);
            }
            else if (input.Contains("browsing") || input.Contains("safe"))
            {
                // Load multi-step safe browsing advice
                currentLines = new string[] {
                    prefix +"Safe browsing protects you from threats hiding across the web.",
                    "Always check for HTTPS in the website address.\nAvoid downloading files from unknown sites.\nUse a trusted browser with security features.\nClear your cookies and cache regularly.\nUse a VPN on public Wi-Fi.",
                     "Every website you visit can potentially track your activity, collect your data, or expose you to malware. Safe browsing habits are essential to protecting your privacy and security online. Stick to well-known, trusted websites, keep your browser updated, and consider installing an ad blocker or privacy extension to reduce your exposure to malicious ads and trackers." };
                currentStep = 0;
                BotMessage(currentLines[currentStep++]);
            }
            else if (input.Contains("tell me more") || input.Contains("more"))
            {
                // Continue to the next step if more content is available
                if (currentStep < currentLines.Length)
                    BotMessage(currentLines[currentStep++]);
                else
                    BotMessage("I didn't understand, " + name + ". Please rephrase.");
            }
            else if (sentiment != "neutral")
            {
                // Respond to emotional input with a helpful nudge
                BotMessage(prefix + "You can ask me about passwords, phishing, or safe browsing and I'll help you out!");
            }
            else
            {
                // ── START OF INTERESTS

                if (input.Contains("interested"))
                {
                    // Split the lowercased input into individual words
                    string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' },
                                                  StringSplitOptions.RemoveEmptyEntries);

                    // Noise/stop words to ignore when extracting topic keywords
                    HashSet<string> ignore = new HashSet<string>
                    {
                        "i", "am", "im", "i'm", "is", "the", "a", "an", "to",
                        "it", "of", "my", "me", "we", "be", "do", "so", "at",
                        "on", "or", "if", "as", "by", "no", "up", "hi", "hey"
                    };

                    string message = string.Empty;
                    string store_interests = string.Empty;
                    bool found_interest = false;

                    HashSet<string> currentInterests = new HashSet<string>();

                    foreach (string interest in words)
                    {
                        // Clean each word — remove non-alphanumeric characters
                        string clean = interest.ToLower().Trim();
                        clean = Regex.Replace(clean, @"[^a-zA-Z0-9\s]", "");

                        // Filter out noise words, the trigger word itself, and very short words
                        if (!ignore.Contains(clean)
                            && clean != "interested"
                            && clean != "and"
                            && clean != "in"
                            && clean.Length >= 3)
                        {
                            found_interest = true;
                            currentInterests.Add(clean);
                        }
                    }

                    store_interests = string.Join(", ", currentInterests);

                    if (found_interest && !string.IsNullOrWhiteSpace(store_interests))
                    {
                        string filename = "interested_topic.txt";
                        bool userFound = false;

                        if (File.Exists(filename))
                        {
                            string[] lines = File.ReadAllLines(filename);

                            for (int i = 0; i < lines.Length; i++)
                            {
                                // Case-insensitive compare so name casing never causes a mismatch
                                if (lines[i].ToLower().StartsWith(name.ToLower() + " interested in:"))
                                {
                                    userFound = true;

                                    // Use IndexOf(':') to safely extract everything after the colon
                                    string existing = lines[i]
                                        .Substring(lines[i].IndexOf(':') + 1)
                                        .ToLower();

                                    // Build a set of existing interests for this user
                                    HashSet<string> existingSet = new HashSet<string>(
                                        existing.Split(',')
                                                .Select(x => x.Trim())
                                                .Where(x => x != ""));

                                    // Merge new interests without duplicates
                                    foreach (string item in currentInterests)
                                        existingSet.Add(item);

                                    // Write the updated line back preserving original name casing
                                    lines[i] = name + " interested in: " + string.Join(", ", existingSet);
                                    File.WriteAllLines(filename, lines);

                                    // FIX: clearly tell the user their interest is saved and will be remembered next time
                                    message = "Great! I will remember that you're interested in "
                                            + store_interests + " for next time, " + name + "!"
                                            + " As someone interested in " + store_interests
                                            + ", remember that staying informed is key to staying safe online!";
                                    break;
                                }
                            }
                        }

                        if (!userFound)
                        {
                            // User not in file yet — append a new entry
                            File.AppendAllText(
                                filename,
                                name + " interested in: " + store_interests + "\n"
                            );

                            // FIX: clearly tell the user their interest is saved and will be remembered next time
                            message = "Great! I will remember that you're interested in "
                                    + store_interests + " for next time, " + name + "!"
                                    + " It's a crucial part of staying safe online!";
                        }
                    }
                    else
                    {
                        // No valid interest keywords found in the input
                        message = "Please specify what you're interested in, " + name
                                + " (e.g., 'I am interested in cybersecurity').";
                    }

                    BotMessage(message);
                }

                // ── END OF INTERESTS

                else
                {
                    // Input did not match any known topic
                    BotMessage("I didn't understand, " + name + ". Please rephrase.");
                }
            }
        }

        // Adds a bot message to the chat history
        private void BotMessage(string message)
        {
            messages.Add(new ChatMessage
            {
                Message = message,
                Sender = "Bot",
                Timestamp = DateTime.Now.ToString("HH:mm")
            });
        }

        // Adds a user message to the chat history
        private void UserMessage(string message)
        {
            messages.Add(new ChatMessage
            {
                Message = message,
                Sender = "User",
                Timestamp = DateTime.Now.ToString("HH:mm")
            });
        }

        private void Submit_response(object sender, RoutedEventArgs e)
        {
            // Send the user's input and clear the text box
            UserInput(user_response.Text);
            user_response.Clear();
            user_response.Focus();
        }
    }

    // Model class representing a single chat message
    public class ChatMessage
    {
        public string Timestamp { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
    }
}
//end of namespace
