using System;
using MarkApp.Interfaces;
using MarkApp.DataObjects;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarkApp.ViewModels
{
    public class PostDataViewModel: ViewModelBase
    {
        #region Constructors
        public PostDataViewModel(IPermissionService permissionService
            , IDialogService dialogService
            , INavigationService navigationService
            , IPhotoService photoService
            , IFileService fileService
            , IApiService apiService):base(permissionService, dialogService, navigationService,
                photoService, fileService, apiService)
        {
        }
        #endregion

        #region Private Members
        Diary _diary;
        ICommand _postData;
        #endregion

        #region ViewModels
        public Diary diary
        {
            get{ return _diary; }
            set { SetProperty(ref _diary, value); }
        }
        #endregion

        #region Commands
        public ICommand PostData => _postData ?? new Command(async () => await ExecutePostDataAsync());
        #endregion

        #region Public Methods
        private async Task ExecutePostDataAsync()
        {
            IsBusy = true;
            try
            {
                if (await _apiService.PostDataAsync(_diary))
                    _dialogService.ShowToast("Data Successfully Posted!");
                else
                    await _dialogService.ShowDialog("There was an error in posting data to the service", "Error", "ok");
            }
            catch(Exception ex)
            {
                await _dialogService.ShowDialog("There was an error processing your request", "Error", "ok");
                IsBusy = false;
            }
            IsBusy = false;
        }
        #endregion
    }
}
