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
        protected readonly IPermissionService _permissionService;
        protected readonly IDialogService _dialogService;
        protected readonly IPhotoService _photoService;
        protected readonly IFileService _fileService;
        #endregion

        #region Constructor
        public ViewModelBase(IPermissionService permissionService
            , IDialogService dialogService
            , INavigationService navigationService
            , IPhotoService photoService
            , IFileService fileService)
        {
            _permissionService = permissionService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            _photoService = photoService;
            _fileService = fileService;
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
