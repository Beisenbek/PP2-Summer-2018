using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L9G2
{
    public partial class Form1 : Form
    {
        string a, b;
        string o;
        bool isOperationPressed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpBtnClcl(object sender, EventArgs e)
        {
            isOperationPressed = true;
            a = textBox1.Text;
            textBox1.Text = "";
            o = (sender as Button).Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            b = textBox1.Text;
            if(o == "+")  textBox1.Text = (int.Parse(a) + int.Parse(b)).ToString();
            if(o == "-") textBox1.Text = (int.Parse(a) - int.Parse(b)).ToString();
        }

        private void DigitBtnClck(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(btn.Text);
            textBox1.Text = textBox1.Text + btn.Text;
        }
    }
}
