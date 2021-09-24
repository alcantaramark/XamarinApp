using System;
using System.Threading.Tasks;
using MarkApp.Interfaces;
using MarkApp.Services;
using MvvmHelpers;

namespace MarkApp.ViewModels
{
    public class ViewModelBase: BaseViewModel
    {
        #region Protected Members
        protected readonly INavigationService _navigationService;
        #endregion

        #region Constructor
        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ViewModelBase()
        {

        }
        #endregion

        #region Public Methods
        public virtual Task InitializeAsync()
        {
            return Task.FromResult(false);
        }
        #endregion
    }
}
