﻿using System;
using System.Collections.Generic;
using MarkApp.Interfaces;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using MarkApp.DataObjects;
using System.Collections.ObjectModel;
using System.Linq;

namespace MarkApp.ViewModels
{
    public class NewDiaryViewModel : ViewModelBase
    {
        #region Protected Members
        
        #endregion

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
        private ObservableCollection<string> _filePath = new ObservableCollection<string>();
        private bool _linkToExistingEvent = true;
        private string _selectedArea;
        private string _selectedTaskCategory;
        private string _selectedEvent;
        //Commands
        private ICommand selectPhotos;
        private ICommand deletePhoto;
        private ICommand prepareForPosting;
        #endregion

        #region Models
        public string SelectedArea
        {
            get { return _selectedArea; }
            set { SetProperty(ref _selectedArea, value); }
        }

        public string SelectedTaskCategory
        {
            get { return _selectedTaskCategory; }
            set { SetProperty(ref _selectedTaskCategory, value); }
        }

        public string SelectedEvent
        {
            get { return _selectedEvent; }
            set { SetProperty(ref _selectedEvent, value); }
        }

        public bool LinkToExistingEvent
        {
            get { return _linkToExistingEvent; }
            set { SetProperty(ref _linkToExistingEvent, value); }
        }
        public ObservableCollection<string> FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value); }
        }

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
                _areas = new List<string> {"Entrance", "Exit", "Basement", "Rooftop" };
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
        public ICommand SelectPhotos => selectPhotos ?? (selectPhotos = new Command(async () => await ExecuteSelectPhotosAsync()));
        public ICommand DeletePhoto => deletePhoto ?? (deletePhoto = new Command<string>((path) => ExecuteDeletePhoto(path)));
        public ICommand PrepareForPosting => prepareForPosting ?? (prepareForPosting = new Command(async () => await ExecutePrepareForPosting()));
        #endregion

        #region Constructors
        public NewDiaryViewModel(IPermissionService permissionService
            , IDialogService dialogService
            , INavigationService navigationService
            , IPhotoService photoService
            , IFileService fileService) : base(
                permissionService, dialogService, navigationService, photoService, fileService)
        {
            
        }
        #endregion

        #region CommandExecutions
        private async Task ExecutePrepareForPosting()
        {
            Console.Write("dito lang ako");
            Diary diary = new Diary
            {
                Area = _selectedArea ?? _selectedArea,
                Comments = _comments ?? _comments,
                DateTaken = _dateTaken,
                Event = _selectedEvent ?? _selectedEvent,
                IncludeInPhotoGallery = _includeInPhotoGallery,
                Location = _location,
                Tags = _tags.Split(new char[0], StringSplitOptions.RemoveEmptyEntries),
                TaskCategory = _selectedTaskCategory ?? _selectedTaskCategory,
                Base64ImageString = _fileService.ConvertToBase64String(_filePath.ToList())
            };
            await _navigationService.NavigateToAsync<PostDataViewModel>(diary);
        }

        private void ExecuteDeletePhoto(string path)
        {
            if (_filePath.Contains(path))
                _filePath.Remove(path);
        }

        private async Task ExecuteSelectPhotosAsync()
        {
            var medias = await _photoService.SelectPhotoAsync();
            if (medias != null)
            {
                foreach (string media in medias)
                {
                    if (!_filePath.Contains(media))
                        _filePath.Add(media);
                }
            }
            
        }

        
        #endregion
    }
}
