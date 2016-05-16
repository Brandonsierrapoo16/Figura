using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    abstract class Figura : IComparable
    {
        protected int X;
        protected int Y;
        protected Pen pluma;
        protected int ancho;
        protected int largo;
        protected Color color;
        protected SolidBrush brocha;

        public Figura(int x, int y, Color color)
        {
            X = x;
            Y = y;
            brocha = new SolidBrush(color);
            pluma = new Pen(color, 2);
            this.color = Color.Black;
            Random rnd = new Random();
            ancho = rnd.Next(10, 60);
            largo = ancho;
        }

        public abstract void Draw(Form f);

        public int CompareTo(object obj)
        {

            return this.largo.CompareTo(((Figura)obj).largo);
        }
    }


    class Rectangulo : Figura
    {
        public Rectangulo(int x, int y, Color color)
            : base(x, y, color)
        {
        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawRectangle(pluma, this.X, this.Y, ancho, largo);
            g.FillRectangle(brocha, this.X, this.Y, ancho, largo);
        }

    }

    class Circulo : Figura
    {
        public Circulo(int x, int y, Color color)
            : base(x, y, color)
        {

        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawEllipse(pluma, this.X, this.Y, ancho, largo);
            g.FillEllipse(brocha, this.X, this.Y, ancho, largo);
        }
    }

        class Triangulo : Figura
        {
            public Triangulo(int x, int y, Color color)
                : base(x, y, color)
            {

            }

            public override void Draw(Form f)
            {
                Graphics g = f.CreateGraphics();
                g.DrawLine(pluma, new Point(this.X + 0, this.Y + 50), new Point(this.X + 50, this.Y + 0));
                g.DrawLine(pluma, new Point(this.X + 50, this.Y + 0), new Point(this.X + 50, this.Y + 50));
                g.DrawLine(pluma, new Point(this.X + 50, this.Y + 50), new Point(this.X + 0, this.Y + 50));
            }

        }

        class Recta : Figura
        {
            public Recta(int x, int y, Color color)
                : base(x, y, color)
            {

            }

            public override void Draw(Form f)
            {
                Graphics g = f.CreateGraphics();
                g.DrawLine(pluma, this.X, this.Y, ancho, largo);
            }

        }

    
}


