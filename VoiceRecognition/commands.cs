using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
   public class Commands
    {
       
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        PromptBuilder promptBuilder = new PromptBuilder();
        string[] command;
        public Commands()
        {
            command = new string[] {
                "Sir!!",
                "Sir!! its ",
                "opening google",
                "My name is Jarvis, your personal AI assistant",
                "opening outlook",
                "opening visual studio",
                "opening visual code",
                "opening notepad plus plus",
                "closing notepad plus plus",
                "minimizing outlook",
                "Sir!! something went wrong, could you please repeate the command?"
            };
        }
        public void speak(string command)
        {
            promptBuilder.StartSentence();
            promptBuilder.AppendText(command);
            promptBuilder.EndSentence();
            speechSynthesizer.SpeakAsync(promptBuilder);
        }

        public string[] getCommands()
        {
            string[] command = new string[] {
                "jarvis",
                "what time is it?",
                "open google",
                "what is your name?",
                "open outlook",
                "open vs",
                "open vs code",
                "open notepad plus plus",
                "close notepad plus plus",
                "search for",
                "minimize outlook"};

            return command;

        }

        public string getReply(int index) {
            return command.GetValue(index).ToString();            
        }
    }
}
