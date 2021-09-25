using System;
using System.Collections.Generic;
using System.Collections;

namespace MarkApp.DataObjects
{
    public class Diary
    {
        #region Constructor
        public Diary()
        {
        }
        #endregion

        
        #region Properties
        public string Location { get; set; }
        public string Comments { get; set; }
        public bool IncludeInPhotoGallery { get; set; }
        public DateTime DateTaken { get; set; }
        public string Area { get; set; }
        public string TaskCategory { get; set; }
        public string[] Tags { get; set; }
        public string Event { get; set; }
        public List<string> Base64Image { get; set; }
        #endregion
    }
}
