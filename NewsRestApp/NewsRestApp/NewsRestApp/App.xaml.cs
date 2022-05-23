using NewsRestApp.Model;
using NewsRestApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsRestApp
{
    public partial class App : Application
    {
        private static INewsWebService _service;
        public static INewsWebService Service => _service == null ? (_service = new NewsWebService()) : _service;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //Service = new NewsWebService();
            ////Service.Consultar();
            //List<Noticia> noticias = Service.Consultar();
            //foreach (var item in noticias)
            //{
            //    Debug.WriteLine("  - " + item.Titulo);
            //}
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
