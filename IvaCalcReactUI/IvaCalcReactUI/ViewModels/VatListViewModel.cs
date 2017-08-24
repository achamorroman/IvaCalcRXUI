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

        public VatListViewModel(double amount, int units, IVatService vatService = null)
        {
            _amount = amount;
            _units = units;

            _vatService = vatService ?? Locator.Current.GetService<IVatService>();

            // TODO sustituir llamada por método y ReactiveCommand
            var computedVats = _vatService.ComputeVat(Amount, Units);
            _vats.AddRange(computedVats);

            // TODO habilitar cálculos al modificar Amount o Units (llamada a método)

            // TODO selección del elemento del listview
            // Selected Item and navigation
            //this.WhenAnyValue(x => x.SelectedItem)
            //    .Where(x => x != null)
            //    .Subscribe(x => NavigateToDetailPage(x))
            //    .DisposeWith(this.Disposables);
        }

        private void LoadData(double amount, int units)
        {
            var computedVats = _vatService.ComputeVat(Amount, Units);
            Vats = new ReactiveList<VatInfo>(computedVats);
        }

        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set { this.RaiseAndSetIfChanged(ref _amount, value); }
        }

        private int _units;
        public int Units
        {
            get { return _units; }
            set { this.RaiseAndSetIfChanged(ref _units, value); }
        }


        private ReactiveList<VatInfo> _vats = new ReactiveList<VatInfo>();
        public ReactiveList<VatInfo> Vats
        {
            get { return _vats; }
            set { this.RaiseAndSetIfChanged(ref _vats, value); }
        }

        private VatInfo _selectedItem;
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