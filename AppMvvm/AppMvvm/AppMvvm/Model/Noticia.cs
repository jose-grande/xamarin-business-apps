using System;
using System.Collections.Generic;
using System.Text;

namespace AppMvvm.Model
{
    public class Noticia
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        private string _cuerpo;

        public string Cuerpo
        {
            get { return _cuerpo; }
            set { _cuerpo = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private int _categoriaId;

        public int CategoriaId
        {
            get { return _categoriaId; }
            set { _categoriaId = value; }
        }


    }
}
