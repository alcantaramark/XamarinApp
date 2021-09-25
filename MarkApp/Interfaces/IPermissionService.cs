using System;
namespace MarkApp.Interfaces
{
    public interface IPermissionService
    {
        #region Methods
        bool IsPickPhotoGranted();
        #endregion
    }
}
