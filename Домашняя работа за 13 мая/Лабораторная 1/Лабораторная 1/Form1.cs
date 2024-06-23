using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDlg.Dispose();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.BeginUpdate();
            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();

                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                    
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }
            }
            listBox1.EndUpdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            richTextBox1.Clear();
            textBox1.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = true;
            radioButton3.Checked = true;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            string Find = textBox1.Text;

            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items) 
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();

            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedIndex);
            listBox2.Items.Remove(listBox2.SelectedIndex);
            listBox3.Items.Remove(listBox3.SelectedIndex);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Алфавиту (по убыванию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                list.Sort();
                list.Reverse();
                listBox1.Items.Clear();
                foreach (var item in list)
                    listBox1.Items.Add(item);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Алфавиту (по возрастанию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                list.Sort();
                listBox1.Items.Clear();
                foreach (var item in list)
                    listBox1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < richTextBox1.Text.Length; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();
            Application.Exit();
            MessageBox.Show("Информация о приложении и разработчике");
        }
    }
}
