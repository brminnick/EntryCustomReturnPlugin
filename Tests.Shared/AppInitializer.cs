using System;

using Xamarin.UITest;

namespace Tests.Shared
{
    public static class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            switch (platform)
            {
                case Platform.Android:
                    return ConfigureApp.Android.PreferIdeSettings().StartApp();

                case Platform.iOS:
                    return ConfigureApp.iOS.PreferIdeSettings().StartApp();

                default:
                    throw new NotSupportedException("Platform Not Supported");
            }
        }
    }
}
