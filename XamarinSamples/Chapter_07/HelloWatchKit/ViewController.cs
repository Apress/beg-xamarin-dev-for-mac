using System;
using Foundation;
using UIKit;

namespace HelloWatchKit
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void ButtonLocalNotification_TouchUpInside(UIButton sender)
        {                        
            var notification = new UILocalNotification()
            {
                FireDate = (NSDate)DateTime.Now.AddSeconds(10),
        		AlertTitle = "Hello!",
        	    AlertAction = "Alert Action",
        	    AlertBody = "Local notification was fired"
            };

        	UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}
