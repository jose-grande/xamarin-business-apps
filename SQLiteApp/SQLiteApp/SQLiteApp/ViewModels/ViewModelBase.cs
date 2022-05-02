using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SQLiteApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public string TituloPagina { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
