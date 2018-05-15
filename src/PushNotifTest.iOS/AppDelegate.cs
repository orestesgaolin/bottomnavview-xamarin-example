using Foundation;
using MvvmCross.Platforms.Ios.Core;
using PushNotifTest.Core;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using UIKit;
using Microsoft.AppCenter.Push;
using PushNotifTest.iOS.Views.Main;
using MvvmCross;
using System.Diagnostics;
using MvvmCross.ViewModels;

namespace PushNotifTest.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>//MvxApplicationDelegate<Setup, App>
    {
        public override void FinishedLaunching(UIApplication application)
        {
            base.FinishedLaunching(application);

            AppCenter.Start("f1ef25d6-48e0-41fe-9029-4ce0ff1a1c5f", typeof(Push), typeof(Analytics), typeof(Crashes));
        }

        //public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        //{
        //    Window = new UIWindow(UIScreen.MainScreen.Bounds);
        //    var setup = new Setup();
        //    setup.PlatformInitialize(this, Window);

        //    var startup = Mvx.Resolve<IMvxAppStart>();
        //    startup.Start();

        //    Window.MakeKeyAndVisible();
        //    Debug.WriteLine("Set root view to MainViewController");
        //    return true;
        //}
    }
}
