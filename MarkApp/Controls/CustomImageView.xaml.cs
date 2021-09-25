using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;


namespace MarkApp.Controls
{
    public partial class CustomImageView : ContentView
    {
        #region Constructors
        public CustomImageView()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Members
        private ICommand deletePhoto;
        #endregion

        #region Public Members
        public static readonly BindableProperty PhotoSourceProperty = BindableProperty.Create(
                "PhotoSource", typeof(string),typeof(CustomImageView));

        
        public string PhotoSource
        {
            get => (string)GetValue(PhotoSourceProperty);
            set => SetValue(PhotoSourceProperty, value);
        }

        
        #endregion

        #region Command Executions
        
        #endregion

    }
}
