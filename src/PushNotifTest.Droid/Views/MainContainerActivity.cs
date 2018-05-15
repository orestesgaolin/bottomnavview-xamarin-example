using Android.App;
using Android.OS;
using Android.Views;
using PushNotifTest.Core.ViewModels.Main;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using MvvmCross.Binding.BindingContext;
using System;
using System.Windows.Input;

namespace PushNotifTest.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainContainerActivity : BaseActivity<MainViewModel>
    {
        protected override int ActivityLayoutId => Resource.Layout.activity_main_container;

        BottomNavigationView bottomNavigation;

        public ICommand GoToSettingsCommand { get; set; }
        public ICommand GoToFavoritesCommand { get; set; }
        public ICommand GoToHomeCommand { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartAppCenter();
            AddBackgroundAnimations();
            AddBottomNavigation();
        }

        private void StartAppCenter()
        {
            Push.SetSenderId("888165002361");
            AppCenter.Start("46356580-9ee5-40e5-b368-138d21390ada", typeof(Push), typeof(Analytics), typeof(Crashes));
        }

        private void AddBottomNavigation()
        {
            bottomNavigation = (BottomNavigationView)FindViewById(Resource.Id.bottom_navigation);
            if (bottomNavigation != null)
            {
                bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
                // trying to bind command to view model property
                var set = this.CreateBindingSet<MainContainerActivity, MainViewModel>();
                set.Bind(this).For(v => v.GoToSettingsCommand).To(vm => vm.NavigateToSettingsCommand);
                set.Bind(this).For(v => v.GoToHomeCommand).To(vm => vm.NavigateToHomeCommand);
                set.Bind(this).For(v => v.GoToFavoritesCommand).To(vm => vm.NavigateToFavoritesCommand);
                set.Apply();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Bottom navigation menu is null");
            }
        }

        private void AddBackgroundAnimations()
        {
            CoordinatorLayout rootLayout = (CoordinatorLayout)FindViewById(Resource.Id.root_layout);
            AnimationDrawable animationDrawable = (AnimationDrawable)rootLayout.Background;
            animationDrawable.SetEnterFadeDuration(2000);
            animationDrawable.SetExitFadeDuration(4000);
            animationDrawable.Start();
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Bottom navigation menu is selected: {e.Item.ItemId}");

                if (e.Item.ItemId == Resource.Id.menu_settings)
                    if (GoToSettingsCommand != null && GoToSettingsCommand.CanExecute(null))
                        GoToSettingsCommand.Execute(null);
                if (e.Item.ItemId == Resource.Id.menu_list)
                    if (GoToFavoritesCommand != null && GoToFavoritesCommand.CanExecute(null))
                        GoToFavoritesCommand.Execute(null);
                if (e.Item.ItemId == Resource.Id.menu_home)
                    if (GoToHomeCommand != null && GoToHomeCommand.CanExecute(null))
                        GoToHomeCommand.Execute(null);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {exception.Message}");
                Crashes.TrackError(exception);
            }
        }
    }
}
