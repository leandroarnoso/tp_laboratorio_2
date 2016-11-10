using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta { AlDia, Deudor, MesPrueba }
        
        #region Atributos

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region Constructores

        private Alumno()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Polimorfismos

        /// <summary>
        /// Expone los datos de un alumno incluyendo sus herencias.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            string estadoCuenta = "Deudor";
            switch (this._estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    estadoCuenta = "Cuota al día";
                    break;
                case EEstadoCuenta.MesPrueba:
                    estadoCuenta = "Mes de prueba";
                    break;
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + estadoCuenta);
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Muestra la clase en la que esta registrado el alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma;
        }

        /// <summary>
        /// Muestra los datos de un alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores Logicos

        /// <summary>
        /// Un alumno es igual a una clase, si y solo si, el alumno toma esa clase y no es deudor.
        /// </summary>
        /// <param name="a">Alumno a comprar.</param>
        /// <param name="clase">Clase a comprar.</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            return !(a != clase || a._estadoCuenta == EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Un alumno es distinto a una clase, si y solo si, el alumno no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno a comprar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return a._claseQueToma != clase;
        }
        #endregion
    }
}
