using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Nº_1___Calculadora
{
    class Calculadora
    {
        #region METODOS

        /// <summary>
        /// Realiza la operacion matematica pedida entre dos numeros.
        /// </summary>
        /// <param name="numero1"> Primer numero a operar.</param>
        /// <param name="numero2"> Segundo numero a operar.</param>
        /// <param name="operador"> Operacion matematica a realizar</param>
        /// <returns> Retorna el resultado de la operacion matematica entre los dos numeros.</returns>
        public double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            operador = validarOperacion(operador);
            switch (operador)
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    if (numero2 != 0)
                        resultado = numero1 / numero2;
                    else
                        MessageBox.Show("Division por 0(Cero) invalida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Comprueba que el operador que se le pasa sea valido.
        /// </summary>
        /// <param name="operador"> Operador a validar.</param>
        /// <returns> Retorna el operador valido o el operador +(suma) en caso contrario.</returns>
        public string validarOperacion(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                MessageBox.Show("Operador invalido.\nPor defecto se usara el operador +(suma).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                operador = "+";
            }

            return operador;
        }

        #endregion
    }
}
