using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{


    public partial class Form1 : Form
    {
        Brain b;
        public Form1()
        {
            InitializeComponent();
            b = new Brain(DisplayInfo);
        }

        void DisplayInfo(string text)
        {
            textBox1.Text = text;
        }

        void BtnPressed(object sender, EventArgs e)
        {
            b.Process((sender as Button).Text);
        }
    }

    public delegate void DisplayInfoDelegate(string text);

}
