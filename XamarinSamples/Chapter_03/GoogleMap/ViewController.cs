using CoreGraphics;
using System;
using System.IO;
using Foundation;
using UIKit;

namespace GoogleMap
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var webView = new UIWebView(GetFrameWithVerticalMargin(20));

            LoadMapUrl(webView);

            Add(webView);

            webView.LoadFinished += (sender, e) =>
            {
                webView.EvaluateJavascript("displayGeocoordinate('New York');");
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private CGRect GetFrameWithVerticalMargin(nfloat offset)
        {
            var rect = View.Frame;

            rect.Y = offset;
            rect.Height -= offset;

            return rect;
        }

        private void LoadMapUrl(UIWebView webView)
        {
            var url = Path.Combine(NSBundle.MainBundle.BundlePath, "HTML/map.html");

            webView.LoadRequest(new NSUrlRequest(new NSUrl(url, false)));
        }
    }
}
