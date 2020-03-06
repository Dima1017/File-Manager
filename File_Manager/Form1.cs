using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MetroFramework;
using MetroFramework.Components;

namespace File_Manager
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MetroStyleManager metroStyleManager = null;
            this.StyleManager = metroStyleManager;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo j = new DirectoryInfo(textBox1.Text);
            DirectoryInfo[] y = j.GetDirectories();
            foreach (DirectoryInfo t in y)
            {
                listBox1.Items.Add(t);
            }
            FileInfo[] h = j.GetFiles(); 
            foreach (FileInfo o in h) 
            {
                listBox1.Items.Add(o);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '\\')  // удаляем слеши из адреса
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1); // удаляем символ
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            else if (textBox1.Text[textBox1.Text.Length - 1] != '\\')
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString())) == "")
            {
                textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                DirectoryInfo j = new DirectoryInfo(textBox1.Text);
                DirectoryInfo[] y = j.GetDirectories();
                foreach (DirectoryInfo t in y)
                {
                    listBox1.Items.Add(t);
                }
                FileInfo[] h = j.GetFiles();
                foreach (FileInfo o in h)
                {
                    listBox1.Items.Add(o);
                }

            }
            else
            {
                Process.Start(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()));
            }
        }
    }
    }

