using System.Diagnostics;
using Foundation;
using WatchKit;

namespace HelloWatchKit.WatchExtension
{
    [Register("ExtensionDelegate")]
    public class ExtensionDelegate : WKExtensionDelegate
    {
        public override void ApplicationDidFinishLaunching()
        {
            // Perform any final initialization of your application.
            DisplayInfo("ApplicationDidFinishLaunching");
        }

        public override void ApplicationDidBecomeActive()
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive.
            // If the application was previously in the background, optionally refresh the user interface.
            DisplayInfo("ApplicationDidBecomeActive");
        }

        public override void ApplicationWillResignActive()
        {
            // Sent when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions
            // (such as an incoming phone call or SMS message) or when the user quits the application
            // and it begins the transition to the background state.
            // Use this method to pause ongoing tasks, disable timers, etc.
            DisplayInfo("ApplicationWillResignActive");
        }

        public override void ApplicationWillEnterForeground()
        {
            if (IsEventSupported())
            {
                DisplayInfo("ApplicationWillEnterForeground");
            }
        }

        public override void ApplicationDidEnterBackground()
        {
            if (IsEventSupported())
            {
                DisplayInfo("ApplicationDidEnterBackground");
            }
        }

        private void DisplayInfo(string eventName)
        {
            Debug.WriteLine($"App event: {eventName}");
        }

        private bool IsEventSupported()
        {
            return WKInterfaceDevice.CurrentDevice.CheckSystemVersion(3, 0);
        }
    }
}

