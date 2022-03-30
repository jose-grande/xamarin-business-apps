using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamlAndBinding.Model
{
    public class Persona: INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre { get { return _nombre; } set { _nombre = value; NotifyPropertyChanged(nameof(Nombre)); } }
        
        private string _apellido;
        public string Apellido { get { return _apellido; } set { _apellido = value;NotifyPropertyChanged(nameof(Apellido)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
