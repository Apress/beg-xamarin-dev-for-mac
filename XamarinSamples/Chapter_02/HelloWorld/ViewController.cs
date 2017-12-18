using System;
using System.Diagnostics;
using UIKit;

namespace HelloWorld
{
    public partial class ViewController : UIViewController
    {
        #region Fields

        private const string title = "Apress";
        private const string message = "Hello, Xamarin.iOS!";

        private UIAlertAction okAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
        private UIAlertAction cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null);

        private Person person = new Person();

        #endregion

        #region Constructor

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        #endregion

        #region View lifecycle

		public override void ViewDidLoad()
		{
		    base.ViewDidLoad();
		    // Perform any additional setup after loading the view, typically from a nib.

		    DisplayInfo("ViewDidLoad");
		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            DisplayInfo("ViewWillAppear");

            DisplayPersonData();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            DisplayInfo("ViewWillDisappear");

            StorePersonData();
        }

		public override void ViewDidAppear(bool animated)
		{
		    base.ViewDidAppear(animated);

		    DisplayInfo("ViewDidAppear");
		}

		public override void ViewDidDisappear(bool animated)
		{
		    base.ViewDidDisappear(animated);

		    DisplayInfo("ViewDidDisappear");
		}

        #endregion

        #region Memory warning

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #endregion

        #region Event handlers

        partial void ButtonAlert_TouchUpInside(UIButton sender)
        {
            var alertController = UIAlertController.Create(
                title, message, UIAlertControllerStyle.Alert);

            alertController.AddAction(okAction);

            PresentViewController(alertController, false, null);
        }

        partial void ButtonActionSheet_TouchUpInside(UIButton sender)
        {
            var actionSheetController = new UIAlertController()
            {
                Title = title,
                Message = message
            };

            actionSheetController.AddAction(okAction);
            actionSheetController.AddAction(cancelAction);

            PresentViewController(actionSheetController, true, null);
        }

		#endregion

		#region Helpers

		private void DisplayInfo(string eventName)
		{
			Debug.WriteLine($"View event: {eventName}");
		}

		private void DisplayPersonData()
		{
		    person.RestoreValues();

			TextFieldFirstName.Text = person.FirstName;
		    TextFieldLastName.Text = person.LastName;
		}

		private void StorePersonData()
		{
		    person.FirstName = TextFieldFirstName.Text;
		    person.LastName = TextFieldLastName.Text;

		    person.StoreValues();
		}

        #endregion
    }
}