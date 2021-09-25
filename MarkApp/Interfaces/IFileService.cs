using System;
using System.Collections.Generic;

namespace MarkApp.Interfaces
{
    public interface IFileService
    {
        #region Methods
        List<string> ConvertToBase64String(List<string> imagePath);
        #endregion
    }
}
