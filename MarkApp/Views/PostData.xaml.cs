using System;
using System.Collections.Generic;
using MarkApp.DataObjects;
using MarkApp.Helpers;
using MarkApp.ViewModels;
using Xamarin.Forms;

namespace MarkApp.Views
{
    public partial class PostData : ContentPage
    {
        #region Constructor
        public PostData()
        {
            InitializeComponent();
            
        }
        #endregion

        #region Overriden Methods
        protected override void OnAppearing()
        {
            var args = this.GetNavigationArgs();
            var vm = BindingContext as PostDataViewModel;
            vm.diary = args as Diary;

            vm.PostData.Execute(null);
            base.OnAppearing();
        }
        #endregion
    }
}
