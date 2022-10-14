using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //agregamos la libreria
using System.Speech; //agregamos la referencia
using System.Speech.Synthesis;
using System.Web;

namespace MiLECTORD
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer reader = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //btnSpeak
        private void button4_Click(object sender, EventArgs e)
        {
            reader.SpeakAsync(label1.Text); //leemos el contenido
        }
        //btnAbrir
        private void button5_Click(object sender, EventArgs e)
        {
            Stream str;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if((str=openFileDialog.OpenFile())!=null)
                {
                    string fname = openFileDialog.FileName;
                    string filetxt = File.ReadAllText(fname);
                    label1.Text = filetxt;
                }
            }
        }
        //btnStop
        private void button2_Click(object sender, EventArgs e)
        {
            if(reader!=null)
            {
                reader.Dispose();
            }
        }
        //btnPlay
        private void button1_Click(object sender, EventArgs e)
        {
            if(reader !=null)
            {
                if(reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }
        }
        //btnPausa
        private void button3_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }
    }
}
