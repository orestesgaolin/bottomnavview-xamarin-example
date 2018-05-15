using System;
using MvvmCross.Navigation;

namespace PushNotifTest.Core.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public string TestString = "test string 2 here";
        public SettingsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
