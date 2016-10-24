using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleThreadDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Timeconsumingprocess();
        }

        void Timeconsumingprocess()
        {
            System.IO.FileStream lobjfilestream = new System.IO.FileStream(@"D:\Sample.txt", System.IO.FileMode.CreateNew);

            byte[] larrbyte = new byte[] { 12, 13, 14, 15, 16 };

            for (int i = 0; i < 100; i++)
            {
                lobjfilestream.Write(larrbyte,0,larrbyte.Length);
                lobjfilestream.Flush();
            }
            MessageBox.Show("Writing done");
        }
    }
}
