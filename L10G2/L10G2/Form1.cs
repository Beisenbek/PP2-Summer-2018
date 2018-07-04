using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L10G2
{
    public delegate void MyDelegate(string x);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintToLabel("test");
            Thread t = new Thread(new ThreadStart(DoIt));
            t.Start();
            //p.Print("hello world!");
            
        }

        private void DoIt()
        {
            MyDelegate d = new MyDelegate(this.PrintToTextBox);
            d += PrintToLabel;
            Printer p = new Printer(d);
        }

        public void PrintToLabel(string msg)
        {
            label1.Text = msg;
        }

        public void PrintToTextBox(string msg)
        {
            textBox1.Text = msg;
        }
    }

    public class Printer
    {
        MyDelegate d;
        public Printer(MyDelegate d)
        {
            this.d = d;
        }
        public void Print(string message)
        {
            Thread.Sleep(3000);
            d.Invoke(message + "!" + message);
        }
    }
}
