using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        enum TipoFigura { Rectangulo, Circulo, Triangulo, Recta };
        Color color;
        private TipoFigura figura_actual;
        private List<Figura> rectangulos;


        public Form1()
        {
            figura_actual = TipoFigura.Circulo;
            this.color = Color.Black;
            rectangulos = new List<Figura>();
            InitializeComponent();
            circuloToolStripMenuItem.Checked = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {

                contextMenuStrip1.Show(this, e.X, e.Y);
            }
            else if (MouseButtons.Left == e.Button)
            {
                if (figura_actual == TipoFigura.Circulo)
                {
                    Circulo c = new Circulo(e.X, e.Y, this.color);
                    c.Draw(this);
                    rectangulos.Add(c);
                }
                else if (figura_actual == TipoFigura.Rectangulo)
                {
                    Rectangulo r = new Rectangulo(e.X, e.Y, this.color);
                    r.Draw(this);
                    rectangulos.Add(r);
                }

                else if (figura_actual == TipoFigura.Recta)
                {
                    Recta r = new Recta(e.X, e.Y, this.color);
                    r.Draw(this);
                    rectangulos.Add(r);
                }

                else if (figura_actual == TipoFigura.Triangulo)
                {
                    Triangulo r = new Triangulo(e.X, e.Y, this.color);
                    r.Draw(this);
                    rectangulos.Add(r);
                }

                
            }


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Polimorfismo
            foreach (Figura r in rectangulos)
                r.Draw(this);
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rectanguloToolStripMenuItem.Checked = true;
            this.circuloToolStripMenuItem.Checked = false;
            this.trianguloToolStripMenuItem.Checked = false;
            this.rectaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Rectangulo;
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = true;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.trianguloToolStripMenuItem.Checked = false;
            this.rectaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Circulo;
        }

        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.trianguloToolStripMenuItem.Checked = true;
            this.rectaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Triangulo;
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectangulos.Sort();
            rectangulos.Reverse();


        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;

            }
        }

        private void rectanguloToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void rectaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.trianguloToolStripMenuItem.Checked = false;
            this.rectaToolStripMenuItem.Checked = true;
            figura_actual = TipoFigura.Recta;

        }

        private void trianguloToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.trianguloToolStripMenuItem.Checked = true;
            this.rectaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Triangulo;
        }

        

        
    }

}
