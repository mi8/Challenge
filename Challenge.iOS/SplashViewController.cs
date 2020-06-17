using Airbnb.Lottie;
using CoreGraphics;
using UIKit;

namespace Challenge.iOS
{
    public partial class SplashViewController : UIViewController
    {
        LOTAnimationView animationView;

        public SplashViewController() : base("SplashViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            animationView = LOTAnimationView.AnimationNamed("trophy");

            View.AddSubview(animationView);

            animationView.PlayWithCompletion((animationFinished) =>
            {
                UIApplication.SharedApplication.Delegate.FinishedLaunching(UIApplication.SharedApplication,
                                                                           new Foundation.NSDictionary());
            });
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var ratio = animationView.Bounds.Width / View.Bounds.Width;

            animationView.Frame = new CGRect(animationView.Frame.X, animationView.Frame.Y, View.Bounds.Width, animationView.Frame.Height / ratio);
            animationView.Center = new CGPoint(View.Bounds.Size.Width / 2, View.Bounds.Size.Height / 2);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

