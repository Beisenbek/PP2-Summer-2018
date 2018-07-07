using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L11
{
    public partial class Form1 : Form
    {
        Circle c = new Circle();
        public Form1()
        {
            InitializeComponent();
            c.r = 10;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red, 3);
            e.Graphics.DrawLine(p, 200, 100, 30, 30);

            e.Graphics.FillRectangle(p.Brush, 10, 10, 100, 100);

            e.Graphics.DrawEllipse(p, 300-c.r/2, 300-c.r/2, c.r * 2, c.r * 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c.r ++;
            this.Refresh();
        }
    }

    class Circle
    {
        public float r;
    }
}
