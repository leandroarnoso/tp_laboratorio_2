using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private const string FILE_NAME = "Jornada.txt";

        #region Atributos

        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        #endregion

        #region Constructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
        }

        public Gimnasio.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Instructor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los datos de una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guarda.</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                return txt.guardar(FILE_NAME, jornada.ToString());
            }
            catch (ArchivosException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee los datos de una jornada en un solo string para poder mostrarlo.
        /// </summary>
        /// <param name="datos">Cadena de caracteres que contendra los datos de la jornada.</param>
        /// <returns></returns>
        public static bool Leer(out string datos)
        {
            try
            {
                Texto txt = new Texto();
                txt.leer(FILE_NAME, out datos);

                return true;
            }
            catch (ArchivosException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        #endregion

        #region Polimorfismos

        /// <summary>
        /// Muestra los datos de una jornada junto con los datos del instructor y los alumnos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this._clase, this._instructor);
            if (this._alumnos.Count > 0)
            {
                sb.AppendLine("ALUMNOS:");
                for (int i = 0; i < this._alumnos.Count; i++)
                {
                    sb.AppendLine(this[i].ToString());
                }
            }
            else
            {
                sb.AppendLine("CLASE SIN ALUMNOS");
            }
            sb.AppendLine("<------------------------------------------------>\n");

            return sb.ToString();
        }
        #endregion

        #region Indexador

        public Alumno this[int i]
        {
            get
            {
                Alumno a = null;

                if (i > -1 && i < this._alumnos.Count)
                    a = this._alumnos[i];

                return a;
            }
        }
        #endregion

        #region Operadores Logicos

        /// <summary>
        /// Una jornada es igual a un alumno si, y solo si, el alumno participa de la jornada.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            for (int i = 0; i < j._alumnos.Count; i++)
            {
                if (j[i].Equals(a))
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Una jornada es distinta a un alumno si, y solo si, el alumno no participa de la jornada.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        #endregion

        #region Operadores Aritmeticos

        /// <summary>
        /// Agrega un alumno a la jornada si, y solo si, este no se encuentra ya registrado en la jornada.
        /// </summary>
        /// <param name="j">Jornada a la que se le agregara el alumno.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return j;
        }
        #endregion
    }
}
