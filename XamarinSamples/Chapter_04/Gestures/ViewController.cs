#region Using

using System;
using System.Drawing;
using CoreGraphics;
using UIKit;

#endregion

namespace Gestures
{
    public partial class ViewController : UIViewController
    {
        #region Fields

        private UIView square;
        private CGPoint lastTranslation;
		private nfloat lastRotation;
		private nfloat lastScale = 1.0f;

		private UIRotationGestureRecognizer rotationGestureRecognizer;
		private UIPinchGestureRecognizer pinchGestureRecognizer;

        #endregion

        #region Constructor

        protected ViewController(IntPtr handle) : base(handle) 
        { 
        }

        #endregion              

        #region View Event Handlers

		public override void ViewDidLoad()
		{
		    base.ViewDidLoad();

		    AddSquare(50.0f, UIColor.Purple);

		    AddPanGestureRecognizer();

		    AddRotationAndPinchGestureRecognizers();
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        #endregion

        #region Helpers

        private void AddSquare(float squareSideLength, UIColor color)
		{            
		    square = new UIView()
		    {
		        BackgroundColor = color,                	
			    Frame = new RectangleF(0, 0, squareSideLength, squareSideLength),
		        Center = new CGPoint(View.Frame.Width / 2.0, View.Frame.Height / 2.0)
		    };

		    Add(square);
		}

		private bool IsTouchLocationWithinSquare(UIPanGestureRecognizer panGestureRecognizer)
		{
			var location = panGestureRecognizer.LocationInView(View);

		    return square.Frame.Contains(location.X, location.Y);            		
		}

		private void UpdateSquareTransform(CGPoint translation, nfloat rotation, nfloat scale)
		{
			var transform = CGAffineTransform.MakeIdentity();

            Console.WriteLine(lastScale);

		    // Include previous translation, rotation and scale
			translation.X += lastTranslation.X;
			translation.Y += lastTranslation.Y;
			rotation += lastRotation;
			scale *= lastScale;

		    // Combine translation, rotation and scale
			transform = CGAffineTransform.Translate(transform, translation.X, translation.Y);
			transform = CGAffineTransform.Rotate(transform, rotation);
			transform = CGAffineTransform.Scale(transform, scale, scale);

			square.Transform = transform;
		}

        #endregion

        #region Gesture Recognizers

        private void AddPanGestureRecognizer()
		{
            var panGestureRecognizer = new UIPanGestureRecognizer(TranslateSquare);

		    View.AddGestureRecognizer(panGestureRecognizer);
		}

        private void TranslateSquare(UIPanGestureRecognizer sender)
        {
            if (IsTouchLocationWithinSquare(sender))
            {
                var translation = sender.TranslationInView(View);

                //square.Transform = CGAffineTransform.MakeTranslation(                    
                //    translation.X + lastTranslation.X, 
                //    translation.Y + lastTranslation.Y);                    			

                UpdateSquareTransform(translation, 0.0f, 1.0f);
            }

            if (sender.State == UIGestureRecognizerState.Ended)
            {
                lastTranslation.X = square.Transform.x0;
                lastTranslation.Y = square.Transform.y0;
            }
        }        	

        private void AddRotationAndPinchGestureRecognizers()
        {
            rotationGestureRecognizer = new UIRotationGestureRecognizer(RotateSquare);
            pinchGestureRecognizer = new UIPinchGestureRecognizer(ScaleSquare);

            rotationGestureRecognizer.ShouldRecognizeSimultaneously += GestureRecognizer_ShouldRecognizeSimultaneously;
            pinchGestureRecognizer.ShouldRecognizeSimultaneously += GestureRecognizer_ShouldRecognizeSimultaneously;

            View.AddGestureRecognizer(pinchGestureRecognizer);
            View.AddGestureRecognizer(rotationGestureRecognizer);
        }

        private bool GestureRecognizer_ShouldRecognizeSimultaneously(
            UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)
        {
            return true;
        }

        private void RotateSquare(UIRotationGestureRecognizer sender)
        {
            //UpdateSquareTransform(new CGPoint(), sender.Rotation, 1.0f);

            if (sender.State == UIGestureRecognizerState.Changed)
            {
                if (pinchGestureRecognizer.State == UIGestureRecognizerState.Changed)
                {
                    UpdateSquareTransform(new CGPoint(), sender.Rotation, pinchGestureRecognizer.Scale);
                }
                else
                {
                    UpdateSquareTransform(new CGPoint(), sender.Rotation, 1.0f);
                }
            }

            if (sender.State == UIGestureRecognizerState.Ended)
            {
                lastRotation += sender.Rotation;
            }
        }

        private void ScaleSquare(UIPinchGestureRecognizer sender)
        {
            //UpdateSquareTransform(new CGPoint(), 0.0f, sender.Scale);

            if (sender.State == UIGestureRecognizerState.Changed)
            {
                if (rotationGestureRecognizer.State == UIGestureRecognizerState.Changed)
                {
                    UpdateSquareTransform(new CGPoint(), rotationGestureRecognizer.Rotation, sender.Scale);
                }
                else
                {
                    UpdateSquareTransform(new CGPoint(), 0.0f, sender.Scale);
                }
            }
            if (sender.State == UIGestureRecognizerState.Ended)
            {
                lastScale *= sender.Scale;
            }
        }

        #endregion
    }
}
