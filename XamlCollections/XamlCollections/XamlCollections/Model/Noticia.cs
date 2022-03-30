using System;
using System.Collections.Generic;
using System.Text;

namespace XamlCollections.Model
{
    public class Noticia: ModelBase
    {
        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; NotifyPropertyChanged(nameof(Titulo)); }
        }
        private string _cuerpo;
        public string Cuerpo
        {
            get { return _cuerpo; }
            set { _cuerpo = value; NotifyPropertyChanged(nameof(Cuerpo)); }
        }
        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; NotifyPropertyChanged(nameof(Fecha)); }
        }

        public override string ToString()
        {
            return Titulo;// base.ToString();
        }
    }
}
