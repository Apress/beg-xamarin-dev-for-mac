using System;
using System.Diagnostics;
using System.Timers;
using Foundation;
using WatchKit;

namespace HelloWatchKit.WatchExtension
{
    public partial class InterfaceController : WKInterfaceController
    {
        private Timer timer;

        protected InterfaceController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void Awake(NSObject context)
        {
            base.Awake(context);

            SetTitle("Hello, watch!");

            ConfigureTimer();

            // Configure interface objects here.
            //Console.WriteLine("{0} awake with context", this);

            DisplayInfo("Awake");
        }

        public override void WillActivate()
        {
            UpdateTimer();

            // This method is called when the watch view controller is about to be visible to the user.
            //Console.WriteLine("{0} will activate", this);

            DisplayInfo("WillActivate");
        }

        public override void DidDeactivate()
        {
            UpdateTimer(false);

            // This method is called when the watch view controller is no longer visible to the user.
            //Console.WriteLine("{0} did deactivate", this);

            DisplayInfo("DidDeactivate");
        }

        public override void DidAppear()
        {
            DisplayInfo("DidAppear");
        }

        public override void WillDisappear()
        {
            DisplayInfo("WillDisappear");
        }

        public override void HandleUserActivity(NSDictionary userActivity)
        {
            if (userActivity != null)
            {
                if (userActivity.ContainsKey(GlanceHelper.Key))
                {
                    SetTitle(userActivity.ValueForKey(GlanceHelper.Key).ToString());
                }
            }
        }

        partial void SanFranciscoItem_Tapped()
        {
            DisplayCityGeolocationController(City.SanFrancisco);
        }

        partial void NewYorkItem_Tapped()
        {
            DisplayCityGeolocationController(City.NewYork);
        }

        private void DisplayCityGeolocationController(City city)
        {
            var location = LocationHelper.GetLocationForCity(city);

            PushController("CityGeolocationController", location);
        }

        private void ConfigureTimer()
        {
            if (timer == null)
            {
                timer = new Timer();

                timer.Elapsed += (sender, e) =>
                {
                    DisplayCurrentTime();
                };

                timer.Interval = 1000;
            }
        }

        private void DisplayCurrentTime()
        {
            var time = String.Format("{0:HH:mm:ss}", DateTime.Now);

            LabelTime.SetText(time);
        }

        private void UpdateTimer(bool start = true)
        {
            if (start)
            {
                DisplayCurrentTime();
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        partial void ButtonInput_Activated()
        {
            var colors = new string[]
            {
                "Red", "Green", "Blue", "Orange", "Purple"
            };

            PresentTextInputController(colors, WKTextInputMode.AllowEmoji, DisplayUserResponse);
        }

        private void DisplayUserResponse(NSArray result)
        {
            var answer = "No answer";

            if (result != null)
            {
                if (result.Count > 0)
                {
                    answer = result.GetItem<NSObject>(0).ToString();
                }
            }

            LabelAnswer.SetText(answer);

            ComplicationHelper.Answer = answer;
            ComplicationHelper.UpdateComplications();
        }

        private void DisplayInfo(string eventName)
        {
            Debug.WriteLine($"{this.Class.Name}, view event: {eventName}");
        }
    }
}
