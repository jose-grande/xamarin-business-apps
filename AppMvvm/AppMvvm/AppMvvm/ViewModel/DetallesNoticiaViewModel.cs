using AppMvvm.Infrastructure;
using AppMvvm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMvvm.ViewModel
{
    public class DetallesNoticiaViewModel
    {
        private IAlmacen _almacen;
        public int Id { get; set; }
        public Noticia Noticia { get; set; }

        public DetallesNoticiaViewModel(int id, IAlmacen almacen)
        {
            _almacen = almacen;
            Id = id;
            ConsultarNoticia();
        }
        public void ConsultarNoticia()
        {
            this.Noticia = _almacen.ConsultarNoticia(this.Id);
        }

    }
}
