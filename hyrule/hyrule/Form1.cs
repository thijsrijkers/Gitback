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
    public partial class Form1 : Form
    {
        string filePathSave;
        int visible = 0;
        public class hyperlinks
        {
            public int hyperlink_id { get; set; }
            public string hyperlink_name { get; set; }
            public string hyperlink_link { get; set; }
        }

        List<hyperlinks> hll = new List<hyperlinks>();
        public Form1()
        {
            InitializeComponent();
            string[] files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"apploc\"));
            foreach (string file in files)
            {
                if (file.ToString().Equals("gitname.txt") || file.ToString().Equals("links.txt"))
                {
                    Console.WriteLine(file);
                }
                else
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
            }
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderColor = BackColor;
            button8.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button8.FlatAppearance.MouseOverBackColor = Color.Transparent;

                hyperlinks link1 = new hyperlinks();
                link1.hyperlink_id = 1;
                link1.hyperlink_name = "Reddit";
                link1.hyperlink_link = "www.reddit.com";
                hll.Add(link1);

                hyperlinks link2 = new hyperlinks();
                link2.hyperlink_id = 2;
                link2.hyperlink_name = "Mail";
                link2.hyperlink_link = "https://portal.office.com/";
                hll.Add(link2);

                hyperlinks link3 = new hyperlinks();
                link3.hyperlink_id = 3;
                link3.hyperlink_name = "Youtube";
                link3.hyperlink_link = "www.youtube.com";
                hll.Add(link3);

                hyperlinks link4 = new hyperlinks();
                link4.hyperlink_id = 4;
                link4.hyperlink_name = "Twitch";
                link4.hyperlink_link = "www.twitch.com";
                hll.Add(link4);

                listBox2.DataSource = hll;
                listBox2.DisplayMember = "hyperlink_name";
                listBox2.ValueMember = "hyperlink_id";

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt")))
            {
                Console.WriteLine("File Existed in Map");
                string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt"));
                textBox23.Text = text;
                pictureBox1.ImageLocation = "https://avatars.githubusercontent.com/" + text + "";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            panel22.Visible = false;
            panel24.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
        }

        private OpenFileDialog openFileDialog1;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            button2.Click += new EventHandler(Button2_Click);

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string targetPath = Path.Combine(Environment.CurrentDirectory, @"apploc\");
                string  result = Path.GetFileName(openFileDialog1.FileName);
                string destFile = System.IO.Path.Combine(targetPath, result);
                System.IO.File.Copy(filename, destFile, true);
            }
            Show_Click();
        }

        private void Show_Click()
        {
            listBox1.Items.Clear();
            string[] files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"apploc\"));
            foreach (string file in files)
            {
                if (file != "gitname")
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
            }
        }

        public void Show_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox3.Text = "";
            int i = 0;
            string targetPath = Path.Combine(Environment.CurrentDirectory, @"apploc\" + listBox1.Text);
            string text = System.IO.File.ReadAllText(targetPath);
            textBox3.Text = text;
            filePathSave = targetPath;

            System.IO.StreamReader file = new System.IO.StreamReader(filePathSave);
            while ((text = file.ReadLine()) != null)
            {
                textBox4.Text += i + 1 + "\n" + "\t";
                i++;
            }
            file.Close();
            
            //string targetPath = Path.Combine(Environment.CurrentDirectory, @"apploc\"+ listBox1.Text);
            //Console.WriteLine("" + targetPath + "");
            //System.Diagnostics.Process.Start(targetPath);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
        }

        private void panel10_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Click(object sender, EventArgs e)
        {
        }

        private void panel9_Click(object sender, EventArgs e)
        {
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel14_Click(object sender, EventArgs e)
        {
        }

        private void panel4_Click(object sender, EventArgs e)
        {
        }

        private void panel13_Click(object sender, EventArgs e)
        {
        }

        private void panel18_Click(object sender, EventArgs e)
        {
        }

        private void panel15_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (hyperlinks link in hll)
            {
                if (listBox2.SelectedValue.ToString() == link.hyperlink_id.ToString())
                {
                    listBox2.Text = link.hyperlink_link.ToString();
                    string url = link.hyperlink_link.ToString();
                    Process.Start("" + url + "");
                    Console.WriteLine(""+url+"");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt"));
            Process.Start("https://github.com/"+ text + "?tab=repositories");
        }

        private void TextBox25_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            TextWriter txt = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt"));
            txt.Write(textBox25.Text);
            txt.Close();
            string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt"));
            textBox23.Text = text;
            pictureBox1.ImageLocation = "https://avatars.githubusercontent.com/" + text + "";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void TextBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt"));
            textBox23.Text = text;
            Process.Start("https://github.com/" + text + "");
        }

        private void TextBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            textBox4.Text = "";
            openFileDialog1 = new OpenFileDialog();
            button2.Click += new EventHandler(Button2_Click);

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int i = 0;
                string filename = openFileDialog1.FileName;
                String result = Path.GetFileName(openFileDialog1.FileName);
                string text = System.IO.File.ReadAllText(filename);
                textBox3.Text = text;
                filePathSave = openFileDialog1.FileName;
  
                System.IO.StreamReader file = new System.IO.StreamReader(filePathSave);
                while ((text = file.ReadLine()) != null)
                {
                    textBox4.Text += i + 1 + "\n" + "\t";
                    i++;
                }
                file.Close();
            }
            Console.WriteLine(filePathSave);
            Console.WriteLine(filePathSave);
            Console.WriteLine(filePathSave);
            Console.WriteLine(filePathSave);
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            TextWriter txt = new StreamWriter(filePathSave);
            txt.Write(textBox3.Text);
            txt.Close();
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (visible == 0)
            {
                panel22.Visible = true;
                panel24.Visible = true;
                button2.Visible = true;
                listBox1.Visible = true;
                visible = 1;
            }
            else
            {
                panel22.Visible = false;
                panel24.Visible = false;
                button2.Visible = false;
                listBox1.Visible = false;
                visible = 0;
            }
        }
    }
}
