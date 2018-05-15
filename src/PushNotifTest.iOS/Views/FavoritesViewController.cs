using System;

using UIKit;
using PushNotifTest.Core.ViewModels.Favorites;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Binding.BindingContext;
using Foundation;
using System.Linq;
using ModelIO;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace PushNotifTest.iOS.Views.Favorites
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Tab 2")]
    public class FavoritesViewController : BaseViewController<FavoritesViewModel>
    {
        private UILabel label;
        public FavoritesViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddLabel();
            var set = this.CreateBindingSet<FavoritesViewController, FavoritesViewModel>();
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

