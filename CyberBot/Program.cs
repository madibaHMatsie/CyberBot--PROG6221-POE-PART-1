using System;
using System.Threading;

namespace CyberBot
{                                      // St10457954 MH Madiba Part 1
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cyber Bot - South Africa";

                                                                           // objects for display, audio, and chatbot 
            Display display = new Display();
            AudioService audio = new AudioService();
            Chatbot chatbot = new Chatbot();

                                                                                       // ASCII logo
            display.ShowAsciiLogo();

                                                                                             
            audio.SpeakGreeting();

                                                                      
            Thread.Sleep(500);

                                             
            display.TypeWriter("Welcome to Cyber Bot!", 40);
            Thread.Sleep(500);

                                                // Get user name
            string userName = GetUserName(display);
            chatbot.SetUserName(userName);

           
            display.ShowColoredMessage("\nHello, " + userName + "! Great to have you here!", ConsoleColor.DarkBlue);
            display.DrawSeparator();

                                                  // Chat loop
            RunChatLoop(chatbot, display);
        }

                                                                        // Get user name with validation
        static string GetUserName(Display display)
        {
            string name;
            do
            {
                display.TypeWriter("What's your name? ", 40);
                name = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(name))
                {
                    display.ShowColoredMessage("I didn't catch that. Please enter your name:", ConsoleColor.Yellow);
                }
            } while (string.IsNullOrWhiteSpace(name));
            return name;
        }

                                                                                   // interaction loop
        static void RunChatLoop(Chatbot chatbot, Display display)
        {
            bool running = true;
            while (running)
            {
                display.ShowColoredMessage("\n" + chatbot.UserName + ", what would you like to know about cybersecurity?", ConsoleColor.DarkRed);
                Console.Write("> ");
                string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (input == "exit" || input == "quit" || input == "goodbye")
                {
                    display.TypeWriter("Stay safe online, " + chatbot.UserName + "! Remember: Cyber security starts with you!", 40);
                    running = false;
                }
                else
                {
                    string response = chatbot.GetResponse(input);
                    display.TypeWriter(response, 30);
                }
            }
        }
    }
}
