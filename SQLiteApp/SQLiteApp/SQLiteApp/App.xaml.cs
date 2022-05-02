using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace SQLiteApp
{
    public partial class App : Application
    {
        private static Database _database;
        public static Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"noticias.db3"));
                }
                return _database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
