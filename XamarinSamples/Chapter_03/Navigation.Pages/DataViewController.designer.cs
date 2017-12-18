// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Navigation.Pages
{
    [Register ("DataViewController")]
    partial class DataViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel dataLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewDataPanel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (dataLabel != null) {
                dataLabel.Dispose ();
                dataLabel = null;
            }

            if (ViewDataPanel != null) {
                ViewDataPanel.Dispose ();
                ViewDataPanel = null;
            }
        }
    }
}