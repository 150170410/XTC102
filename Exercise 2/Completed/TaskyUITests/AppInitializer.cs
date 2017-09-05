using Xamarin.UITest;
using System;

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
                    // Comment this out to use the project-resources
                    .ApkFile(@"../../../../../Binaries/TaskyPro/Android/com.xamarin.samples.taskyandroid.apk")
                    .StartApp();
            }

            else if (platform == Platform.iOS)
            {
                return ConfigureApp
                    .iOS
                    // Comment this out to use the project-resources
                    .AppBundle(@"../../../../../Binaries/TaskyPro/iOS/TaskyiOS.app")
                    .StartApp();
            }

            throw new Exception("AppInitializer: Unsupported platform " + platform);
        }
    }
}

