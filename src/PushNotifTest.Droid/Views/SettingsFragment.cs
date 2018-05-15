using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PushNotifTest.Core.ViewModels.Main;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Graphics.Drawables;
using PushNotifTest.Core.ViewModels.Settings;

namespace PushNotifTest.Droid.Views.Settings
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, false,
                             Resource.Animation.abc_grow_fade_in_from_bottom,
                             Resource.Animation.abc_fade_out,
                             Resource.Animation.abc_fade_in,
                             Resource.Animation.abc_fade_out)]
    [Register(nameof(SettingsViewModel))]
    public class SettingsFragment : BaseFragment<SettingsViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_settings;
    }
}
