using System;
using Pokedex.ViewModels.Base;
using Pokedex.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex
{
    public partial class App : Application
    {
        public App ()
        {
            BuildDependencies();
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        public static void BuildDependencies()
        {

            ViewModelLocator.Instance.Build();
        }
    }
}

