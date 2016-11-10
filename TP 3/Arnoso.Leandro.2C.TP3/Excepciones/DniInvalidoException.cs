using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase;

        #region Constructores

        static DniInvalidoException()
        {
            DniInvalidoException.mensajeBase = "DNI invalido.";
        }

        public DniInvalidoException(Exception e)
            : this(e.Message, e)
        { }

        public DniInvalidoException(string message)
            : this(message, new Exception())
        { }

        public DniInvalidoException(string message, Exception e)
            : base(DniInvalidoException.mensajeBase + message, e)
        { }
        #endregion
    }
}
