using System;
using UIKit;

namespace Navigation.Swipe
{
    public partial class SecondViewController : BaseViewController
    {        
        public SecondViewController (IntPtr handle) : base (handle)
        {
        }

		partial void SwipeDetected(UISwipeGestureRecognizer sender)
		{            
		    DismissViewController(true, null);			
		}
    }
}