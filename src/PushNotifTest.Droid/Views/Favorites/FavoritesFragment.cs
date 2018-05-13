using System;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using PushNotifTest.Core.ViewModels.Favorites;
using PushNotifTest.Core.ViewModels.Main;

namespace PushNotifTest.Droid.Views.Favorites
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame)]
    public class FavoritesFragment : BaseFragment<FavoritesViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_favorites;
    }
}
