using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.Media.Abstractions;

namespace MarkApp.Interfaces
{
    public interface IPhotoService
    {
        #region Methods
        Task<List<MediaFile>> SelectPhotoAsync(PickMediaOptions options = null);
        #endregion
    }
}
