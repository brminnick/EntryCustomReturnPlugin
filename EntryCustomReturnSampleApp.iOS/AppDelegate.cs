using UIKit;
using Foundation;

using EntryCustomReturn.Forms.Plugin.iOS;

namespace EntryCustomReturnSampleApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			CustomReturnEntryRenderer.Init();

			Xamarin.Calabash.Start();

			return base.FinishedLaunching(uiApplication, launchOptions);
		}
	}
}
