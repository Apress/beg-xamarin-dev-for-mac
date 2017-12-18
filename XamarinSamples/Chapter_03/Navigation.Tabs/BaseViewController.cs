using System;
using UIKit;

namespace Navigation.Tabs
{
    public class BaseViewController : UIViewController
    {
        protected BaseViewController(IntPtr handle) : base(handle) { }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Console.WriteLine(GetType().Name);
        }
    }
}