// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace InputControls
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider SliderShift { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchIsVertical { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewMoveableSquare { get; set; }

        [Action ("SliderShift_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SliderShift_ValueChanged (UIKit.UISlider sender);

        [Action ("SwitchIsVertical_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SwitchIsVertical_ValueChanged (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (SliderShift != null) {
                SliderShift.Dispose ();
                SliderShift = null;
            }

            if (SwitchIsVertical != null) {
                SwitchIsVertical.Dispose ();
                SwitchIsVertical = null;
            }

            if (ViewMoveableSquare != null) {
                ViewMoveableSquare.Dispose ();
                ViewMoveableSquare = null;
            }
        }
    }
}