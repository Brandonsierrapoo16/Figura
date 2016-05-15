using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        enum TipoFigura { Rectangulo, Circulo, Linea };

        private TipoFigura figura_actual;
        private List<Figura> rectangulos;
        public int ancho;
        public int largo;
        private Color color_contorno, color_relleno;
        Form2 FormaCaptura = new Form2();

        public Form1()
        {
            figura_actual = TipoFigura.Circulo;

            rectangulos = new List<Figura>();

            InitializeComponent();

            color_contorno = Color.Black;
            color_relleno = Color.LightGreen;
            largo = 40;
            ancho = 40;

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
                    Circulo c = new Circulo(e.X, e.Y, color_contorno, color_relleno, ancho, largo);
                    c.Draw(this);
                    rectangulos.Add(c);
                }
                else if (figura_actual == TipoFigura.Rectangulo)
                {
                    Rectangulo r = new Rectangulo(e.X, e.Y, color_contorno, color_relleno, ancho, largo);
                    r.Draw(this);
                    rectangulos.Add(r);
                }
                else if (figura_actual == TipoFigura.Linea)
                {

                    Linea l = new Linea(e.X, e.Y, color_contorno, color_relleno, ancho, largo);
                    l.Draw(this);
                    rectangulos.Add(l);
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
            this.lineaToolStripMenuItem.Checked = false;
            button3.Text = "Tamaño";
            figura_actual = TipoFigura.Rectangulo;
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = true;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = false;
            button3.Text = "Tamaño";
            figura_actual = TipoFigura.Circulo;
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectangulos.Sort();
            rectangulos.Reverse();


        }

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = true;
            button3.Text = "Coordenadas";
            figura_actual = TipoFigura.Linea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color_contorno = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (figura_actual == TipoFigura.Linea)
            {
                FormaCaptura.Text = "Coordenadas";
                FormaCaptura.lblAncho.Text = "X:";
                FormaCaptura.lblLargo.Text = "Y:";
            }
            else
            {
                FormaCaptura.Text = "Tamaño";
                FormaCaptura.lblAncho.Text = "Ancho:";
                FormaCaptura.lblLargo.Text = "Largo:";
            }
            if (FormaCaptura.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    largo = int.Parse(FormaCaptura.txtLargo.Text);
                    ancho = int.Parse(FormaCaptura.txtAncho.Text);

                }
                catch (Exception)
                {
                    MessageBox.Show("Error, porfavor vuelve a llenar los campos");
                    FormaCaptura.txtAncho.Clear();
                    FormaCaptura.txtLargo.Clear();
                    FormaCaptura.txtLargo.Focus();

                }
                FormaCaptura.txtAncho.Clear();
                FormaCaptura.txtLargo.Clear();
                FormaCaptura.txtLargo.Focus();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.rectangulos.Clear();
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                color_relleno = colorDialog2.Color;
            }
        }
    }
}
