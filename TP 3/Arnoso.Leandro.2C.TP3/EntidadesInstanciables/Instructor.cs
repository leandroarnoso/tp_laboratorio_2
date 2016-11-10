using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor : PersonaGimnasio
    {
        private const int CANT_CLASES = 2;

        #region Atributos

        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Constructores

        private Instructor()
        { }

        static Instructor()
        {
            Instructor._random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            for (int i = 0; i < CANT_CLASES; i++)
            {
                this._randomClases();
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Agrega una clase al azar a las clases del día del instructor.
        /// </summary>
        private void _randomClases()
        {
            Array clases = Enum.GetValues(typeof(Gimnasio.EClases));
            int indice = Instructor._random.Next(clases.Length);

            this._clasesDelDia.Enqueue((Gimnasio.EClases)clases.GetValue(indice));
        }
        #endregion

        #region Polimorfismos

        /// <summary>
        /// Expone los datos de un instructor incluyendo sus herencias).
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Muestra las clases del dia de un instructor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Gimnasio.EClases clase in this._clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos de un instructor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores Logicos

        /// <summary>
        /// Un instructor es igual a una clase, si y solo si, la clase esta en las clases del dia del instructor.
        /// </summary>
        /// <param name="i">Instructor a comprar.</param>
        /// <param name="clase">Clase a comprar.</param>
        /// <returns></returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            bool retorno = false;

            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Un instructor es distinto a una clase, si y solo si, la clase no esta en las clases del dia del instructor.
        /// </summary>
        /// <param name="i">Instructor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
