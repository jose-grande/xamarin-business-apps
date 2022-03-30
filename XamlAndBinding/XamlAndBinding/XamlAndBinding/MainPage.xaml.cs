using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlAndBinding
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SettingsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void SettingsWithBindingButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsWithBindingPage());
        }

        private async void PersonalInfoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonalInfoPage());
        }
    }
}
