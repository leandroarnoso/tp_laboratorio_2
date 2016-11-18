using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Atributos

        private string _archivo;
        #endregion

        #region Constructores

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }
        #endregion

        #region Metodos

        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this._archivo, true, Encoding.UTF8))
                {
                    sw.WriteLine(datos);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(this._archivo, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                        datos.Add(sr.ReadLine());
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
