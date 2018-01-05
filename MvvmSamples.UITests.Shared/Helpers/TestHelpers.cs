using System;
using System.Linq;

using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Android;

namespace MvvmSamples.UITests.Shared
{
	public static class TestHelpers
	{
		internal static string GetPlaceholderText(IApp app, string entryAutomationId)
		{
            switch(app)
            {
                case AndroidApp androidApp:
                    return androidApp.Query(x => x.Marked(entryAutomationId)?.Invoke("getHint"))?.FirstOrDefault()?.ToString(); 

                case iOSApp iOSApp:
                    return iOSApp.Query(x => x.Marked(entryAutomationId)?.Invoke("placeholder"))?.FirstOrDefault()?.ToString();

                default:
                    throw new NotSupportedException("Platform Not Supported");
            }
		}
	}
}
