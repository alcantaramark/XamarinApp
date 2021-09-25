using System;
using System.Threading.Tasks;

namespace MarkApp.Interfaces
{
    public interface IDialogService
    {
        #region Methods
        Task ShowDialog(string message, string title, string buttonlabel);
        void ShowLoading();
        void HideLoading();
        void ShowToast(string message);
        #endregion
    }
}
