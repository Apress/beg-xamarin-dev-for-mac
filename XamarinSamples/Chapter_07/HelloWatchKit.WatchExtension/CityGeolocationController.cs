using CoreLocation;
using Foundation;
using System;
using WatchKit;

namespace HelloWatchKit.WatchExtension
{
    public partial class CityGeolocationController : WKInterfaceController
    {
        private CLLocation location;

        public CityGeolocationController(IntPtr handle) : base(handle)
        {
        }

        public override void Awake(NSObject context)
        {
            base.Awake(context);

            GetLocation(context);
        }

        public override void WillActivate()
        {
            LabelLat.SetText(location.Coordinate.Latitude.ToString());
            LabelLng.SetText(location.Coordinate.Longitude.ToString());
        }

        private void GetLocation(NSObject context)
        {
            location = context as CLLocation;

            if (location == null)
            {
                location = LocationHelper.GetLocationForCity(City.SanFrancisco);
            }
        }
    }
}