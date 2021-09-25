using System;
using MarkApp.Interfaces;
using Plugin.Media;

namespace MarkApp.Services
{
    public class PermissionService: IPermissionService
    {
        #region Constructors
        public PermissionService()
        {
            CrossMedia.Current.Initialize();
        }
        #endregion

        #region Implementations
        public bool IsPickPhotoGranted()
        {
            try
            {
                return CrossMedia.Current.IsPickPhotoSupported;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
