using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using IvaCalcReactUI.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IvaCalcReactUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VatListView : ReactiveContentPage<VatListViewModel>
    {
        public VatListView()
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

                // Units text
                this.Bind(this.ViewModel,
                        vm => vm.Units,
                        view => view.Units.Text)
                    .DisposeWith(disposables);

                // Computed vats list
                this.OneWayBind(ViewModel,
                        vm => vm.Vats,
                        view => view.VatInfoListView.ItemsSource)
                    .DisposeWith(disposables);

            });
        }
    }
}
