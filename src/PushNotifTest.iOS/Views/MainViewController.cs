using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using PushNotifTest.Core.ViewModels.Main;
using UIKit;
using System.Diagnostics;
using MvvmCross.ViewModels;
using PushNotifTest.Core.ViewModels.Favorites;

namespace PushNotifTest.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainViewController : MvxTabBarViewController<MainViewModel>
    {
        private bool _isPresentedFirstTime = true;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (ViewModel != null && _isPresentedFirstTime)
            {
                _isPresentedFirstTime = false;
            }
        }

        protected override void SetTitleAndTabBarItem(UIViewController viewController, MvxTabPresentationAttribute attribute)
        {
            if (string.IsNullOrEmpty(attribute.TabName))
                attribute.TabName = "Tab name";
            base.SetTitleAndTabBarItem(viewController, attribute);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}
