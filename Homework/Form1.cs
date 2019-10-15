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
        apd621_60011212035Entities1 context = new apd621_60011212035Entities1();
        private int x, con = 1, i = 0 ;
        List<string> text = new List<string>();
        List<int> times = new List<int>();
        public Form1()
        {
            InitializeComponent();
            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer2.Tick += OnTick;
        }
        private void OnTick(object sender, EventArgs e)
        {
            x--;
            //label4.Text = x + "  second";
            if (x <= 0)
            {
                x = 0;
                x = times[i]*60;
                label3.Text = text[i];
                i++;
                if (i == con)
                {
                    text.RemoveAll(l => text.Contains(l));
                    times.RemoveAll(l => times.Contains(l));
                    i = 0;
                    var result = from s in context.textShows
                                 orderby s.id
                                 select s.text;
                    var time = from s in context.textShows
                               orderby s.id
                               select s.time;
                    foreach (int s in time)
                    {
                        times.Add(s);
                    }
                    foreach (string i in result)
                    {
                        text.Add(i);
                    }
                    con = times.Count;
                    Console.WriteLine(con);
                }
            }
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
            text.Add(" ");
            times.Add(0);
            timer1.Start();
            timer2.Start();
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label3.Location = new Point(label3.Location.X - 10, label3.Location.Y);
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label2.Text = DateTime.Now.ToString("hh:mm:ss tt");
            if (label3.Location.X < -label3.Width)
            {
                label3.Location = new Point(this.Width + label3.Width, label3.Location.Y);
            }
        }
        public void AddPlaylist()
        {
            var result = (from s in context.Table_2 select s.name);
            foreach (string i in result)
            {
                axVLCPlugin21.playlist.add(new Uri(i).AbsoluteUri);
            }
            MessageBox.Show(""+axVLCPlugin21.playlist.items.count);
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var result = (from s in context.Table_2 select s.name);
            for (int i = 0;i<=axVLCPlugin21.playlist.items.count;i++)
            {
                axVLCPlugin21.playlist.items.remove(i);
            }
            foreach (string i in result)
            {
                axVLCPlugin21.playlist.add(new Uri(i).AbsoluteUri);
            }
            axVLCPlugin21.volume = 60;
            axVLCPlugin21.playlist.play();
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.togglePause();
        }
        private void NextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.next();
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.prev();
        }
    }
}
