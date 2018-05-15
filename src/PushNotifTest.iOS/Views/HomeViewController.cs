using System;
using UIKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using PushNotifTest.Core.ViewModels.Main;

namespace PushNotifTest.iOS.Views.Home
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Tab 1")]
    public class HomeViewController : BaseViewController<HomeViewModel>
    {
        private UILabel label;

        public HomeViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddLabel();
            var set = this.CreateBindingSet<HomeViewController, HomeViewModel>();
            set.Bind(label.Text).To(vm => vm.TestString);
            set.Apply();
        }

        private void AddLabel()
        {
            label = new UILabel
            {
                Text = ViewModel.TestString,
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            var lblConstraints = new[]
            {
                label.LeadingAnchor.ConstraintEqualTo(anchor:this.View.SafeAreaLayoutGuide.LeadingAnchor, constant:20.0f),
                label.WidthAnchor.ConstraintEqualTo(label.IntrinsicContentSize.Width),
                label.TopAnchor.ConstraintEqualTo(anchor:this.View.SafeAreaLayoutGuide.TopAnchor, constant:20.0f),
                label.HeightAnchor.ConstraintEqualTo(label.IntrinsicContentSize.Height)
                };
            View.AddSubview(label);
        }
    }
}

