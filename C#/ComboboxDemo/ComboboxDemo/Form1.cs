using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ComboboxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent(); 
            string[] x=new string[]{"circle","ellipse","triangle"};
            //comboBox1.DataSource = x;
            for (int i = 0; i < x.Length; i++)
            {
                comboBox1.Items.Add(x[i]);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            int x = comboBox1.SelectedIndex;
            GraphicsPath g = new GraphicsPath();

            if (x == 0)
                g.AddEllipse(10, 10, 250, 250);
            else if (x == 1)
                g.AddEllipse(10, 10, 200, 500);
            else
            {
                g.AddLine(10, 10, 300, 500);
                g.AddLine(300, 500, 150, 100);
                g.AddLine(150, 100, 10, 10);
            }
            Region r = new Region(g);
            this.Region = r;
        }
    }
}
