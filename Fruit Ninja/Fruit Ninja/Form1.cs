using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using Fruit_Ninja.Properties;
using Microsoft.Win32.SafeHandles;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Fruit_Ninja
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        int score = 0;
        int misses = 0;
        int fruit1 = 0, fruit2 = 0, fruit3 = 0;
        Boolean running = true;
        Boolean sliceable1 = true, sliceable2 = true, sliceable3 = true;
        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer wmp1 = new WMPLib.WindowsMediaPlayer();
        Boolean flag = true;
        int highscore = int.Parse(Settings.Default["highscore"].ToString());
        int counter;

        public Form1()
        {
            wmp.URL = "start.mp3";
            InitializeComponent();
            this.Cursor = new Cursor(Properties.Resources.katana2.GetHicon());
            pictureBox1.Image = Properties.Resources.apple;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox2.Image = Properties.Resources.apple;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox3.Image = Properties.Resources.apple;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // make it full screen
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            // disable resize button
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // initial score
            toolStripStatusLabel1.Text = "Top Score: 0\n     Time: 0";
            toolStripStatusLabel2.Text = "HIGHSCORE: " + highscore;
            // play background music
            wmp1.controls.play(); 
            wmp1.URL = "background.mp3";
            wmp1.settings.setMode("loop", true);
        }
        
        void iteration()
        {
            if (running)
            {
                if (sliceable1)
                {
                    sliceable1 = false;
                    score++;
                    toolStripStatusLabel1.Text = "Top Score: " + score + "\n     Time: " + counter;
                    toolStripStatusLabel2.Text = "HIGHSCORE: " + highscore;
                    // sliced
                    if (fruit1 == 0) { pictureBox1.Image = Properties.Resources.jabka_s; score++; }
                    else if (fruit1 == 1) { pictureBox1.Image = Properties.Resources.banana_s; score += 2; }
                    else if (fruit1 == 2) { pictureBox1.Image = Properties.Resources.jagoda_s; score += 3; }
                    else if (fruit1 == 3) { pictureBox1.Image = Properties.Resources.praska_s;score += 4; }
                    if (fruit1 == 4) { pictureBox1.Image = Properties.Resources.lubenica_s; score += 5; }
                    // sound effect
                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                    sp.SoundLocation = "splatter.wav";
                    sp.Play();
                }
                if (sliceable2)
                {
                    sliceable2 = false;
                    score++;
                    toolStripStatusLabel1.Text = "Top Score: " + score + "\n     Time: " + counter;
                    toolStripStatusLabel2.Text = "HIGHSCORE: " + highscore;
                    // sliced
                    if (fruit2 == 0) pictureBox1.Image = Properties.Resources.jabka_s;
                    else if (fruit2 == 1) pictureBox1.Image = Properties.Resources.banana_s;
                    else if (fruit2 == 2) pictureBox1.Image = Properties.Resources.jagoda_s;
                    else if (fruit2 == 3) pictureBox1.Image = Properties.Resources.praska_s;
                    if (fruit2 == 4) pictureBox1.Image = Properties.Resources.lubenica_s;
                    // sound effect
                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                    sp.SoundLocation = "splatter.wav";
                    sp.Play();
                }
                if (sliceable3)
                {
                    sliceable3 = false;
                    score++;
                    toolStripStatusLabel1.Text = "Top Score: " + score + "\n     Time: " + counter;
                    toolStripStatusLabel2.Text = "HIGHSCORE: " + highscore;
                    // sliced
                    if (fruit3 == 0) pictureBox1.Image = Properties.Resources.jabka_s;
                    else if (fruit3 == 1) pictureBox1.Image = Properties.Resources.banana_s;
                    else if (fruit3 == 2) pictureBox1.Image = Properties.Resources.jagoda_s;
                    else if (fruit3 == 3) pictureBox1.Image = Properties.Resources.praska_s;
                    if (fruit3 == 4) pictureBox1.Image = Properties.Resources.lubenica_s;
                    // sound effect
                    System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                    sp.SoundLocation = "splatter.wav";
                    sp.Play();
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "GAME OVER\nTop Score: " + score + "\n     Time: " + counter;
                toolStripStatusLabel2.Text = "HIGHSCORE: " + highscore;
            }
        }

        void restart()
        {
            score = 0;
            misses = 0;
            toolStripStatusLabel1.Text = "Top Score: " + score + "\n     Time: " + counter;
            toolStripStatusLabel2.Text = "HIGHSCORE: " + highscore;
            running = true;
            wmp1.controls.play();
            wmp1.settings.setMode("loop", true);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // change fruit 
            int fruits = r.Next(0, 5);
            fruit1 = r.Next(0, 5);
            if (fruit1 == 0) pictureBox1.Image = Properties.Resources.apple;
            else if(fruit1 == 1) pictureBox1.Image = Properties.Resources.banana;
            else if(fruit1 == 2) pictureBox1.Image = Properties.Resources.basaha;
            else if(fruit1 == 3) pictureBox1.Image = Properties.Resources.peach;
            if(fruit1 == 4) pictureBox1.Image = Properties.Resources.sandia;
            sliceable1 = true;
            // new position section
            int x, y;
            x = r.Next(0, 1420);
            y = r.Next(0, 650);
            pictureBox1.Location = new Point(x, y);
            pictureBox3.Location = new Point(-200, -200);
            pictureBox2.Location = new Point(-200, -200);
            if(fruits == 2 || fruits == 3)
            {
                fruit2 = r.Next(0, 5);
                if (fruit2 == 0) pictureBox1.Image = Properties.Resources.apple;
                else if (fruit2 == 1) pictureBox1.Image = Properties.Resources.banana;
                else if (fruit2 == 2) pictureBox1.Image = Properties.Resources.basaha;
                else if (fruit2 == 3) pictureBox1.Image = Properties.Resources.peach;
                if (fruit2 == 4) pictureBox1.Image = Properties.Resources.sandia;
                sliceable2 = true;
                x = r.Next(0, 1420);
                y = r.Next(0, 650);
                pictureBox2.Location = new Point(x, y);
            }
            else if(fruits == 4)
            {
                fruit2 = r.Next(0, 5);
                if (fruit2 == 0) pictureBox1.Image = Properties.Resources.apple;
                else if (fruit2 == 1) pictureBox1.Image = Properties.Resources.banana;
                else if (fruit2 == 2) pictureBox1.Image = Properties.Resources.basaha;
                else if (fruit2 == 3) pictureBox1.Image = Properties.Resources.peach;
                if (fruit2 == 4) pictureBox1.Image = Properties.Resources.sandia;
                sliceable2 = true;
                x = r.Next(0, 1420);
                y = r.Next(0, 650);
                pictureBox2.Location = new Point(x, y);
                fruit3 = r.Next(0, 4);
                if (fruit3 == 0) pictureBox1.Image = Properties.Resources.apple;
                else if (fruit3 == 1) pictureBox1.Image = Properties.Resources.banana;
                else if (fruit3 == 2) pictureBox1.Image = Properties.Resources.basaha;
                else if (fruit3 == 3) pictureBox1.Image = Properties.Resources.peach;
                if (fruit3 == 4) pictureBox1.Image = Properties.Resources.sandia;
                sliceable3 = true;
                x = r.Next(0, 1420);
                y = r.Next(0, 650);
                pictureBox3.Location = new Point(x, y);
            }
            // game over section
            counter++;
            if (counter == 30) {
                timer1.Stop();
                wmp1.controls.stop();
                wmp.controls.play();
                toolStripStatusLabel1.Text = "GAME OVER\nTop Score: " + score + "\n     Time: " + counter ;
                running = false;
                if(score > highscore)
                {
                    highscore = score;
                    Settings.Default["highscore"] = score;
                    Settings.Default.Save();
                }
             // replay button section
                if(flag == true)
                {
                    Button button = new Button();
                    button.Text = "Play again";
                    button.Click += new System.EventHandler(this.button1_Click);
                    statusStrip1.Items.Add(new ToolStripControlHost(button));
                    flag = false;
                }
            }
            toolStripStatusLabel1.Text = "Top Score: " + score + "\n     Time: " + counter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            restart();
            counter = 0;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // red pill
            score = score * 2;
            toolStripStatusLabel1.Text = "Top Score: " + score + "\n     Misses: " + misses;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // blue pill
            score = score + 15;
            toolStripStatusLabel1.Text = "Top Score: " + score + "\n     Misses: " + misses;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            iteration();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            iteration();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            iteration();
        }
    }
}
