using System;
using CoreGraphics;
using UIKit;

namespace InputControls
{
    public partial class ViewController : UIViewController
    {
        private CGPoint initialSquareCenter;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

		public override void ViewDidLoad()
		{
		    base.ViewDidLoad();

		    StoreSquareCenter();

		    AdjustSliderRange();
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		partial void SwitchIsVertical_ValueChanged(UISwitch sender)
		{
		    RecenterSquare();

		    AdjustSliderRange();
		}

		partial void SliderShift_ValueChanged(UISlider sender)
		{
		    TranslateSquare();
		}

		private void StoreSquareCenter()
		{
			initialSquareCenter = ViewMoveableSquare.Center;
		}

        private void RecenterSquare()
        {
            ViewMoveableSquare.Center = initialSquareCenter;
        }

        private void AdjustSliderRange()
        {
            var margin = ViewMoveableSquare.Frame.Width / 2.0;
            var range = SwitchIsVertical.On ? View.Frame.Height : View.Frame.Width;
            var maxShiftValue = Convert.ToInt32(range / 2.0 - margin);

            SliderShift.MinValue = -maxShiftValue;
            SliderShift.MaxValue = maxShiftValue;
            SliderShift.Value = 0;
        }

        private void TranslateSquare()
        {
            var newCenter = new CGPoint(initialSquareCenter);

            if (!SwitchIsVertical.On)
            {
                newCenter.X += SliderShift.Value;
            }
            else
            {
                newCenter.Y += SliderShift.Value;
            }

            ViewMoveableSquare.Center = newCenter;
        }
    }
}
