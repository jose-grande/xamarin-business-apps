using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;
using System.IO;

namespace EssentialsTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetLocationButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                Location lastLocation = await Geolocation.GetLastKnownLocationAsync();
                //Geolocation.GetLocationAsync();
                string text = $"Latitud: {lastLocation.Latitude}; Longitud: {lastLocation.Longitude}";
                LocationLabel.Text = text;
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.Fail(ex.Message);
            }
            catch(FeatureNotEnabledException ex)
            {
                Debug.Fail(ex.Message);
            }
            catch(Exception ex)
            {
                Debug.Fail(ex.Message);
            }
            
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileResult photo = await MediaPicker.CapturePhotoAsync();
                //FileSystem.AppDataDirectory
                var filePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var photoStream = await photo.OpenReadAsync())
                {
                    using (var stream = File.OpenWrite(filePath))
                    {
                        await photoStream.CopyToAsync(stream);
                    }
                }
                PhotoPathLabel.Text = filePath;

                CameraPictureImage.Source = ImageSource.FromFile(filePath);
            }
            catch (FeatureNotSupportedException ex)
            {

                Debug.Fail(ex.Message);
            }
            catch(PermissionException ex)
            {
                Debug.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
        }

        private async void SayHelloButton_Clicked(object sender, EventArgs e)
        {
            await TextToSpeech.SpeakAsync("Hola mundo");
        }
    }
}
