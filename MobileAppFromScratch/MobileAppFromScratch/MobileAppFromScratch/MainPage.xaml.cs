using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppFromScratch
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            //((Button)sender).Text = "Button clicked";
            //label1.Text = "Ha hecho click en el botón";
            string firstName = FirstNameLabel.Text;
            DateTime fechaNacimiento = DobDatePicker.Date;
            bool recibirNotificaciones = NotificationsSwitch.IsToggled;
            double salario = SalarySlider.Value;
            string tiposNotificaciones = NotificationTypeEditor.Text;

            string mensaje = $"Nombre: {firstName}\nFecha Nacimiento: {fechaNacimiento}"
                + $"\nRecibir Notificaciones: {recibirNotificaciones}"
                + $"\nSalario: {salario}"
                + $"\nTipos de notificaciones: {tiposNotificaciones}";
            await DisplayAlert("Información", mensaje, "Cerrar");
        }
    }
}
