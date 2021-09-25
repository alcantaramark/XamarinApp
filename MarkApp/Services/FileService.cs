using System;
using System.Collections.Generic;
using MarkApp.Interfaces;
using System.IO;

namespace MarkApp.Services
{
    public class FileService:IFileService
    {
        #region Constructor
        public FileService()
        {
        }
        #endregion

        #region Implementation
        public List<string> ConvertToBase64String(List<string> imagePath)
        {
            List<string> listBase64 = new List<string>();
            foreach(string image in imagePath)
            {
                byte[] imageArray = File.ReadAllBytes(image);
                listBase64.Add(Convert.ToBase64String(imageArray));
            }
            return listBase64;
        }
        #endregion
    }
}
