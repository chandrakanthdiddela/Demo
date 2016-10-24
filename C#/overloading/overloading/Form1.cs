using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace overloading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Emp
        {
            // int sal;
private   int p;
            //Emp(int x)
            //{
            //    sal =x;
            //}

public    Emp()
    {
        // TODO: Complete member initialization
    }

public    Emp(int p)
    {
        // TODO: Complete member initialization
this.p = p;
    }
public void print()
{
    MessageBox.Show("total" + p);
}
            
            public static Emp operator+ (Emp a, Emp b)
            {
                Emp x= new Emp();
                x.p = a.p + b.p;
                return x;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Emp e1 = new Emp(1000);
            Emp e2 = new Emp(2000);
            Emp e3 = new Emp(3000);
            Emp t = new Emp();
            t=e1+e2+e3;
            t.print();


        }
    }
}
