﻿using System;
using System.Linq.Expressions;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using IvaCalcReactUI.Models;
using IvaCalcReactUI.Services.VAT;
using IvaCalcReactUI.ViewModels.Base;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;

namespace IvaCalcReactUI.ViewModels
{
    public class VatListViewModel : ViewModelBase
    {
        private readonly IVatService _vatService;

        public VatListViewModel(double amount, int units, IVatService vatService = null)
        {
            Amount = amount;
            Units = units;

            _vatService = vatService ?? Locator.Current.GetService<IVatService>();

            Vats = new ReactiveList<VatInfo>();

            // TODO incluir this.WhenActivated para la carga inicial¿?
            LoadData(_amount * _units);

            // Command
            this.LoadVats = ReactiveCommand.Create<double>((totalAmount) => LoadData(totalAmount)).DisposeWith(this.Disposables);

            // Handle erros
            this.LoadVats.ThrownExceptions
                .Subscribe((obj) => this.LogException(obj, "Error computing vats"))
                .DisposeWith(this.Disposables);

            // Al modificar Amount ¿Como paso total (amount * units)? ¿como actualizo el label?
            // this.WhenAnyValue(x => x.Amount, x => x.Units)

            // Al modificar Amount. Funciona.
            this.WhenAnyValue(x => x.Amount)
                            .Select(x => x)
                            .DistinctUntilChanged()
                            .ObserveOn(RxApp.MainThreadScheduler)
                            .InvokeCommand(LoadVats)
                            .DisposeWith(this.Disposables);

            // Al modificar Units, llamar al método. ¿cómo?
            //this.WhenAnyValue(x => x.Units)
            //    .Select(x => x)
            //    .DistinctUntilChanged()
            //    .ObserveOn(RxApp.MainThreadScheduler)
            //    .InvokeCommand(LoadVats)
            //    .DisposeWith(this.Disposables);

            // TODO selección del elemento del listview
            // Selected Item and navigation
            //this.WhenAnyValue(x => x.SelectedItem)
            //    .Where(x => x != null)
            //    .Subscribe(x => NavigateToDetailPage(x))
            //    .DisposeWith(this.Disposables);
        }

        public ReactiveCommand LoadVats { get; protected set; }

        private void LoadData(double amount)
        {
            var computedVats = _vatService.ComputeVat(amount);
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


        readonly ObservableAsPropertyHelper<double> _totalAmount;
        public double TotalAmount
        {
            get { return _totalAmount.Value; }
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