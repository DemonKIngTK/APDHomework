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
        apd621_60011212035Entities context = new apd621_60011212035Entities();
        private string texts;
        private string file;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            table2BindingSource.DataSource = context.Table_2.ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            setText(textBox1.Text);
            form.chageText();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void setText(String str)
        {
            texts = str;
        }
        public String getText()
        {
            return texts;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text!="")
            {
                Table_2 playlist = new Table_2();
                playlist.name = textBox2.Text;

                table2BindingSource.AddNew();

                context.Table_2.Add(playlist);
                context.SaveChanges();
                table2BindingSource.DataSource = context.Table_2.ToList();

            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            var toDel = context.Table_2.Where(d => d.id == id).First();
            context.Table_2.Remove(toDel);
            context.SaveChanges();
            table2BindingSource.DataSource = context.Table_2.ToList();
        }
    }
}
