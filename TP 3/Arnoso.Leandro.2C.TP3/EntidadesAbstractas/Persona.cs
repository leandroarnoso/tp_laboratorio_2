using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        #region Atributos

        private int _dni;
        private string _nombre;
        private string _apellido;
        private ENacionalidad _nacionalidad;
        #endregion

        #region Constructores

        protected Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Propiedades
        
        public int DNI
        {
            
            get { return this._dni; }
            set
            {
                try
                {
                    this._dni = this.ValidarDni(this._nacionalidad, value);
                }
                catch (DniInvalidoException)
                {
                    throw new NacionalidadInvalidaException();
                }
                catch (NacionalidadInvalidaException e)
                {
                    throw e;
                }
            }
        }

        public string StringToDni
        {
            set
            {
                try
                {
                    this._dni = this.ValidarDni(this._nacionalidad, value);
                }
                catch (DniInvalidoException)
                {
                    throw new NacionalidadInvalidaException();
                }
                catch (NacionalidadInvalidaException e)
                {
                    throw e;
                }
            }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set 
            { 
                this._nombre = this.ValidarNombreApellido(value);
                if (this._nombre == "")
                    Console.WriteLine("El nombre contiene caracteres invalidos");
            }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
                if (this._apellido == "")
                    Console.WriteLine("El apellido contiene caracteres invalidos");
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el DNI de una persona este en los limites correctos que le corresponden segun la nacionalidad
        /// de la persona.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI a validar.</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato > 0 && dato < 100000000)
            {
                if ((nacionalidad == ENacionalidad.Argentino && dato < 90000000) || (nacionalidad == ENacionalidad.Extranjero && dato > 89999999))
                    return dato;
                else
                    throw new NacionalidadInvalidaException();
            }
            else
                throw new DniInvalidoException("Fuera de rango [1 - 99.999.999].");
        }

        /// <summary>
        /// Valida que el DNI de una persona este tanto en el formato correcto como en los limites correctos segun 
        /// la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI a validar.</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return this.ValidarDni(nacionalidad, int.Parse(dato));
            }
            catch (NacionalidadInvalidaException e)
            {
                throw e;
            }
            catch (DniInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(e);
            }
        }

        /// <summary>
        /// Valida que la cadena pasada contenga solo letras o espacios.
        /// </summary>
        /// <param name="dato">Cadena a validar.</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            // Expresion regular que solo permite que una cadena contenga entre 2 a 40 caracteres y que ademas
            // solo este formada por letras minusculas o mayuscaulas entre la A y la Z, vocales con tildes
            // y espacios en blanco no consecutivos.
            Regex regEx = new Regex(@"^([a-zA-ZáÁéÉíÍóÓúÚ]\s?){2,40}$");

            if (!regEx.IsMatch(dato))
                dato = "";

            return dato;
        }
        #endregion

        #region Polimorfismos

        /// <summary>
        /// Muestra los datos de una persona excepto el DNI.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);

            return sb.ToString();
        }
        #endregion
    }
}
