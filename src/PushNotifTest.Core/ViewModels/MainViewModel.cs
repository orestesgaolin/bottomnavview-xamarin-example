using MvvmCross.Commands;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Plugin.LocalNotifications;
using MvvmCross.Navigation;
using PushNotifTest.Core.ViewModels.Settings;
using PushNotifTest.Core.ViewModels.Favorites;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace PushNotifTest.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxAsyncCommand NavigateToSettingsCommand => new MvxAsyncCommand(async () => await _navigationService.Navigate<SettingsViewModel>());
        public IMvxAsyncCommand NavigateToFavoritesCommand => new MvxAsyncCommand(async () => await _navigationService.Navigate<FavoritesViewModel>());
        public IMvxAsyncCommand NavigateToHomeCommand => new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());

        public override void Start()
        {
            base.Start();
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    CrossLocalNotifications.Current.Show(e.Title, e.Message);
                };
            }
            try
            {
                _navigationService.Navigate<HomeViewModel>().GetAwaiter().GetResult();
                //NavigateToHomeCommand.Execute();
            }
            catch (System.Exception e)
            {
                Crashes.TrackError(e);
            }
        }
    }
}
