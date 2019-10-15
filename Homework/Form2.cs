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
        apd621_60011212035Entities1 context = new apd621_60011212035Entities1();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            table2BindingSource.DataSource = context.Table_2.ToList();
            textShowBindingSource.DataSource = context.textShows.ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textShow textShow = new textShow();
            textShow.text = textBox1.Text;
            textShow.time = int.Parse(textBox3.Text);

            textShowBindingSource.AddNew();
   
            context.textShows.Add(textShow);
            int change = context.SaveChanges();
            MessageBox.Show("Change " + change + " records");
            textShowBindingSource.DataSource = context.textShows.ToList();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void Button6_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView2.SelectedCells[0].Value.ToString());
            var toDel = context.textShows.Where(d => d.id == id).First();
            context.textShows.Remove(toDel);
            context.SaveChanges();
            textShowBindingSource.DataSource = context.textShows.ToList();
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }
    }
}
