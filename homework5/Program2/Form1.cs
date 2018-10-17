using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {

       public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics != null)
            {
                graphics.Clear(this.BackColor);
                graphics.Dispose();
            }
            graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
            

        private Graphics graphics;

        void drawCayleyTree (int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            Random random = new Random();

            double per1 = (double)(random.Next(59, 80)) / 100;
            double per2 = (double)(random.Next(59, 80)) / 100;
            Console.WriteLine(per1);
            Console.WriteLine(per2);
            double th1 = random.Next(25, 60) * Math.PI / 180;
            double th2 = random.Next(25, 60) * Math.PI / 180;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
            
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            Random random = new Random();
            int id = random.Next(0, 4);
            switch (id)
            {
                case 0:
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 1:
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 2:
                    graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 3:
                    graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }
    }
}
