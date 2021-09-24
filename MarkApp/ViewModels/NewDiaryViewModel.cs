using System;
using System.Collections.Generic;
using MarkApp.Interfaces;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MarkApp.ViewModels
{
    public class NewDiaryViewModel : ViewModelBase
    {
        #region Private Members
        //Properties
        private string _location;
        private string _comments;
        private bool _includeInPhotoGallery;
        private DateTime _dateTaken;
        private List<string> _areas;
        private List<string> _taskCategories;
        private string _tags;
        private List<string> _events;
        private string[] _base64ImageString;

        //Commands
        private ICommand postData;
        #endregion

        #region Models
        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

        public bool IncludeInPhotoGallery
        {
            get { return _includeInPhotoGallery; }
            set { SetProperty(ref _includeInPhotoGallery, value); }
        }

        public DateTime DateTaken
        {
            get { return _dateTaken; }
            set { SetProperty(ref _dateTaken, value); }
        }

        public List<string> Areas
        {
            get
            {
                _areas = new List<string> { "Entrance", "Exit", "Basement", "Rooftop" };
                return _areas;
            }
            private set { }
        }

        public List<string> TaskCategories
        {
            get
            {
                _taskCategories = new List<string> { "Mixing", "Roofing", "Plumbing", "Electrical" };
                return _taskCategories;
            }
            private set { }
        }

        public string Tags
        {
            get { return _tags; }
            set { SetProperty(ref _tags, value); }
        }

        public List<string> Events
        {
            get
            {
                _events = new List<string> { "Event 1", "Event 2", "Event 3" };
                return _events;
            }
            private set { }
        }

        public string[] Base64ImageString
        {
            get { return _base64ImageString; }
            set { SetProperty(ref _base64ImageString, value); }
        }
        #endregion

        #region Commands
        public ICommand PostData => postData ?? (postData = new Command(async () => await ExecutePostDataAsync()));
        #endregion

        #region Constructor
        public NewDiaryViewModel() : base()
        {
            
            
        }
        #endregion

        #region CommandExecutions
        private async Task ExecutePostDataAsync()
        {
            Console.WriteLine($"Naka Check ba? {IncludeInPhotoGallery}");
            await Task.FromResult(false);
        }
        #endregion
    }
}
