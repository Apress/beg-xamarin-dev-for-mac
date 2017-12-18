using System;
using UIKit;
using CoreGraphics;

namespace Navigation.Tabs
{
	public partial class ThirdViewController : BaseViewController
	{
	    public ThirdViewController(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
		    base.ViewDidLoad();

		    AddLabel();
		}

	    public override void DidReceiveMemoryWarning()
	    {
	        base.DidReceiveMemoryWarning();
	    }

		private void AddLabel()
		{
		    // Create the label
		    var label = new UILabel()
		    {
		        Text = "Third View"
		    };

		    // Update font size
		    nfloat fontSize = 36.0f;
		    label.Font = label.Font.WithSize(fontSize);

		    // Measure the label
		    var labelSize = UIStringDrawing.StringSize(label.Text, label.Font);

		    // and adjust the frame accordingly
		    label.Frame = new CGRect(View.Frame.Width / 2 - labelSize.Width / 2,
		                       View.Frame.Height / 2 - labelSize.Height / 2,
		                       labelSize.Width,
		                       labelSize.Height);

		    Add(label);
		}
	}
}