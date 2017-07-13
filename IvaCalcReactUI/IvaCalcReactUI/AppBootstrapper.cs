using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvaCalcReactUI.Services.Navigation;
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
            // IScreen - No lo implementamos
            // Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            // Services
            Locator.CurrentMutable.RegisterLazySingleton(() => new NavigationService(), typeof(INavigationService));

            // Views and ViewModels
            Locator.CurrentMutable.RegisterLazySingleton(() => new MainView(), typeof(IViewFor<MainViewModel>));
            Locator.CurrentMutable.RegisterLazySingleton(() => new VatListView(), typeof(IViewFor<VatListViewModel>));

            // Routing

        }
    }
}
