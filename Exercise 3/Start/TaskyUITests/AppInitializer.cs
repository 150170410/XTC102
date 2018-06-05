using System;
using Xamarin.UITest;

namespace TaskyUITests
{
    public static class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(@"../../../../../Binaries/TaskyPro/Android/com.xamarin.samples.taskyandroid.apk")
                    .StartApp();
            }

            else if (platform == Platform.iOS)
            {
                return ConfigureApp
                    .iOS
                    .AppBundle(@"../../../../../Binaries/TaskyPro/iOS/TaskyiOS.app")
                    .StartApp();
            }

            throw new Exception("AppInitializer: Unsupported platform " + platform);
        }
    }
}
