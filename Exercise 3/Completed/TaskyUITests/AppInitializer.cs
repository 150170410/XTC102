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
                    .DeviceSerial("{your-device-id}")
                    .InstalledApp("com.xamarin.samples.taskydroid")
                    .StartApp();
            }

            else if (platform == Platform.iOS)
            {
                return ConfigureApp
                    .iOS
                    .InstalledApp("com.xamarin.taskypro")
                    .StartApp();
            }

            throw new Exception("AppInitializer: Unsupported platform " + platform);
        }
    }
}
