using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using IvaCalcReactUI.Services.Navigation;
using ReactiveUI;
using Splat;

namespace IvaCalcReactUI.ViewModels.Base
{
    public class ViewModelBase : ReactiveObject, IEnableLogger
    {
        protected readonly CompositeDisposable Disposables;
        public INavigationService Navigator { get; set; }

        public ViewModelBase(INavigationService navigationService = null)
        {
            Disposables = new CompositeDisposable();

            Navigator = navigationService ?? Locator.Current.GetService<INavigationService>();
        }

        public void Dispose()
        {
            Disposables?.Dispose();
        }
    }
}
