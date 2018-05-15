using System;
using MvvmCross.Navigation;

namespace PushNotifTest.Core.ViewModels.Favorites
{
    public class FavoritesViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public string TestString = "test string 2 here";
        public FavoritesViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
