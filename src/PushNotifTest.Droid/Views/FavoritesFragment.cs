using System;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using PushNotifTest.Core.ViewModels.Favorites;
using PushNotifTest.Core.ViewModels.Main;

namespace PushNotifTest.Droid.Views.Favorites
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, false,
                             Resource.Animation.abc_grow_fade_in_from_bottom,
                             Resource.Animation.abc_fade_out,
                             Resource.Animation.abc_fade_in,
                             Resource.Animation.abc_fade_out)]
    public class FavoritesFragment : BaseFragment<FavoritesViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_favorites;
    }
}
