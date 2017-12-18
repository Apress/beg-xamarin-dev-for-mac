// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using WatchKit;

namespace HelloWatchKit.WatchExtension
{
    [Register ("CityGeolocationController")]
    partial class CityGeolocationController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel LabelLat { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel LabelLng { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LabelLat != null) {
                LabelLat.Dispose ();
                LabelLat = null;
            }

            if (LabelLng != null) {
                LabelLng.Dispose ();
                LabelLng = null;
            }
        }
    }
}