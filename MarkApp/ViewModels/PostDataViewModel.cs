using System;
using MarkApp.Interfaces;
using MarkApp.DataObjects;

namespace MarkApp.ViewModels
{
    public class PostDataViewModel: ViewModelBase
    {
        #region Constructors
        public PostDataViewModel(IPermissionService permissionService
            , IDialogService dialogService
            , INavigationService navigationService
            , IPhotoService photoService
            , IFileService fileService):base(permissionService, dialogService, navigationService, photoService, fileService)
        {
        }
        #endregion

        #region Private Members
        Diary _diary;
        #endregion

        #region ViewModels
        public Diary diary
        {
            get{ return _diary; }
            set { SetProperty(ref _diary, value); }
        }
        #endregion
    }
}
