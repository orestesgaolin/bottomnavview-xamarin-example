using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace PushNotifTest.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public IMvxAsyncCommand ShowNotificationCommand => new MvxAsyncCommand(async () => await ShowNotification());

        private async Task ShowNotification()
        {
            await Task.Run(() => {
                Debug.WriteLine("Executing ShowNotification");
                CrossLocalNotifications.Current.Show("test notification", "test");
            });
        }
    }
}
