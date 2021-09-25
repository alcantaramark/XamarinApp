using System;
using MarkApp.Interfaces;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.Collections.Generic;

namespace MarkApp.Services
{
    public class PhotoService : IPhotoService
    {
        #region Constructors
        public PhotoService()
        {
            CrossMedia.Current.Initialize();
        }
        #endregion

        #region Implementations
        public async Task<List<MediaFile>> SelectPhotoAsync(PickMediaOptions options = null)
        {
            try
            {
                var MediaOptions = new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Small,
                    CompressionQuality = 50 
                };

                var images = await CrossMedia.Current.PickPhotosAsync(MediaOptions);
                return images;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
