using System;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace IvaCalcReactUI.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public async Task<object> Pop()
        {
            var page = await Navigator.PopAsync(true);
            return ((IViewFor)page).ViewModel;
        }

        public async Task<object> PopModal()
        {
            var page = await Navigator.PopModalAsync(true);
            return ((IViewFor)page).ViewModel;
        }

        public Task PopToRoot()
        {
            return Navigator.PopToRootAsync();
        }

        public Task Push<T>() where T : class
        {
            var page = this.GetView<T>();
            return Navigator.PushAsync(page, true);
        }

        public Task Push<T>(T viewModel) where T : class
        {
            // Ensure.ArgumentNotNull(viewModel, nameof(viewModel));

            var page = this.GetView<T>(viewModel);
            return Navigator.PushAsync(page, true);
        }

        public Task PushModal<T>() where T : class
        {
            var page = this.GetView<T>();
            return Navigator.PushModalAsync(page, true);
        }

        public Task PushModal<T>(T viewModel) where T : class
        {
            // Ensure.ArgumentNotNull(viewModel, nameof(viewModel));

            var page = this.GetView<T>(viewModel);
            return Navigator.PushModalAsync(page, true);
        }

        private Page GetView<T>() where T : class
        {
            var vm = Activator.CreateInstance<T>();
            return this.GetView<T>(vm);
        }

        private Page GetView<T>(T viewModel) where T : class
        {
            var view = Locator.CurrentMutable.GetService<IViewFor<T>>();
            if (view == null)
                return null;
            view.ViewModel = viewModel;

            var page = view as Page;
            if (page == null)
            {
                throw new TypeAccessException("IViewFor must be a Page type");
            }
            return page;

        }

        public INavigation Navigator
        {
            get
            {
                var tabController = Application.Current.MainPage as TabbedPage;
                if (tabController != null)
                    return tabController.CurrentPage.Navigation;
                else
                    return Application.Current.MainPage.Navigation;
            }
        }
    }
}