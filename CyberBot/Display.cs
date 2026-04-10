using System;
using System.Threading;

namespace CyberBot
{                                      // ST10457954 MH Madiba Part 1
    public class Display
    {
                                                                          //  cybersecurity ASCII logo
        public void ShowAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
+-------------------------------------------+
|               CYBER BOT                   |
|              Awareness                    |
|               South Africa                |
+-------------------------------------------+");
            Console.ResetColor();
        }

                                                                        // Typewriter effect
        public void TypeWriter(string text, int delayMs)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

       
        public void DrawSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.ResetColor();
        }

                                                                           //  colored message
        public void ShowColoredMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}