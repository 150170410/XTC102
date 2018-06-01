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
                    // TODO: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    //.ApkFile ("../../../path/to/android/Debug/yourapp.apk")
                    .StartApp();
            }

            else if (platform == Platform.iOS)
            {
                return ConfigureApp
                    .iOS
                    // TODO: Update this path to point to your iOS app and uncomment the
                    // code if the app is not included in the solution.
                    //.AppBundle ("../../../path/to/ios/iPhoneSimulator/Debug/yourapp.app")
                    .StartApp();
            }

            throw new Exception("AppInitializer: Unsupported platform " + platform);
        }
    }
}
