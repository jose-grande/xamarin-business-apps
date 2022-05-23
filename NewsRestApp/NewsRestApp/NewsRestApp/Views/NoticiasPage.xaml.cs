﻿using NewsRestApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsRestApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticiasPage : ContentPage
    {
        public NoticiasPage()
        {
            InitializeComponent();
            this.BindingContext = new NoticiasViewModel();
        }
    }
}