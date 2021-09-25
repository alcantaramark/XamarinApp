using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MarkApp.Controls
{
    public partial class CustomCheckboxView : ContentView
    {
        #region Constructors
        public CustomCheckboxView()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Members
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(
            "Checked", typeof(bool), typeof(CustomCheckboxView)
            );

        public static readonly BindableProperty CheckBoxLabelProperty = BindableProperty.Create(
                "CheckBoxLabel", typeof(string), typeof(CustomCheckboxView));

        public static readonly BindableProperty CheckBoxLabelFontSizeProperty = BindableProperty.Create(
            "CheckBoxLabelFontSize", typeof(double), typeof(CustomCheckboxView));

        public static readonly BindableProperty CheckBoxLabelFontAttributeProperty = BindableProperty.Create(
            "CheckBoxLabelFontAttribute", typeof(FontAttributes), typeof(CustomCheckboxView));

        public FontAttributes CheckBoxLabelFontAttribute
        {
            get => (FontAttributes)GetValue(CheckBoxLabelFontAttributeProperty);
            set => SetValue(CheckBoxLabelFontAttributeProperty, value);
        }

        public double CheckBoxLabelFontSize
        {
            get => (double)GetValue(CheckBoxLabelFontSizeProperty);
            set => SetValue(CheckBoxLabelFontSizeProperty, value);
        }

        public string CheckBoxLabel
        {
            get => (string)GetValue(CheckBoxLabelProperty);
            set => SetValue(CheckBoxLabelProperty, value);
        }

        public bool Checked
        {
            get => (bool)GetValue(CheckedProperty);
            set => SetValue(CheckedProperty, value);
        }

        #endregion
    }
}
