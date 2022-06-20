using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace EssentialsTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var location = await Geolocation.GetLastKnownLocationAsync();
            var mapSpan = new MapSpan(new Position(location.Latitude, location.Longitude), 0.05, 0.05);
            mapControl.MoveToRegion(mapSpan);
        }

        private void mapControl_MapClicked(object sender, MapClickedEventArgs e)
        {
            Pin pin = new Pin
            {
                Position=e.Position,
                Label="Lugar elegido",
                Type=PinType.Place
            };
            mapControl.Pins.Add(pin);
        }
    }
}