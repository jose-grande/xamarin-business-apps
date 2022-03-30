using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamlAndBinding.Model;

namespace XamlAndBinding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalInfoPage : ContentPage
    {
        Persona persona;
        public PersonalInfoPage()
        {
            InitializeComponent();
            persona = new Persona() { Nombre = "Maria", Apellido = "Sanchez" };
            BindingContext = persona;
            persona.PropertyChanged += PropiedadModificada;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (persona.Nombre == "Maria")
            {
                persona.Nombre = "Juana";
                persona.Apellido = "Hernanadez";
            }
            else
            {
                persona.Nombre = "Maria";
                persona.Apellido = "Sanchez";
            }
        }
        private void PropiedadModificada(object quienDisparoElEvento, PropertyChangedEventArgs args)
        {
            Debug.WriteLine($"Se modificó la propiedad: {args.PropertyName}");
        }
    }
}