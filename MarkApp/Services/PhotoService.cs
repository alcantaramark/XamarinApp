using System;
using MarkApp.Interfaces;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.Collections.Generic;
using System.Linq;

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
        public async Task<List<string>> SelectPhotoAsync(PickMediaOptions options = null)
        {
            try
            {
                var MediaOptions = new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Small,
                    CompressionQuality = 30 
                };

                var images = await CrossMedia.Current.PickPhotosAsync(MediaOptions);
                if (images != null)
                    return images.Select(x => x.Path).ToList();
                else
                    return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
