using Foundation;
using System;
using UIKit;

namespace Navigation
{
    public class BaseViewController : UIViewController
    {
        protected BaseViewController(IntPtr handle) : base(handle) { }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var sourceViewControllerName = segue.SourceViewController.GetType().Name;
            var destinationViewControllerName = segue.DestinationViewController.GetType().Name;

            Console.WriteLine($"From: {sourceViewControllerName} " +
                "To: {destinationViewControllerName}");
        }
    }
}
