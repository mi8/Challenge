using Airbnb.Lottie;
using CoreGraphics;
using UIKit;

namespace Challenge.iOS
{
    public partial class SplashViewController : UIViewController
    {
        public SplashViewController() : base("SplashViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            var animationView = LOTAnimationView.AnimationNamed("trophy");
            animationView.Center = new CGPoint(View.Bounds.Size.Width / 2, View.Bounds.Size.Height / 2);

            this.View.AddSubview(animationView);
            animationView.PlayWithCompletion((animationFinished) =>
            {
                UIApplication.SharedApplication.Delegate.FinishedLaunching(UIApplication.SharedApplication,
                                                                           new Foundation.NSDictionary());
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

