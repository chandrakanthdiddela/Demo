using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBackgroundChange
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

        private void button1_Click(object sender, EventArgs e)
        {
            int no1 = int.Parse(textBox1.Text);
            int no2 = int.Parse(textBox2.Text);
            if (no1 > no2)
            {
                this.BackColor = Color.GreenYellow;
            }
            else
            {
                this.BackColor = Color.Indigo;
            }
        }
    }
}
