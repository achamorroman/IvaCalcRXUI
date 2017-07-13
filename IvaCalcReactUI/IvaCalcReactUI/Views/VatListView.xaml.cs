using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvaCalcReactUI.ViewModels;
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
        }
    }
}
