using System;
using System.Collections.Generic;

namespace CyberBot
{                             // ST10457954 MH MadibaPart 1
    public class Chatbot
    {
        public string UserName { get; private set; }
        private Random random = new Random();
        private Dictionary<string, string[]> responseDatabase;

        public Chatbot()
        {
            InitializeResponses();
        }

        public void SetUserName(string name)
        {
            UserName = name;
        }

        
        private void InitializeResponses()
        {
            responseDatabase = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                                                                        // "how are you"
                ["how are you"] = new[]
                {
                    "I'm functioning well, thank you! Ready to help you stay cyber-safe.",
                    "I'm doing great! How can I assist with your cybersecurity questions?",
                    "All systems operational! What would you like to learn about protecting yourself online?"
                },

                  
                ["purpose"] = new[]
                {
                    "I'm your Cyber Security Assistant. My purpose is to educate South African citizens about online safety, helping you recognize and avoid cyber threats like phishing, scams, and identity theft.",
                    "I'm here to help you navigate the digital world safely! From password security to recognizing suspicious emails, I've got you covered.",
                    "My mission is to make cybersecurity knowledge accessible to everyone. Think of me as your personal digital safety guide."
                },

                                       //  "what can I ask you about?"
                ["what can i ask"] = new[]
                {
                    "You can ask me about:\n- Password safety\n- Phishing scams\n- Safe browsing habits\n- Email security\n- Social engineering\n- General cybersecurity tips\n\nJust type your question and I'll help!",
                    "Feel free to ask about passwords, phishing, safe internet browsing, email safety, or any other cybersecurity concerns you might have.",
                    "I can answer questions on password safety, phishing recognition, safe browsing, email security, and social engineering. Try asking 'Tell me about passwords' or 'What is phishing?'"
                },

                
                ["password"] = new[]
                {
                    "Password Safety Tips:\n- Use at least 12 characters with letters, numbers, and symbols\n- Never reuse passwords across accounts\n- Consider using a password manager\n- Enable two-factor authentication when available",
                    "Strong passwords are your first defense. Use a unique password for each account and change them regularly."
                },

                ["phish"] = new[]
                {
                    "Phishing Awareness:\n- Be suspicious of urgent requests for personal info\n- Check sender email addresses carefully\n- Hover over links before clicking\n- Look for spelling errors and poor grammar\n- When in doubt, contact the organization directly",
                    "Phishing attacks often impersonate banks like FNB, Standard Bank, or Capitec in South Africa. Always verify unexpected messages."
                },

                ["safe browsing"] = new[]
                {
                    "Safe Browsing Tips:\n- Look for 'https://' in the URL before entering sensitive info\n- Avoid clicking on pop-up ads\n- Keep your browser and antivirus updated\n- Don't download files from untrusted sources\n- On public Wi-Fi, consider using a VPN",
                    "Public Wi-Fi in malls and coffee shops can be risky. A VPN adds encryption to protect your data."
                },

                ["email"] = new[]
                {
                    "Email Safety:\n- Never click links in unsolicited emails\n- Verify unexpected attachments with the sender\n- Be wary of emails claiming you've won prizes\n- Don't reply to spam - it confirms your email is active\n- Use spam filters and report phishing attempts",
                    "Legitimate companies will never ask for your password or OTP via email."
                },

                ["social engineering"] = new[]
                {
                    "Social Engineering Awareness:\n- Be cautious of callers claiming to be 'tech support'\n- Verify identities through official channels\n- Don't share personal info on social media\n- Be skeptical of 'too good to be true' offers\n- Trust your instincts - if something feels wrong, it probably is"
                },

                ["help"] = new[]
                {
                    "I can help you with:\n- Password safety\n- Phishing scams\n- Safe browsing\n- Email security\n- Social engineering\n\nJust type your question or topic, and I'll provide helpful information.",
                    "Need guidance? Ask me about passwords, phishing, safe browsing, or any other cybersecurity topic."
                }
            };
        }

                                                                                // response based on user input
        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return GetDefaultResponse();

            
            foreach (var key in responseDatabase.Keys)
            {
                if (input.Contains(key))
                {
                    var responses = responseDatabase[key];
                    return responses[random.Next(responses.Length)];
                }
            }

            
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
                return "Hi " + UserName + "! How can I help you stay safe online today?";

           
            if (input.Contains("thank"))
                return "You're welcome! Stay safe online.";

           
            return GetDefaultResponse();
        }

        private string GetDefaultResponse()
        {
            string[] defaults = {
                "I'm not sure I understand. Could you rephrase your question about cybersecurity?",
                "I didn't quite catch that. Feel free to ask me about passwords or phishing.",
                "Hmm, I'm not sure about that. Try asking me about password safety or how to spot phishing emails."
            };
            return defaults[random.Next(defaults.Length)];
        }
    }
}