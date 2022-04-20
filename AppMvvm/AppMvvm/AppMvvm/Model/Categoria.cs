using System;
using System.Collections.Generic;
using System.Text;

namespace AppMvvm.Model
{
    public class Categoria
    {
        private int _categoriaId;

        public int CategoriaId
        {
            get { return _categoriaId; }
            set { _categoriaId = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

    }
}
