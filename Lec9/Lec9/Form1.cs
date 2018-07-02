using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lec9
{
    public partial class Form1 : Form
    {
        bool isOperationPressed = false;
        string o;
        string a;
        string b;

        public Form1()
        {
            InitializeComponent();
        }

        private void digitBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = textBox1.Text + btn.Text;
        }

        private void operationBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            isOperationPressed = true;
            o = btn.Text;
            a = textBox1.Text;
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            b = textBox1.Text;
            if (o == "+")
            {
                textBox1.Text = (int.Parse(a) + int.Parse(b)).ToString();
            }
            else if(o == "-")
            {
                textBox1.Text = (int.Parse(a) - int.Parse(b)).ToString();
            }
            isOperationPressed = false;
        }
    }
}
