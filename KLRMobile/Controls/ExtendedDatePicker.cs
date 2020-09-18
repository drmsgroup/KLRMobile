using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace KLRMobile.Controls
{
    public class ExtendedDatePicker : DatePicker
    {
        private static void PlaceHolderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ExtendedDatePicker)bindable;
            control.PlaceHolder = newValue.ToString();
        }

        public string PlaceHolder { get; set; }
        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
                                                             propertyName: "PlaceHolder",
                                                             returnType: typeof(string),
                                                             declaringType: typeof(ExtendedDatePicker),
                                                             defaultValue: "",
                                                             defaultBindingMode: BindingMode.TwoWay,
                                                             propertyChanged: PlaceHolderPropertyChanged);
    }
    
}
