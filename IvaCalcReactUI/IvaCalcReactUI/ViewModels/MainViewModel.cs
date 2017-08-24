using IvaCalcReactUI.ViewModels.Base;
using ReactiveUI;

namespace IvaCalcReactUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
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

        public ReactiveCommand ComputeVatCommand { get; protected set; }

        public MainViewModel()
        {
            ComputeVatCommand = ReactiveCommand.Create(() => Navigator.Push(new VatListViewModel(_amount, _units)));
        }

    }
}