using System;
using System.Linq;
using CoreLocation;
using MapKit;
using UIKit;

namespace Map
{
    public partial class ViewController : UIViewController
    {
        private const double spanDelta = 0.005d;

        private MKMapView map;
        private CLLocationManager locationManager;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

		public override void ViewDidLoad()
		{
		    base.ViewDidLoad();

		    InitMap();  

		    InitLocationManager();
		}

		public override void ViewDidAppear(bool animated)
		{
		    locationManager.StartUpdatingLocation();
		}

		public override void ViewDidDisappear(bool animated)
		{
		    base.ViewDidDisappear(animated);

		    locationManager.StopUpdatingLocation();
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void InitMap()
        {
            map = new MKMapView(View.Frame)
            {
                ZoomEnabled = true,
                ScrollEnabled = true,
                ShowsUserLocation = true,
                MapType = MKMapType.HybridFlyover
            };

            Add(map);
        }

        private void InitLocationManager()
        {
            locationManager = new CLLocationManager();

            // Request authorization
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {                
                locationManager.RequestWhenInUseAuthorization();
            }

            // Handle LocationsUpdated event
            locationManager.LocationsUpdated += (sender, e) =>
            {
                UpdateMap(e);
            };
        }

        private void UpdateMap(CLLocationsUpdatedEventArgs e)
        {
            var location = e.Locations.LastOrDefault();

            if (location != null)
            {
                map.CenterCoordinate = location.Coordinate;

                SetMapRegion(location.Coordinate);
            }
        }

        private void SetMapRegion(CLLocationCoordinate2D centerCoordinate)
        {
            var span = new MKCoordinateSpan(spanDelta, spanDelta);

            var region = new MKCoordinateRegion(centerCoordinate, span);

            map.SetRegion(region, false);
        }
    }
}
