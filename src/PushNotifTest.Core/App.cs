using MvvmCross.IoC;
using MvvmCross.ViewModels;
using PushNotifTest.Core.ViewModels.Main;

namespace PushNotifTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
