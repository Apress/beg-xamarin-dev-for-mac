using System;
using CoreLocation;
using MapKit;
using UIKit;
using Users.MobileClient.Helpers;
using Users.MobileClient.Models;

namespace Users.MobileClient
{
    public partial class UserDetailsViewController : UIViewController
    {
        public User User { get; set; }

        private const double spanDelta = 0.05d;

        private UsersRepository usersRepository;

        public UserDetailsViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            usersRepository = await UsersRepository.GetInstance();

            MapViewAddress.ScrollEnabled = true;
            MapViewAddress.ZoomEnabled = true;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            DisplayUserData();

            UpdateMap(User.Address.Geo.ToCLLocationCoordinate2D());
        }

        partial void ButtonCancel_TouchUpInside(UIButton sender)
        {
            DismissViewController(true, null);
        }

        partial void ButtonUpdate_TouchUpInside(UIButton sender)
        {
            UpdateUserData();

            ButtonCancel_TouchUpInside(sender);
        }

        private void DisplayUserData()
        {
            TextFieldName.Text = User.Name;
            TextFieldEmail.Text = User.Email;
        }

        private void UpdateUserData()
        {
            User.Name = TextFieldName.Text;
            User.Email = TextFieldEmail.Text;

            usersRepository.Update(User);
        }

        private void UpdateMap(CLLocationCoordinate2D centerCoordinate)
        {
            AddPin(centerCoordinate);

            SetMapRegion(centerCoordinate);
        }

        private void SetMapRegion(CLLocationCoordinate2D centerCoordinate)
        {
            var span = new MKCoordinateSpan(spanDelta, spanDelta);

            var region = new MKCoordinateRegion(centerCoordinate, span);

            MapViewAddress.SetRegion(region, false);
        }

        private void AddPin(CLLocationCoordinate2D centerCoordinate)
        {
            var pin = new PinMapAnnotation(centerCoordinate, User.Name);

            MapViewAddress.AddAnnotation(pin);
        }
    }
}