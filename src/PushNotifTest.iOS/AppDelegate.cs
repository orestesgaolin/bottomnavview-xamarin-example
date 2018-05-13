using Foundation;
using MvvmCross.Platforms.Ios.Core;
using PushNotifTest.Core;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using UIKit;
using Microsoft.AppCenter.Push;

namespace PushNotifTest.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        public override void FinishedLaunching(UIApplication application)
        {
            base.FinishedLaunching(application);
            AppCenter.Start("f1ef25d6-48e0-41fe-9029-4ce0ff1a1c5f", typeof(Analytics), typeof(Crashes));
            AppCenter.Start("f1ef25d6-48e0-41fe-9029-4ce0ff1a1c5f", typeof(Push));
        }
    }
}
