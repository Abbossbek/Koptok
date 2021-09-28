using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koptok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int R, ok=0, st=0;
        private Random rn = new Random(); Timer t = new Timer();
        private int r, g, b, x=10, y=1, i=0, j=0;
        private Graphics gr; Pen p, pb; Brush br; Graphics[] tr;
        private bool xb=true, yb=true;
        private int[] ab, ba;
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(r, g, b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
                BackColor = Color.FromArgb(r, g, b);
                if (textBox1.Text != "" && textBox2.Text!="")
                {
                    ok++;
                    if (ok == 1)
                    {
                        button1.Text = "Clear";
                        button1.SendToBack();
                        pictureBox2.SendToBack();
                        label1.SendToBack();
                        textBox1.SendToBack();
                        label2.SendToBack();
                        textBox2.SendToBack();
                        R = Convert.ToInt32(textBox1.Text);
                        for (int tez = 0; tez < int.Parse(textBox2.Text); tez++)
                        {
                            t.Interval = 1;
                            t.Tick += new EventHandler(timer1_Tick);
                        }
                    }
                    tr = new Graphics[10000];
                    p = new Pen(Color.FromArgb(r, g, b),3);
                    br = new SolidBrush(Color.FromArgb(255-r, 255-g, 255-b));
                    r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
                    BackColor = Color.FromArgb(r, g, b);
                }
            }
            catch
            {
                textBox1.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < 1)
            {
                gr = pictureBox1.CreateGraphics();
                pb = new Pen(Color.White, 3);
                br = new SolidBrush(Color.White);
                gr.DrawEllipse(p, x, y, R, R);
                if (x == 0)
                {
                    xb = true;
                    r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
                    p = new Pen(Color.FromArgb(r, g, b),3);
                }
                if (x == pictureBox1.Width - R)
                {
                    xb = false;
                    r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
                    p = new Pen(Color.FromArgb(r, g, b),3);
                }
                if (y == 0)
                {
                    yb = true;
                    r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
                    p = new Pen(Color.FromArgb(r, g, b),3);
                }
                if (y == pictureBox1.Height - R)
                {
                    yb = false;
                    r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
                    p = new Pen(Color.FromArgb(r, g, b),3);
                }
                gr.DrawEllipse(pb, x, y, R, R);
                x = xb == true ? x + 1 : x - 1;
                y = yb == true ? y + 1 : y - 1;
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
            br = new SolidBrush(Color.FromArgb(255 - r, 255 - g, 255 - b));
            gr = pictureBox1.CreateGraphics();
            ab =new int[10000]; ba = new int[10000];
            for(int i=0; i<10000; i++)
            {
                ab[i]=rn.Next(10,200);
                ba[i]=rn.Next(10,200);
            }
            tr[j] = pictureBox1.CreateGraphics();
            r = rn.Next(0, 255); g = rn.Next(0, 255); b = rn.Next(0, 255);
            tr[j].FillRectangle(br, e.X, e.Y , ab[j], ba[j]);
            j++;
            st++;
        }
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (st == 1)
            {
                gr.DrawEllipse(p, e.X - R / 2, e.Y - R / 2, R, R);
            }
            else
            {
                if (e.X > R / 2 && e.Y > R / 2 && e.X < pictureBox1.Width - R / 2 && e.Y < pictureBox1.Height - R / 2)
                {
                    x = e.X - R / 2;
                    y = e.Y - R / 2;
                    p = new Pen(Color.FromArgb(r, g, b), 3);
                    br = new SolidBrush(Color.FromArgb(255 - r, 255 - g, 255 - b));
                    t.Start();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1))
                        textBox2.Focus();
                    else
                        button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                        button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }
    }
}
