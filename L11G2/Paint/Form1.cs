using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics gfx;
        Point prevPoint;
        Point curPoint;
        Pen p;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.White);
            p = new Pen(Color.Green,5);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //gfx.DrawLine(p, prevPoint, curPoint);
           // gfx.DrawRectangle(p, GetRectangle(prevPoint, curPoint));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                curPoint = e.Location;

                gfx.DrawLine(p, prevPoint, curPoint);
                prevPoint = curPoint;

                pictureBox1.Refresh();
            }

            toolStripStatusLabel1.Text = e.Location.ToString();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           // e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //e.Graphics.DrawLine(p, prevPoint, curPoint);
          //  e.Graphics.DrawRectangle(p, GetRectangle(prevPoint, curPoint));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                gfx = Graphics.FromImage(bmp);
            }
        }
         
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog1.FileName);
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
            }
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle r = new Rectangle(Math.Min(p1.X, p2.X),
                                        Math.Min(p1.Y, p2.Y),
                                        Math.Abs(p1.X - p2.X),
                                        Math.Abs(p1.Y - p2.Y));
            return r;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
