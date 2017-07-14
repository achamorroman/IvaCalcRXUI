using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IvaCalcReactUI.Services.Navigation;
using IvaCalcReactUI.ViewModels;
using IvaCalcReactUI.Views;
using Splat;
using Xamarin.Forms;

namespace IvaCalcReactUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var appBootstrapper = new AppBootstrapper();

            // var navPage = Locator.Current.GetService<MainView>();

            var initialPage = new MainView();
            initialPage.ViewModel = new MainViewModel();

            MainPage = initialPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }


}
