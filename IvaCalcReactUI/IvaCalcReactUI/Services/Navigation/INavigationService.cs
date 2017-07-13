using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvaCalcReactUI.Services.Navigation
{
    public interface INavigationService
    {
        Task Push<T>() where T : class;
        Task Push<T>(T viewModel) where T : class;
        Task<object> Pop();
        Task PushModal<T>() where T : class;
        Task PushModal<T>(T viewModel) where T : class;
        Task<object> PopModal();
        Task PopToRoot();
    }
}
