// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Persons
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonDisplayPersonData { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldAge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldFirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldLastName { get; set; }

        [Action ("ButtonDisplayPersonData_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonDisplayPersonData_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonDisplayPersonData != null) {
                ButtonDisplayPersonData.Dispose ();
                ButtonDisplayPersonData = null;
            }

            if (TextFieldAge != null) {
                TextFieldAge.Dispose ();
                TextFieldAge = null;
            }

            if (TextFieldEmail != null) {
                TextFieldEmail.Dispose ();
                TextFieldEmail = null;
            }

            if (TextFieldFirstName != null) {
                TextFieldFirstName.Dispose ();
                TextFieldFirstName = null;
            }

            if (TextFieldLastName != null) {
                TextFieldLastName.Dispose ();
                TextFieldLastName = null;
            }
        }
    }
}