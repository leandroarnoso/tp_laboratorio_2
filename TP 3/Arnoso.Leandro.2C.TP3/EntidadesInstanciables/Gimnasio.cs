using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;
using Excepciones;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        private const string FILE_NAME = "Gimnasio.xml";

        public enum EClases { CrossFit, Natacion, Pilates, Yoga }

        #region Atributos

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornadas;
        #endregion

        #region Constructores

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
        }

        public List<Instructor> Instrcutores
        {
            get { return this._instructores; }
        }

        public List<Jornada> Jornadas
        {
            get { return this._jornadas; }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los datos de un gimnasio en un archivo xml.
        /// </summary>
        /// <param name="gim">Gimnasio a guardar.</param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            try
            {
                Xml<Gimnasio> xml = new Xml<Gimnasio>();
                return xml.guardar(FILE_NAME, gim);
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
        /// Lee y recupera los datos de un gimnasio de un archivo xml.
        /// </summary>
        /// <returns></returns>
        public static Gimnasio Leer()
        {
            try
            {
                Gimnasio gim = null;
                Xml<Gimnasio> xml = new Xml<Gimnasio>();
                xml.leer(FILE_NAME, out gim);

                return gim;
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
        /// Expone los datos de un gimnasio y sus jornadas con sus respectivos instructores y alumnos y herencias.
        /// </summary>
        /// <param name="gim">Gimnasio a mostrar.</param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            for (int i = 0; i < gim._jornadas.Count; i++)
            {
                sb.Append(gim[i].ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Polimorfismos

        /// <summary>
        /// Muestra los datos de un gimnasio y todas sus jornadas.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        #endregion

        #region Indexador

        public Jornada this[int i]
        {
            get
            {
                Jornada j = null;

                if (i > -1 && i < this._jornadas.Count)
                    j = this._jornadas[i];

                return j;
            }
        }
        #endregion

        #region Operadores Logicos

        /// <summary>
        /// Un gimnasio es igual a un alumno si, y solo si, el alumno pertenece al gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g._alumnos)
            {
                if (item.Equals(a))
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Un gimnasio es distinto de un alumno si, y solo si, el alumno no pertenece al gimnasio.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un gimnasio es igual a una clase si, y solo si, el gimnasio tiene un instructor que de la clase. 
        /// En caso de tener un instructor lo retornara.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            Instructor instructor = null;

            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                {
                    instructor = item;
                    break;
                }
            }
            if (Object.Equals(instructor, null))
                throw new SinInstructorException();

            return instructor;
        }

        /// <summary>
        /// Un gimnasio es distinto a una clase si, y solo si, el gimnasio tiene un instructor que no de la clase. 
        /// En caso de tener un instructor lo retornara.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            Instructor instructor = null;

            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                {
                    instructor = item;
                    break;
                }
            }

            return instructor;
        }

        /// <summary>
        ///  Un gimnasio es igual a un instructor si, y solo si, el instructor pertenece al gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="i">Instructor a comparar.</param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool retorno = false;

            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        ///  Un gimnasio es distinto a un instructor si, y solo si, el instructor no pertenece al gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="i">Instructor a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }
        #endregion

        #region Operadores Aritmeticos

        /// <summary>
        /// Agrega un alumno al gimnasio si, y solo si, el alumno no este ya registrado en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio al que se le agregara el alumno.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g != a)
                g._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return g;
        }

        /// <summary>
        /// Agrega una jornada al gimnasio con un instructor y alumnos si, y solo si, tiene un instructor que de la clase.
        /// </summary>
        /// <param name="g">Gimnasio al que se le agregara la jornada.</param>
        /// <param name="clase">Clase de la jornada.</param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            try
            {
                Jornada j = new Jornada(clase, g == clase);
                foreach (Alumno item in g._alumnos)
                {
                    if (item == clase)
                        j += item;
                }
                g._jornadas.Add(j);

                return g;
            }
            catch (AlumnoRepetidoException e)
            {
                throw e;
            }
            catch (SinInstructorException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Agrega un instructor al gimnasio si, y solo si, este no este ya registrado en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio al que se le agregara el alumno.</param>
        /// <param name="i">Instructor a agregar.</param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
                g._instructores.Add(i);

            return g;
        }
        #endregion
    }
}
