// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace HelloWorld
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonActionSheet { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonAlert { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldFirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextFieldLastName { get; set; }

        [Action ("ButtonActionSheet_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonActionSheet_TouchUpInside (UIKit.UIButton sender);

        [Action ("ButtonAlert_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonAlert_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonActionSheet != null) {
                ButtonActionSheet.Dispose ();
                ButtonActionSheet = null;
            }

            if (ButtonAlert != null) {
                ButtonAlert.Dispose ();
                ButtonAlert = null;
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