// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace HelloWatchKit.WatchExtension
{
    [Register ("InterfaceController")]
    partial class InterfaceController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceButton ButtonInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel LabelAnswer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WatchKit.WKInterfaceLabel LabelTime { get; set; }

        [Action ("ButtonInput_Activated")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonInput_Activated ();

        [Action ("NewYorkItem_Tapped")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NewYorkItem_Tapped ();

        [Action ("SanFranciscoItem_Tapped")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SanFranciscoItem_Tapped ();

        void ReleaseDesignerOutlets ()
        {
            if (ButtonInput != null) {
                ButtonInput.Dispose ();
                ButtonInput = null;
            }

            if (LabelAnswer != null) {
                LabelAnswer.Dispose ();
                LabelAnswer = null;
            }

            if (LabelTime != null) {
                LabelTime.Dispose ();
                LabelTime = null;
            }
        }
    }
}