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
                if (file == Path.Combine(Environment.CurrentDirectory, @"apploc\gitnameaccount.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\gitname.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link1.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link2.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link3.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link4.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\xp.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\level.txt"))
                {
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
            hll.Clear();
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link1.txt")) && File.Exists(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link2.txt")) && File.Exists(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link3.txt")) && File.Exists(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link4.txt")))
            {
                hyperlinks link1 = new hyperlinks();

                link1.hyperlink_id = 1;
                string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link1.txt"));
                link1.hyperlink_name = text;
                link1.hyperlink_link = text;
                hll.Add(link1);

                hyperlinks link2 = new hyperlinks();
                link2.hyperlink_id = 2;
                string text2 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link2.txt"));
                link2.hyperlink_name = text2;
                link2.hyperlink_link = text2;
                hll.Add(link2);

                hyperlinks link3 = new hyperlinks();
                link3.hyperlink_id = 3;
                string text3 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link3.txt"));
                link3.hyperlink_name = text3;
                link3.hyperlink_link = text3;
                hll.Add(link3);

                hyperlinks link4 = new hyperlinks();
                link4.hyperlink_id = 4;
                string text4 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link4.txt"));
                link4.hyperlink_name = text4;
                link4.hyperlink_link = text4;
                hll.Add(link4);

                listBox2.DataSource = hll;
                listBox2.DisplayMember = "hyperlink_name";
                listBox2.ValueMember = "hyperlink_id";
            }

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitnameaccount.txt")))
            {
                string texttext = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitnameaccount.txt"));
                textBox23.Text = texttext;
                pictureBox1.ImageLocation = "https://avatars.githubusercontent.com/" + texttext + "";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt")))
            {
                Console.WriteLine("File Existed in Map");
                string textsearch = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt"));
                textBox5.Text = textsearch;
                pictureBox3.ImageLocation = "https://avatars.githubusercontent.com/" + textsearch + "";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            string level = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
            xpcheck();
            textBox14.Text = level;

            panel8.Visible = false;
            panel22.Visible = false;
            panel24.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
        }

        private void xpcheck()
        {
            string xp = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            int xpint = System.Convert.ToInt32(xp);
            panel16.Size = new Size(xpint, panel16.Width);
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
                if (file == Path.Combine(Environment.CurrentDirectory, @"apploc\gitnameaccount.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\gitname.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link1.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link2.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link3.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\link4.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\xp.txt") || file == Path.Combine(Environment.CurrentDirectory, @"apploc\level.txt"))
                {
                }
                else
                {
                    Console.WriteLine(file);
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
            textBox5.Text = text;
            pictureBox3.ImageLocation = "https://avatars.githubusercontent.com/" + text + "";
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            panel8.Visible = true;

            string xp = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            int xpint = System.Convert.ToInt32(xp);
            xpint += 10;
            if (xpint >= 235)
            {
                string level = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                int levelcap = System.Convert.ToInt32(level);
                levelcap += 1;
                TextWriter txt3 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                txt3.Write(levelcap);
                txt3.Close();
                xpint = 0;
            }
            TextWriter txt2 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            txt2.Write(xpint);
            txt2.Close();
            string level2 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
            textBox14.Text = level2;
            xpcheck();
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
            string xp = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            int xpint = System.Convert.ToInt32(xp);
            xpint += 10;
            if (xpint >= 235)
            {
                string level = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                int levelcap = System.Convert.ToInt32(level);
                levelcap += 1;
                TextWriter txt = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                txt.Write(levelcap);
                txt.Close();
                xpint = 0;
            }
            TextWriter txt2 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            txt2.Write(xpint);
            txt2.Close();
            string level2 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
            textBox14.Text = level2;
            xpcheck();
        }

        private void HandleScroll(Object sender, ScrollEventArgs e)
        {

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

            string xp = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            int xpint = System.Convert.ToInt32(xp);
            xpint += 10;
            if (xpint >= 235)
            {
                string level = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                int levelcap = System.Convert.ToInt32(level);
                levelcap += 1;
                TextWriter txt3 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                txt3.Write(levelcap);
                txt3.Close();
                xpint = 0;
            }
            TextWriter txt2 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            txt2.Write(xpint);
            txt2.Close();
            string level2 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
            textBox14.Text = level2;
            xpcheck();
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

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitname.txt"));
            Process.Start("https://github.com/" + text + "?tab=repositories");
            string xp = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            int xpint = System.Convert.ToInt32(xp);
            xpint += 10;
            if (xpint >= 235)
            {
                string level = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                int levelcap = System.Convert.ToInt32(level);
                levelcap += 1;
                TextWriter txt3 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                txt3.Write(levelcap);
                txt3.Close();
                xpint = 0;
            }
            TextWriter txt2 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            txt2.Write(xpint);
            txt2.Close();
            string level2 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
            textBox14.Text = level2;
            xpcheck();
        }

        private void Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            panel12.Visible = false;
            if (panel13.Visible)
            {
                panel13.Visible = false;
            }
            else
            {
                panel13.Visible = true;
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
            panel12.Visible = false;
            Process.Start("https://github.com/thijsrijkers/Gitback");
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            string xp = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            int xpint = System.Convert.ToInt32(xp);
            xpint += 10;
            if(xpint >= 235)
            {
                string level = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                int levelcap = System.Convert.ToInt32(level);
                levelcap += 1;
                TextWriter txt = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
                txt.Write(levelcap);
                txt.Close();
                xpint = 0;
            }
            TextWriter txt2 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "xp.txt"));
            txt2.Write(xpint);
            txt2.Close();
            string level2 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "level.txt"));
            textBox14.Text = level2;
            xpcheck();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void Button16_Click(object sender, EventArgs e)
        {
                TextWriter txt = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitnameaccount.txt"));
                txt.Write(textBox7.Text);
                txt.Close();
                string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "gitnameaccount.txt"));
                textBox23.Text = text;
                pictureBox1.ImageLocation = "https://avatars.githubusercontent.com/" + text + "";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                panel12.Visible = false;
        }

        private void Panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button13_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
            if (panel12.Visible)
            {
                panel12.Visible = false;
            }
            else
            {
                panel12.Visible = true;
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            TextWriter txt = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link1.txt"));
            txt.Write(textBox8.Text);
            txt.Close();
            TextWriter txt2 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link2.txt"));
            txt2.Write(textBox9.Text);
            txt2.Close();
            TextWriter txt3 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link3.txt"));
            txt3.Write(textBox10.Text);
            txt3.Close();
            TextWriter txt4 = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link4.txt"));
            txt4.Write(textBox11.Text);
            txt4.Close();

            hll.Clear();

            hyperlinks link1 = new hyperlinks();
            link1.hyperlink_id = 1;
            string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link1.txt"));
            link1.hyperlink_name = text;
            link1.hyperlink_link = text;
            hll.Add(link1);

            hyperlinks link2 = new hyperlinks();
            link2.hyperlink_id = 2;
            string text2 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link2.txt"));
            link2.hyperlink_name = text2;
            link2.hyperlink_link = text2;
            hll.Add(link2);

            hyperlinks link3 = new hyperlinks();
            link3.hyperlink_id = 3;
            string text3 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link3.txt"));
            link3.hyperlink_name = text3;
            link3.hyperlink_link = text3;
            hll.Add(link3);

            hyperlinks link4 = new hyperlinks();
            link4.hyperlink_id = 4;
            string text4 = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"apploc\" + "link4.txt"));
            link4.hyperlink_name = text4;
            link4.hyperlink_link = text4;
            hll.Add(link4);

            panel13.Visible = false;
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel16_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
