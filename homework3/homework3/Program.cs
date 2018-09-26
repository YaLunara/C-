using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework3
{
    interface Chart
    {
        void display();
    }
    class Triangle : Chart
    {
        double bottom, height, area;
        public Triangle()
        {
            this.bottom = 5.8;
            this.height = 6.4;
            this.area = bottom * height / 2;
        }
        public void display()
        {
            Console.WriteLine("the area of this triangle is:" + this.area);
        }
    }
    class Circle : Chart
    {
        double r, area;
        public Circle()
        {
            this.r = 9;
            this.area = Math.PI * r * r;
        }
        public void display()
        {
            Console.WriteLine("the area of this circle is:" + this.area);
        }
    }
    class Square : Chart
    {
        double side, area;
        public Square()
        {
            this.side = 4.3;
            this.area = side * side;
        }
        public void display()
        {
            Console.WriteLine("the area of this square is:" + this.area);
        }
    }
    class Rectangle : Chart
    {
        double width, length, area;
        public void display()
        {
            this.width = 3.2;
            this.length = 4.1;
            this.area = width * length;
        }
    }
    class ChartFactory
    {
        public static Chart GetChart(string type)
        {
            Chart chart = null;
            if (type.Equals("triangle"))
            {
                chart = new Triangle();
            }
            else if (type.Equals("circle"))
            {
                chart = new Circle();
            }
            else if (type.Equals("square"))
            {
                chart = new Square();
            }
            else if (type.Equals("rectangle"))
            {
                chart = new Rectangle();
            }
            return chart;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Chart chart_1 = ChartFactory.GetChart("triangle");
            chart_1.display();
            Chart chart_2 = ChartFactory.GetChart("circle");
            chart_2.display();
            Chart chart_3 = ChartFactory.GetChart("square");
            chart_3.display();
            Chart chart_4 = ChartFactory.GetChart("rectangle");
            chart_4.display();
        }
    }
}
