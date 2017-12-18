#region Using

using System;
using System.Diagnostics;
using System.Linq;
using Foundation;
using UIKit;

#endregion

namespace Touches
{
    public partial class ViewController : UIViewController
    {
        #region Constructor

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        #endregion

        #region View Event Handlers

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

        #endregion

        #region Touches

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);

			Debug.WriteLine("TouchesBegan");
		}

		public override void TouchesMoved(NSSet touches, UIEvent evt)
		{
			base.TouchesMoved(touches, evt);

			Debug.WriteLine("TouchesMoved");

			foreach (var touch in touches.Cast<UITouch>())
			{
				Debug.WriteLine(touch.GetPreciseLocation(View));
			}
		}

		public override void TouchesCancelled(NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);

			Debug.WriteLine("TouchesCancelled");
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);

			Debug.WriteLine("TouchesEnded");
		}

		#endregion
	}
}
