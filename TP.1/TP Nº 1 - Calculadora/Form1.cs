using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Nº_1___Calculadora
{
    public partial class FrmCalculadora : Form
    {
        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void Operar(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(this.txtNumero1.Text);
            this.txtNumero1.Text = numero1.getNumero().ToString();
            Numero numero2 = new Numero(this.txtNumero2.Text);
            this.txtNumero2.Text = numero2.getNumero().ToString();
            Calculadora calculadora = new Calculadora();
            string operador = this.cmbOperacion.Text;

            lblResultado.Text = "Resultado: " + calculadora.operar(numero1, numero2, operador).ToString();
        }

        private void Limpiar(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = "";
            this.lblResultado.Text = "Resultado:";
        }
    }
}
