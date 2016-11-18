using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public delegate void DownloadProgressChanged(int progreso);
        public event DownloadProgressChanged ProgresoDescarga;

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                this.ProgresoDescarga(e.ProgressPercentage);
            }
            catch (Exception)
            {
                
            }
        }


        public delegate void DownloadCompleted(string html);
        public event DownloadCompleted DescargaCompletada;

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                this.DescargaCompletada(this.html);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
