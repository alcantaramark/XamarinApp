using System;
using System.Threading.Tasks;
using MarkApp.Helpers;
using MarkApp.Interfaces;
using MarkApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeApp();
            InitializeNavigation();

        }
       

        #region Private Methods
        private async Task InitializeNavigation()
        {
            try
            {
                var navigationService = AppContainer.Resolve<INavigationService>();
                await navigationService.NavigateToAsync<NewDiaryViewModel>();
            }
            catch(Exception e)
            {
                throw new Exception("There was an error initializing the app");
            }
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();

        }
        #endregion

        #region Page Events
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion
    }
}
