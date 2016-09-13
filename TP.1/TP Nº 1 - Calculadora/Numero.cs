using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Nº_1___Calculadora
{
    class Numero
    {
        #region Atributos

        private double _numero;

        #endregion

        #region Constructores

        public Numero()
            : this(0)
        {
        }

        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        #endregion

        #region Metodos

        public double getNumero()
        {
            return this._numero;
        }

        private void setNumero(string numero)
        {
            this._numero = Numero.validarNumero(numero);
        }

        /// <summary>
        /// Valida que una cadena de caracteres sea un numero valido.
        /// </summary>
        /// <param name="numero"> Cadena de caracteres a validar.</param>
        /// <returns> Retorna el numero valido o 0(cero) en caso contrario.</returns>
        private static double validarNumero(string numero)
        {
            double aux;

            if (!double.TryParse(numero, out aux))
            {
                MessageBox.Show("Numero invalido.\nPor defecto se lo tomara como 0(cero).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                aux = 0;
            }

            return aux;
        }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Numero numero1, double numero2)
        {
            return numero1.getNumero() == numero2;
        }

        public static bool operator !=(Numero numero1, double numero2)
        {
            return !(numero1 == numero2);
        }

        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.getNumero() + numero2.getNumero();
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.getNumero() - numero2.getNumero();
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.getNumero() * numero2.getNumero();
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            return numero1.getNumero() / numero2.getNumero();
        }

        #endregion

    }
}
