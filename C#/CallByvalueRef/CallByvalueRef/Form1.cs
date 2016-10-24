using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CallByvalueRef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        class Test
        {
            public void swap( int x, ref int y)
            {
                int k = x;
                x = y;
                y = k;
            }
            public void add(int x,int y,out int z)
            {
                z = x + y;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test t = new Test() ;
            int a = 10, b = 20;
            t.swap(a, ref b);
            MessageBox.Show(a + " " + b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test t = new Test();
            int a1 = 10, b1 = 20,c1;
            t.add(a1, b1, out c1);
            MessageBox.Show("sum"+c1);
        } 


    }
}
