using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR
{
    public partial class Form1 : Form
    {
        OpenFileDialog fileDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();


            //string Text = new IronTesseract().Read("image.png").Text;
            //textBox1.Text = Text;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            // fileDialog.Filter = "Files|*.png" ;
            //fileDialog.Filter = "Image File(png)|*.png;*.jpg;*.GIF;*.BMP;*.jpeg";
            //fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.Filter = "image files |*.png;*.jpg;.gif;.bmp;.jpeg|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Length > 0)
                {
                    
                    pictureBox1.Load(fileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            progressBar1.Value = 0;
            textBox1.Text = "";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fileDialog.FileName.Length > 0)
            {


              

               
                
                textBox1.Text = new IronTesseract().Read(fileDialog.FileName).Text;
                int i = 0;
                while (i++ < 100)
                {
                    progressBar1.PerformStep();
                }
            }


        }
    }
}
