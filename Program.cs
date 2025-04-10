using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        DisplayBanner();

        Console.Title = "Cybersecurity Awareness Bot";

        Divider();
        Console.ForegroundColor = ConsoleColor.Yellow;
        TypeLine("👋 Hi there! Welcome to CyberChatBot — your friendly cybersecurity awareness assistant.", 15);
        Console.ResetColor();
        TypeLine("Type a question or topic (like 'password', 'phishing', 'wifi') or type 'exit' to quit.");
        Divider();

        Console.Write("🧑 What’s your name? ");
        string userName = Console.ReadLine()?.Trim() ?? "Friend";
        Console.WriteLine($"\nWelcome, {userName}! Let's start chatting about online safety.");

        Dictionary<string, string> responses = new Dictionary<string, string>()
        {
            { "how are you", "🤖 I'm running smoothly and virus-free, thanks for asking!" },
            { "what is your purpose", "🧠 I'm here to help you learn how to stay safe online — one tip at a time." },
            { "what can i ask you about", "❓ Try asking about 'password safety', 'phishing', 'wifi security', or 'malware protection'." },
            { "password", "🔐 Use a long, unique password for each account. Consider using a password manager!" },
            { "phishing", "🎣 Be cautious of unexpected emails and links — even if they look legit. Don't click suspicious stuff!" },
            { "wifi", "📶 Avoid using public Wi-Fi for banking or sensitive tasks unless you're on a VPN." },
            { "malware", "🛡️ Install and regularly update antivirus software. Don’t download files from unknown sources." },
            { "2fa", "🔑 Enable two-factor authentication wherever possible to make your accounts harder to crack." },
            { "safe browsing", "🌐 Use secure, HTTPS websites and never download files from shady links or popups." }
        };

        while (true)
        {
            Console.Write($"\n💬 {userName}: ");
            string? userInput = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeLine("❗ I didn’t catch that. Please type something like 'password' or 'phishing'.");
                Console.ResetColor();
                continue;
            }

            if (userInput == "exit")
            {
                Divider();
                TypeLine($"👋 Thanks for chatting with CyberChatBot, {userName}. Stay safe online!");
                Divider();
                break;
            }

            bool found = false;
            foreach (var key in responses.Keys)
            {
                if (userInput.Contains(key))
                {
                    Divider();
                    TypeLine($"🤖 CyberChatBot: {responses[key]}", 25);
                    Divider();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Divider();
                TypeLine("🤖 I didn’t quite understand that. Could you rephrase?");
                TypeLine("🧠 Try asking about: password, phishing, wifi, malware, 2FA, or safe browsing.", 15);
                TypeLine("📣 You can also ask: 'how are you?', 'what's your purpose?', or 'what can I ask you about?'.", 15);
                Divider();
            }
        }
    }

    static void DisplayBanner()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
   ____            _                 _                     
  / ___|___  _ __ | |__   ___   ___ | | ___   __ _  ___    
 | |   / _ \| '_ \| '_ \ / _ \ / _ \| |/ _ \ / _` |/ _ \   
 | |__| (_) | | | | | | | (_) | (_) | | (_) | (_| | (_) |  
  \____\___/|_| |_|_| |_|\___/ \___/|_|\___/ \__, |\___/   
                                            |___/          
   ____                 _                               _             
  / ___|_ __ ___  _   _| | ___  ___ _ ____   _____ _ __| |_ ___  _ __ 
 | |   | '__/ _ \| | | | |/ _ \/ _ \ '__\ \ / / _ \ '__| __/ _ \| '__|
 | |___| | | (_) | |_| | |  __/  __/ |   \ V /  __/ |  | || (_) | |   
  \____|_|  \___/ \__,_|_|\___|\___|_|    \_/ \___|_|   \__\___/|_|   
");
        Console.ResetColor();
    }

    static void TypeLine(string message, int delay = 20)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    static void Divider()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n" + new string('-', 60) + "\n");
        Console.ResetColor();
    }
}
