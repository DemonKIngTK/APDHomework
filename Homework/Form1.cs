using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Visible = true;
            if (form2.Visible == true)
            {
                form2.BringToFront();
            }

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label2.Text = DateTime.Now.ToString("hh:mm:ss tt");
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            label3.Location = new Point(label3.Location.X - 10, label3.Location.Y);

            if (label3.Location.X < -label3.Width)
            {
                label3.Location = new Point(this.Width + label3.Width, label3.Location.Y);
            }


        }
        public void AddPlaylist(string filename)
        {
            axVLCPlugin21.playlist.add(new Uri(filename).AbsoluteUri);

        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
            int d = axVLCPlugin21.playlist.items.count;
            MessageBox.Show("TestPlay"+d);

        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.togglePause();
        }
        public void chageText()
        {
            Form2 form2 = new Form2();
            label3.Text = form2.getText();
            MessageBox.Show(label3.Text);
        }
    }
}
