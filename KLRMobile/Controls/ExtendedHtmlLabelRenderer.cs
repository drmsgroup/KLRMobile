using KLRMobile.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedDatePicker), typeof(ExtendedDatePickerRenderer))]
namespace KLRMobile.Controls
{
    public class ExtendedDatePickerRenderer : DatePickerRenderer
    {
        public ExtendedDatePicker ExtendedDatePickerElement => Element as ExtendedDatePicker;
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Text = ExtendedDatePickerElement.PlaceHolder;
            }
        }
    }
}
