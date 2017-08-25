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

        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return this._ErrorMessage; }
            set { this.RaiseAndSetIfChanged(ref _ErrorMessage, value); }
        }

        public void Dispose()
        {
            Disposables?.Dispose();
        }

        protected void LogException(Exception ex, string errorMessage)
        {
            this.Log().Write(ex.Message, LogLevel.Error);
            this.Log().Write(ex.StackTrace, LogLevel.Error);
            ErrorMessage = errorMessage;
        }
    }
}
