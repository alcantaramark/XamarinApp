using System;
using System.Threading.Tasks;
using MarkApp.ViewModels;

namespace MarkApp.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel: ViewModelBase;
    }
}
