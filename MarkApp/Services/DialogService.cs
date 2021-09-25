using System;
using System.Threading.Tasks;
using MarkApp.Interfaces;
using Acr.UserDialogs;
using System.Drawing;

namespace MarkApp.Services
{
    public class DialogService : IDialogService
    {
        #region Constructors
        public DialogService()
        {
        }
        #endregion

        #region Implementations
        public void HideLoading()
        {
            try
            {
                UserDialogs.Instance.HideLoading();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task ShowDialog(string message, string title, string buttonlabel)
        {
            try
            {
                return UserDialogs.Instance.AlertAsync(message, title, buttonlabel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ShowLoading()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ShowToast(string message)
        {
            try
            {
                var cfg = new ToastConfig(message)
                {
                    BackgroundColor = Color.YellowGreen,
                    MessageTextColor = Color.White
                };

                UserDialogs.Instance.Toast(cfg);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
