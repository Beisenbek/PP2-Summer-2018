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

namespace Lec12G2
{
    enum Mode
    {
        Fill,
        Pen
    }

    public partial class Form1 : Form
    {

        Bitmap bmp;
        Graphics gfx;
        Pen p;
        Mode mode;
        Point prevPoint;

        public Form1()
        {
            InitializeComponent();
            mode = Mode.Pen;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            p = new Pen(Color.Black);
            gfx.Clear(Color.White);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
            if(mode == Mode.Fill)
            {
                MapFill mf = new MapFill();
                mf.Fill(gfx, e.Location, p.Color, ref bmp);
                pictureBox1.Image = bmp;
                gfx = Graphics.FromImage(bmp);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                gfx.DrawLine(p,prevPoint, e.Location);
                prevPoint = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mode = Mode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = Mode.Pen;
        }
    }
}
