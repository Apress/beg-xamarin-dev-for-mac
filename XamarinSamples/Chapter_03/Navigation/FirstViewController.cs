using Foundation;
using System;
using UIKit;

namespace Navigation
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
    }
}