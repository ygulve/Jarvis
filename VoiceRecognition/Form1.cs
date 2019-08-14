using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace VoiceRecognition
{
    public partial class Form1 : Form
    {

        SpeechRecognitionEngine recEngin = new SpeechRecognitionEngine();
        Commands commands = new Commands();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            recEngin.RecognizeAsync(RecognizeMode.Multiple);

            btnDisable.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            Commands cmds = new Commands();
            commands.Add(cmds.getCommands());
            GrammarBuilder grammarBuilder = new GrammarBuilder(commands);

            Grammar grammar = new Grammar(grammarBuilder);

            recEngin.LoadGrammarAsync(grammar);
            recEngin.SetInputToDefaultAudioDevice();

            recEngin.SpeechRecognized += RecEngin_SpeechRecognized;
        }

        private void RecEngin_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                switch (e.Result.Text.ToLower())
                {
                    case "jarvis":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(0));

                        //promptBuilder.AppendBreak(new TimeSpan(1000));
                        //promptBuilder.StartSentence();
                        //promptBuilder.AppendText("What can I do for you?", PromptEmphasis.None);
                        //promptBuilder.EndSentence();
                        
                        break;
                    case "what time is it?":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        string currenttime = DateTime.Now.ToShortTimeString();
                        commands.speak(commands.getReply(1) + " " + currenttime);                       
                        break;
                    case "open google":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(2));
                        Process.Start("chrome.exe", "http://www.google.com/");
                        break;
                    case "what is your name?":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(3));                     
                        break;
                    case "open outlook":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(4));                       
                        Process.Start("OUTLOOK.EXE");
                        break;
                    case "open vs":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(5));                       
                        Process.Start("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Professional\\Common7\\IDE\\devenv.exe");
                        break;
                    case "open vs code":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(6));                       
                        Process.Start("Code.exe");
                        break;
                    case "open notepad plus plus":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(7));                      
                        Process.Start("notepad++.exe");
                        break;
                    case "close notepad plus plus":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(8));                        
                        Process[] proc = Process.GetProcessesByName("notepad++");                        
                        proc[0].Kill();
                        break;
                    case "minimize outlook":
                        richTextBox1.Text = e.Result.Text.ToLower();
                        commands.speak(commands.getReply(9));
                        proc = Process.GetProcessesByName("outlook");
                        ProcessStartInfo theProcess = new ProcessStartInfo("outlook.exe");

                        theProcess.UseShellExecute = false;
                        theProcess.WindowStyle = ProcessWindowStyle.Minimized;
                        
                        break;
                
                }

            }
            catch (Exception ex)
            {                
               commands.speak(commands.getReply(10));                
            }

        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngin.RecognizeAsyncStop();
            btnDisable.Enabled = false;
        }
    }
}
