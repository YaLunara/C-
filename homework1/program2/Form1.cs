using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            double d1 = Double.Parse(s1);
            string s2 = textBox2.Text;
            double d2 = Double.Parse(s2);
            label3.Text = "the two-digit multiplication is:" + (d1 * d2);
        }
    }
}
