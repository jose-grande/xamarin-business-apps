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
        public INewsWebService Service { get; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            Service = new NewsWebService();
            //Service.Consultar();
            List<Noticia> noticias = Service.Consultar();
            foreach (var item in noticias)
            {
                Debug.WriteLine("  - " + item.Titulo);
            }
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
