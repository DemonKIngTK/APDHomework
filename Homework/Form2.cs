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
    public partial class Form2 : Form
    {

        private string text;
        private string file;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            setText(textBox1.Text);
            form.chageText();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public void setText(String str)
        {
            text = str;
        }
        public String getText()
        {
            return text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                listBox1.Items.Add(openFileDialog1.FileName);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.AddPlaylist(textBox2.Text);
            MessageBox.Show("Test");
        }

    }
}
