// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Users.MobileClient
{
    [Register ("UserDetailsViewController")]
    partial class UserDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonCancel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonUpdate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView MapViewAddress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldName { get; set; }

        [Action ("ButtonCancel_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonCancel_TouchUpInside (UIKit.UIButton sender);

		[Action("ButtonUpdate_TouchUpInside:")]
		[GeneratedCode("iOS Designer", "1.0")]
		partial void ButtonUpdate_TouchUpInside(UIKit.UIButton sender);

		void ReleaseDesignerOutlets ()
        {
            if (ButtonCancel != null) {
                ButtonCancel.Dispose ();
                ButtonCancel = null;
            }

            if (ButtonUpdate != null) {
                ButtonUpdate.Dispose ();
                ButtonUpdate = null;
            }

            if (MapViewAddress != null) {
                MapViewAddress.Dispose ();
                MapViewAddress = null;
            }

            if (TextFieldEmail != null) {
                TextFieldEmail.Dispose ();
                TextFieldEmail = null;
            }

            if (TextFieldName != null) {
                TextFieldName.Dispose ();
                TextFieldName = null;
            }
        }
    }
}