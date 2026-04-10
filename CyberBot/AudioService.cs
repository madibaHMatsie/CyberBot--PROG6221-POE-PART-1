using System;
using System.Speech.Synthesis;

namespace CyberBot
{                                                //ST10457954 MH Madiba Part 1
    public class AudioService : IDisposable
    {
        private SpeechSynthesizer synthesizer;

        public AudioService()
        {
            try
            {
                synthesizer = new SpeechSynthesizer();

                //  Microsoft Zira set as default voice
                try
                {
                    synthesizer.SelectVoice("Microsoft Zira Desktop");
                }
                catch
                {
                    
                    Console.WriteLine("Note: Microsoft Zira voice not found. Using default voice.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Speech synthesis not available: " + ex.Message);
                Console.ResetColor();
                synthesizer = null;
            }
        }

                                                                          // Greeting
        public void SpeakGreeting()
        {
            Speak("Welcome to Cyber Bot!");
        }

                                                                      // Speak any text
        public void Speak(string text)
        {
            if (synthesizer == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Voice would say: \"" + text + "\"]");
                Console.ResetColor();
                return;
            }

            try
            {
                synthesizer.Speak(text);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not speak: " + ex.Message);
                Console.ResetColor();
            }
        }

        
        public void Dispose()
        {
            synthesizer?.Dispose();
        }
    }
}