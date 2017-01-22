using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using EntryCustomReturn.Forms.Plugin.iOS;

namespace EntryCustomReturnSampleApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			CustomReturnEntryRenderer.Init();

			return base.FinishedLaunching(app, options);
		}
	}
}
