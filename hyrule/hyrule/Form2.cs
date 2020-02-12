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
using System.Security;
using System.Collections;
using System.Diagnostics;
using System.Threading;


namespace hyrule
{
    public partial class Form2 : Form
    {
        string filePathSave;
        public Form2()
        {
            InitializeComponent();
            string[] files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Repos\"));
            foreach (string file in files)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
            panel4.Visible = false;
            richTextBox1.Visible = false;
            textBox5.Visible = false;
        }

        private OpenFileDialog openFileDialog1;
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            Form1 Check = new Form1();
            Check.Show();
            Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        var path = fbd.SelectedPath;

                        string folder = Path.GetFileName(fbd.SelectedPath);
                        TextWriter txt = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"Repos\" + folder +".txt"));
                        txt.Write(path);
                        txt.Close();
                    }
                }
                listBox1.Items.Clear();
                string[] files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Repos\"));
                foreach (string file in files)
                {
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            listBox2.Items.Clear();
            int i = 0;
            string targetPath = Path.Combine(Environment.CurrentDirectory, @"Repos\" +listBox1.Text+".txt");
            string text = System.IO.File.ReadAllText(targetPath);
            string result = Path.GetFileName(text);
            textBox2.Text = result;
            filePathSave = text;

            string targetPath2 = Path.Combine(Environment.CurrentDirectory, @"Commits\" + listBox1.GetItemText(listBox1.SelectedItem)+".txt");
            if (File.Exists(targetPath))
            {
                DirectoryInfo dinfo = new DirectoryInfo(filePathSave);
                FileInfo[] Files = dinfo.GetFiles();
                foreach (FileInfo file in Files)
                {
                    listBox2.Items.Add(file.Name);
                }
                if (File.Exists(targetPath2))
                {
                    string text2 = System.IO.File.ReadAllText(targetPath2);
                    richTextBox1.Text = "";
                    richTextBox1.Text = text2;
                    richTextBox1.Visible = true;
                    textBox5.Visible = true;
                }
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string targetPath = ""+ filePathSave + "\\" + listBox2.GetItemText(listBox2.SelectedItem)+"";
            Form1 Check = new Form1();
            Check.Show();
            Check.repos_Direct(targetPath);
            Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
                panel4.Visible = true;
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            string reposName = textBox2.Text;

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, @"Commits\" + reposName+ ".txt")))
            {

                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(Path.Combine(Environment.CurrentDirectory, @"Commits\" + reposName+ ".txt")))
                {
                    sw.WriteLine(textBox4.Text + "\n" + "\t");
                }
            }
            else
            {
                TextWriter txt = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"Commits\" + reposName+ ".txt"));
                txt.Write(textBox4.Text + "\n" + "\t");
                txt.Close();
            }
            string targetPath2 = Path.Combine(Environment.CurrentDirectory, @"Commits\" + listBox1.GetItemText(listBox1.SelectedItem) + ".txt");
            string text2 = System.IO.File.ReadAllText(targetPath2);
            richTextBox1.Text = "";
            richTextBox1.Text = text2;
            panel4.Visible = false;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
