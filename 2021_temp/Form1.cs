using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;



namespace _2021_temp
{

    public partial class Form1 : Form
    {
        TextReading temp_speech = new TextReading();

        
        static SpeechRecognitionEngine _recognizer = null;
        static ManualResetEvent manualResetEvent = null;
        public Form1()
        {
            InitializeComponent();
            FormLoad();
            textBox1.Text = "Myanmar is a member of the East Asia Summit, Non-Aligned Movement, ASEAN, and BIMSTEC, but it is not a member of the Commonwealth of Nations. It is a country rich in jade and gems, oil, natural gas, and other mineral resources. Myanmar is also endowed with renewable energy; it has the highest solar power potential compared to other countries of the Great Mekong Subregion.[15] In 2013, its GDP (nominal) stood at US$56.7 billion and its GDP (PPP) at US$221.5 billion.[16] The income gap in Myanmar is among the widest in the world, as a large proportion of the economy is controlled by supporters of the military government.[17] As of 2020, according to the Human Development Index, Myanmar ranks 147 out of 189 countries in human developmen";
        }

        private void FormLoad()
        {
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            // Display the form as a modal dialog box.
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {      
            
            temp_speech.AsyncTextSpeak(textBox1.Text);
            textBox1.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp_speech.PauseTextSpeak();
            textBox1.BackColor = Color.Yellow;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temp_speech.ResumeTextSpeak();
            textBox1.BackColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temp_speech.Dispose();
            textBox1.BackColor = Color.White;
            textBox1.Text = "";
            Form1.ActiveForm.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            _recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder("exit")));
            _recognizer.LoadGrammar(new DictationGrammar());
            _recognizer.SpeechRecognized += speechRecognitionWithDictationGrammar_SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        void speechRecognitionWithDictationGrammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "exit")
            {
                manualResetEvent.Set();
                return;
            }
            textBox2.Text = e.Result.Text;
            //  Console.WriteLine("You said: " + e.Result.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }


    }
}
