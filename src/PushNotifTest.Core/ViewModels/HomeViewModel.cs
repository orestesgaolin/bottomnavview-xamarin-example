using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Plugin.LocalNotifications;
using MvvmCross.Commands;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using MvvmCross.Navigation;

namespace PushNotifTest.Core.ViewModels.Main
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public string TestString = "test string 1 here";
        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
