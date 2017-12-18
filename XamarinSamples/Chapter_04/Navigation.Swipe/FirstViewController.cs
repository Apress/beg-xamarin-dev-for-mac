using Foundation;
using System;
using UIKit;

namespace Navigation.Swipe
{
    public partial class FirstViewController : BaseViewController
    {        
        public FirstViewController (IntPtr handle) : base (handle)
        {
        }

		[Action("UnwindToFirstViewController:")]
		public void UnwindToFirstViewController(UIStoryboardSegue segue)
		{
            Console.WriteLine("UnwindToFirstViewController");
		}

		public override void ViewDidLoad()
		{
		    base.ViewDidLoad();

		    var longPressGestureRecognizer = 
                new UILongPressGestureRecognizer(PresentSecondViewController);

		    View.AddGestureRecognizer(longPressGestureRecognizer);
		}

		private void PresentSecondViewController(UILongPressGestureRecognizer sender)
		{
		    if (sender.State == UIGestureRecognizerState.Began)
		    {        
		       var secondViewController = Storyboard.
		            InstantiateViewController("SecondViewController")
		            as UIViewController;

		        PresentViewController(secondViewController, true, null);        
		    }		    
		}
    }
}