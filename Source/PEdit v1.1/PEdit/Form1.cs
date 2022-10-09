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
using PEdit;

namespace bad_text_editor
{
    public partial class Form1 : Form
    {
        string path;
        public Form1(string fileName)
        {
            InitializeComponent();
            string filePath = fileName;
            try
            {
              if (File.Exists(filePath))
              {
                    path = filePath;
                    richTextBox1.Text = File.ReadAllText(path);
              }
            }
            catch(IOException)
            {
                path = null;
                MessageBox.Show("File failed to open");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Plain Text|*.txt|C Source File|*.c|C++ Source File|*.cpp|Python Script|*.py|Rich Text File|*.rtf|Java Source Class|*.java|PEdit Text File|*.pedit|Markdown|*.md|JavaScript File|*.js|C# Source File|*.cs|C Header File|*.h|All Files|*";
                saveFileDialog1.Title = "Save As..";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                }
            }
            catch (IOException) { }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Plain Text|*.txt|C Source File|*.c|C++ Source File|*.cpp|Python Script|*.py|Rich Text File|*.rtf|Java Source Class|*.java|PEdit Text File|*.pedit|Markdown|*.md|JavaScript File|*.js|C# Source File|*.cs|C Header File|*.h|All Files|*";
                openFileDialog1.Title = "Open";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    path = openFileDialog1.FileName;
                }
            }
            catch(IOException)
            {
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (path != null)
                {
                    File.WriteAllText(path, richTextBox1.Text);
                    MessageBox.Show("File saved");
                }
                else
                {
                    saveFileDialog1.Filter = "Plain Text|*.txt|PEdit Text File|*.pedit";
                    saveFileDialog1.Title = "Save";
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName != "")
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File failed to save");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save your current file?", "PEdit", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (path == null)
                    {
                        saveFileDialog1.Filter = "Plain Text|*.txt|PEdit Text File|*.pedit";
                        saveFileDialog1.Title = "Save";
                        saveFileDialog1.ShowDialog();
                        if (saveFileDialog1.FileName != "")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                        }
                    }
                    else
                    {
                        File.WriteAllText(path, richTextBox1.Text);
                    }
                    richTextBox1.Text = "";
                    path = null;
                }
                catch (IOException)
                {}
            }
            else if (dialogResult == DialogResult.No)
            {
                richTextBox1.Text = "";
                path = null;
            }
        }

        private void aboutPEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
