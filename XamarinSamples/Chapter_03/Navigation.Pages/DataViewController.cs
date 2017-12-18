using System;
using System.Collections.Generic;
using UIKit;

namespace Navigation.Pages
{
	public partial class DataViewController : UIViewController
	{	    
	    public KeyValuePair<string, UIColor> DataObject { get; set; }

	    protected DataViewController(IntPtr handle) : base(handle)
	    {
	        // Note: this .ctor should not contain any initialization logic.
	    }

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

	    public override void ViewWillAppear(bool animated)
	    {
	        base.ViewWillAppear(animated);
            	        
	        dataLabel.Text = DataObject.Key;
	        ViewDataPanel.BackgroundColor = DataObject.Value;
	    }
	}
}
