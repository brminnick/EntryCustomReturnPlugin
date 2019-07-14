using UIKit;
using Foundation;

using EntryCustomReturn.Forms.Plugin.iOS;

namespace SimpleSample.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            CustomReturnEntryRenderer.Init();

            LoadApplication(new App());

            Xamarin.Calabash.Start();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
