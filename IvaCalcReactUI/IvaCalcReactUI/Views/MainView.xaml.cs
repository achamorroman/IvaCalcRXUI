using System.Reactive.Disposables;
using IvaCalcReactUI.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;
using IvaCalcReactUI.Views;

namespace IvaCalcReactUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ReactiveContentPage<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();

            // Bindings
            this.WhenActivated((CompositeDisposable disposables) =>
            {
                // Amount text
                this.Bind(this.ViewModel,
                          vm => vm.Amount,
                          view => view.Amount.Text)
                    .DisposeWith(disposables);

                // Units
                this.Bind(this.ViewModel,
                          vm => vm.Units,
                          view => view.Units.Text)
                    .DisposeWith(disposables);

                // ComputeVAT
                this.BindCommand(this.ViewModel,
                        vm => vm.ComputeVatCommand,
                        view => view.ComputeVAT)
                    .DisposeWith(disposables);
            });

        }
    }
}
