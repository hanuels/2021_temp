using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dinamic_Font
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

           

            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", this.Height / 2, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox2.Text = "Size =" + this.Height / 2;

            TPpanel TPPanel1 = new TPpanel();
            TPPanel1.Location = new Point(0, 0);
            TPPanel1.Size = this.Size;
            TPPanel1.Dock = DockStyle.Fill;
            TPPanel1.BringToFront();
            TPPanel1.Opacity = 50;
            
            //TPPanel1.BackColor = Color.Blue;
            TPPanel1.Parent = textBox1;

            

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            

            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", this.Height / 2, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox2.Text = "Size =" + this.Height / 2;
            textBox1.Text = "Size =" + this.Height / 2;
            
        }

       
        
        

    }
}
