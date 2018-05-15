using System;
using UIKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using PushNotifTest.Core.ViewModels.Settings;

namespace PushNotifTest.iOS.Views.Settings
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Tab 3")]
    public class SettingsViewController : BaseViewController<SettingsViewModel>
    {
        private UILabel label;
        public SettingsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AddLabel();

            var set = this.CreateBindingSet<SettingsViewController, SettingsViewModel>();
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

