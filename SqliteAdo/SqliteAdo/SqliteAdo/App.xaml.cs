using SqliteAdo.Services;
using SqliteAdo.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteAdo
{
    public partial class App : Application
    {
        //private static IDatabase _database;
        //public static IDatabase Database
        //{
        //    get
        //    {
        //        if (_database == null)
        //        {
        //            _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "noticias.db3"));
        //        }
        //        return _database;
        //    }
        //}
        public App()
        {
            InitializeComponent();

            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            IDatabase database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "noticias.db3"));
            
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
