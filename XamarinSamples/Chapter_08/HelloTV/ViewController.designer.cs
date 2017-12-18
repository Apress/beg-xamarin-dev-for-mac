// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace HelloTV
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonGetCurrentWeather { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageViewWeatherIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelHumidity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelPressure { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelTemperature { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldCityName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonGetCurrentWeather != null) {
                ButtonGetCurrentWeather.Dispose ();
                ButtonGetCurrentWeather = null;
            }

            if (ImageViewWeatherIcon != null) {
                ImageViewWeatherIcon.Dispose ();
                ImageViewWeatherIcon = null;
            }

            if (LabelDescription != null) {
                LabelDescription.Dispose ();
                LabelDescription = null;
            }

            if (LabelHumidity != null) {
                LabelHumidity.Dispose ();
                LabelHumidity = null;
            }

            if (LabelPressure != null) {
                LabelPressure.Dispose ();
                LabelPressure = null;
            }

            if (LabelTemperature != null) {
                LabelTemperature.Dispose ();
                LabelTemperature = null;
            }

            if (TextFieldCityName != null) {
                TextFieldCityName.Dispose ();
                TextFieldCityName = null;
            }
        }
    }
}