using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmCross.Commands;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Plugin.LocalNotifications;
using MvvmCross.Navigation;
using PushNotifTest.Core.ViewModels.Settings;
using PushNotifTest.Core.ViewModels.Favorites;

namespace PushNotifTest.Core.ViewModels.Main
{
    public class MainContainerViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainContainerViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxAsyncCommand NavigateToSettingsCommand => new MvxAsyncCommand(async () => await _navigationService.Navigate<SettingsViewModel>());
        public IMvxAsyncCommand NavigateToFavoritesCommand => new MvxAsyncCommand(async () => await _navigationService.Navigate<FavoritesViewModel>());
        public IMvxAsyncCommand NavigateToHomeCommand => new MvxAsyncCommand(async () => await _navigationService.Navigate<MainViewModel>());

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
        }
    }
}
