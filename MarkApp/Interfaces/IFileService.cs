using System;
using System.Collections.Generic;

namespace MarkApp.Interfaces
{
    public interface IFileService
    {
        #region Methods
        List<string> ConvertToBase64Encoding(List<string> imagePath);
        #endregion
    }
}
