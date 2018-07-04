using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lec10
{
    public delegate void MyDelegate(string msg);


    public partial class Form1 : Form
    {
        Printer p;
        public Form1()
        {
            InitializeComponent();
            MyDelegate d = new MyDelegate(PrintToLabel);
            d += PrintToTextBox;
            p = new Printer(d);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Print("hello is printed");
        }

        void PrintToLabel(string msgFromObject)
        {
            label1.Text = msgFromObject;
        }

        void PrintToTextBox(string msgFromObject)
        {
            textBox1.Text = msgFromObject;
        }
    }

    class Printer
    {
        MyDelegate d;
        public Printer(MyDelegate d)
        {
            this.d = d;
        }

        public void Print(string msg)
        {
            d.Invoke(msg + "!!!!");
        }
    }
}
