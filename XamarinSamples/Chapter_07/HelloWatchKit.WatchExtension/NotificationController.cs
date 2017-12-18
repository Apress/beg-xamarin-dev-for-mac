using System;
using System.Diagnostics;
using WatchKit;

namespace HelloWatchKit.WatchExtension
{
    public partial class NotificationController : WKUserNotificationInterfaceController
    {
        protected NotificationController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public NotificationController()
        {
            // Initialize variables here.
            // Configure interface objects here.
        }

        public override void DidReceiveNotification(UserNotifications.UNNotification notification, Action<WKUserNotificationInterfaceType> completionHandler)
        {
            Debug.WriteLine("DidReceiveNotification");

            //notification.
            base.DidReceiveNotification(notification, completionHandler);
        }

        public override void WillActivate()
        {
            // This method is called when the watch view controller is about to be visible to the user.
            Console.WriteLine("{0} will activate", this);
        }

        public override void DidDeactivate()
        {
            // This method is called when the watch view controller is no longer visible to the user.
            Console.WriteLine("{0} did deactivate", this);
        }
    }
}
