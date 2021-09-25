using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarkApp.ViewModels;
using MarkApp.Views;
using MarkApp.Interfaces;
using Xamarin.Forms;
using MarkApp.Helpers;
using System.Threading;

namespace MarkApp.Services
{
    public class NavigationService: INavigationService
    {
        #region Private Members
        private readonly Dictionary<Type, Type> _mappings;
        #endregion

        #region Protected Members
        protected Application CurrentApplication => Application.Current;
        #endregion

        #region Constructors
        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }
        #endregion

        #region Implementations
        
        public async Task NavigateToAsync<TViewModel>(object parameters = null) where TViewModel : ViewModelBase
        {
            Page page = CreateandBindPage(typeof(TViewModel), parameters);

            var navigationPage = CurrentApplication.MainPage as NavigationPage;
            if (navigationPage != null)
                await navigationPage.PushAsync(page);
            else
                CurrentApplication.MainPage = new NavigationPage(page);

            await (page.BindingContext as ViewModelBase).InitializeAsync();
        }
        #endregion

        #region Private Methods
        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(NewDiaryViewModel), typeof(NewDiary));
            _mappings.Add(typeof(PostDataViewModel), typeof(PostData));
        }
        #endregion

        #region Proctected Methods

        protected Page CreateandBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
                throw new Exception($"Mapping type for ${viewModelType} is not found");

            Page page = Activator.CreateInstance(pageType) as Page;
            page.SetNavigationArgs(parameter);
            ViewModelBase viewModel = AppContainer.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        
        

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");

            return _mappings[viewModelType];
        }
        #endregion
    }
}
