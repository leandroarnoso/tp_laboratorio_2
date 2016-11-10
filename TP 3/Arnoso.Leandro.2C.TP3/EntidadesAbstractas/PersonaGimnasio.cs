using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        #region Atributos

        private int _identificador;
        #endregion

        #region Constructores

        protected PersonaGimnasio()
        { }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los de una PersonaGimnasio incluyendo su herencia.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NÚMERO: " + this._identificador);

            return sb.ToString();
        }

        /// <summary>
        /// Muestra las clases en las que participa una PersonaGimnasio.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Polimorfismos

        public override bool Equals(object obj)
        {
            return obj is PersonaGimnasio && this == (PersonaGimnasio)obj;
        }
        #endregion

        #region Operadores Logicos

        /// <summary>
        /// Dos PersonaGimnasio son iguales si, y solo si, sus IDs o DNIs son iguales.
        /// </summary>
        /// <param name="pg1">Primer PersonaGimnasio a comparar.</param>
        /// <param name="pg2">Segunda PersonaGimnasio a comprar.</param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return (pg1._identificador == pg2._identificador || pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// Dos PersonaGimnasio son distintas si, y solo si, sus IDs y DNIs son distintos.
        /// </summary>
        /// <param name="pg1">Primer PersonaGimnasio a comparar.</param>
        /// <param name="pg2">Segunda PersonaGimnasio a comprar.</param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
