using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bad_text_editor
{
    public partial class Form1 : Form
    {
        string path;
        string text;
        public Form1(string fileName)
        {
            InitializeComponent();
            string filePath = fileName;
            if (File.Exists(filePath))
            {
                path = filePath;
                textBox1.Text = path;
                richTextBox1.Text = File.ReadAllText(filePath);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            text = richTextBox1.Text;
            path = textBox1.Text;
            try
            {
                StreamWriter sw = File.CreateText(path);
                sw.Close();
                File.WriteAllText(path, text);
                MessageBox.Show("File saved!");
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("File failed to save");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            richTextBox1.Text = File.ReadAllText(path);
        }
    }
}
