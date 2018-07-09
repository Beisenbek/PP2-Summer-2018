using PaintApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L12
{
    enum DrawMode
    {
        Pen,
        Fill
    }
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics gfx;
        Point prevPoint;
        Point currentPoint;
        Pen p;
        DrawMode dmode = DrawMode.Pen;


        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.White);

            p = new Pen(Color.Green);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
            if(dmode == DrawMode.Fill)
            {
                MapFill mfill = new MapFill();
                mfill.Fill(gfx, e.Location, p.Color, ref bmp);
                pictureBox1.Image = bmp;
                gfx = Graphics.FromImage(bmp);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dmode == DrawMode.Pen)
            {
                if (e.Button == MouseButtons.Left)
                {
                    currentPoint = e.Location;
                    gfx.DrawLine(p, prevPoint, currentPoint);
                    prevPoint = currentPoint;
                    pictureBox1.Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dmode = DrawMode.Pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dmode = DrawMode.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }
    }
}
