using System;
using System.Linq.Expressions;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using IvaCalcReactUI.Models;
using IvaCalcReactUI.Services.VAT;
using IvaCalcReactUI.ViewModels.Base;
using ReactiveUI;
using Splat;

namespace IvaCalcReactUI.ViewModels
{
    public class VatListViewModel : ViewModelBase
    {
        private readonly IVatService _vatService;

        public double Amount { get; }
        public int Units { get; }

        private ReactiveList<VatInfo> _vats = new ReactiveList<VatInfo>();
        private VatInfo _selectedItem;

        public VatListViewModel(double amount, int units, IVatService vatService = null)
        {
            Amount = amount;
            Units = units;

            _vatService = vatService ?? Locator.Current.GetService<IVatService>();

            var computedVats = _vatService.ComputeVat(Amount, Units);
            _vats.AddRange(computedVats);

            // TODO habilitar cálculos al modificar Amount o Units

            // TODO selección del elemento del listview
            // Selected Item and navigation
            //this.WhenAnyValue(x => x.SelectedItem)
            //    .Where(x => x != null)
            //    .Subscribe(x => NavigateToDetailPage(x))
            //    .DisposeWith(this.Disposables);
        }

        public ReactiveList<VatInfo> Vats
        {
            get { return _vats; }
            set { this.RaiseAndSetIfChanged(ref _vats, value); }
        }

        public VatInfo SelectedItem
        {
            get { return _selectedItem; }
            set { this.RaiseAndSetIfChanged(ref _selectedItem, value); }
        }

        void NavigateToDetailPage(VatInfo item)
        {
            throw new NotImplementedException();

            // Navigator.Push<>()
            // Navigate to viewModel
            // HostScreen.Router.Navigate.Execute(new DetailViewModel(item)).Subscribe();
        }
    }
}