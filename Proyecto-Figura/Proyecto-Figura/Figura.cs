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
        protected Color C, CR;
        protected Pen pluma;
        protected int A;
        protected int L;
        // protected int ancho, ancho2;
        // protected int largo, largo2;

        protected SolidBrush brocha;

        public Figura(int x, int y, Color c, Color cr, int a, int l)
        {
            X = x;
            Y = y;
            C = c;
            CR = cr;
            A = a;

            L = l;



            brocha = new SolidBrush(CR);
            pluma = new Pen(C, 4);

            //  Random rnd = new Random();
            //  ancho = rnd.Next(10,60);
            //  largo = ancho;
            // ancho2 = rnd.Next(10,100);
            //largo2 = rnd.Next(10,100);
        }

        public abstract void Draw(Form f);

        public int CompareTo(object obj)
        {

            return this.L.CompareTo(((Figura)obj).L);
        }
    }


    class Rectangulo : Figura
    {

        public Rectangulo(int x, int y, Color c, Color cr, int a, int l)
            : base(x, y, c, cr, a, l)
        {
        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawRectangle(pluma, this.X, this.Y, A, L);
            g.FillRectangle(brocha, this.X, this.Y, A, L);
        }

    }

    class Linea : Figura
    {

        public Linea(int x, int y, Color c, Color cr, int a, int l)
            : base(x, y, c, cr, a, l)
        {

        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawLine(pluma, this.X, this.Y, A, L);

        }

    }

    class Circulo : Figura
    {
        public Circulo(int x, int y, Color c, Color cr, int a, int l)
            : base(x, y, c, cr, a, l)
        {

        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawEllipse(pluma, this.X, this.Y, A, L);
            g.FillEllipse(brocha, this.X, this.Y, A, L);
        }





    }
}
