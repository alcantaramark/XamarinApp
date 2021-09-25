using System;
using System.Threading.Tasks;
using MarkApp.ViewModels;

namespace MarkApp.Interfaces
{
    public interface INavigationService
    {
        #region Methods
        Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel: ViewModelBase;
        #endregion
    }
}
