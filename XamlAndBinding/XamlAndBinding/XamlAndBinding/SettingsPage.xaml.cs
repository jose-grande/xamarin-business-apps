using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlAndBinding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void RotationSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var rotation = RotationSlider.Value;
            RotationValueLabel.Text = rotation.ToString();
            RotatedLabel.Rotation = rotation;
        }
    }
}