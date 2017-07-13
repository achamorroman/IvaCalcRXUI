using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using IvaCalcReactUI.Models;
using IvaCalcReactUI.ViewModels.Base;
using ReactiveUI;

namespace IvaCalcReactUI.ViewModels
{
    public class VatListViewModel : ViewModelBase
    {
        private ReactiveList<VatInfo> _vats;
        private VatInfo _selectedItem;

        public VatListViewModel(decimal amount, int units)
        {
            // Obtención del "servicio" de cálculo del IVA

            // Carga del listview

            // Selected Item and navigation
            this.WhenAnyValue(x => x.SelectedItem)
                .Where(x => x != null)
                .Subscribe(x => NavigateToDetailPage(x))
                .DisposeWith(this.Disposables);
        }

        // Lista de IVA
        public ReactiveList<VatInfo> Vats
        {
            get { return _vats; }
            set { this.RaiseAndSetIfChanged(ref _vats, value); }
        }

        // Elemento seleccionado
        public VatInfo SelectedItem
        {
            get { return _selectedItem; }
            set { this.RaiseAndSetIfChanged(ref _selectedItem, value); }
        }


        void NavigateToDetailPage(VatInfo item)
        {
            throw new NotImplementedException();

            // Navigator.Push<>()

            // HostScreen.Router.Navigate.Execute(new DetailViewModel(item)).Subscribe();
        }


    }
}