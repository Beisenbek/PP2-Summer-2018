using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L11G2
{
    public partial class Form1 : Form
    {
        int r = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Green);
            e.Graphics.DrawLine(p, 10, 10, 200, 200);

            e.Graphics.DrawEllipse(p, 100-r, 100-r, 30+r, 30+r);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 2;
            this.Refresh();
        }
    }
}
