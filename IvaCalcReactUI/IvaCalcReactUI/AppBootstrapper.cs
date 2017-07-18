using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvaCalcReactUI.Services.Navigation;
using IvaCalcReactUI.Services.VAT;
using IvaCalcReactUI.ViewModels;
using IvaCalcReactUI.Views;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace IvaCalcReactUI
{
    public class AppBootstrapper : ReactiveObject
    {
        public AppBootstrapper()
        {
            // Services
            Locator.CurrentMutable.RegisterLazySingleton(() => new NavigationService(), typeof(INavigationService));
            Locator.CurrentMutable.RegisterLazySingleton(() => new VatService(), typeof(IVatService));

            // Views and ViewModels
            Locator.CurrentMutable.RegisterLazySingleton(() => new MainView(), typeof(IViewFor<MainViewModel>));
            Locator.CurrentMutable.RegisterLazySingleton(() => new VatListView(), typeof(IViewFor<VatListViewModel>));

            // Sample: Obtain view from locator
            // Locator.Current.GetService<IViewFor<MainViewModel>>();
        }

        public NavigationPage GetMainPage()
        {
            var initialPage = new MainView();
            initialPage.ViewModel = new MainViewModel();

            return new NavigationPage(initialPage);
        }
    }
}
