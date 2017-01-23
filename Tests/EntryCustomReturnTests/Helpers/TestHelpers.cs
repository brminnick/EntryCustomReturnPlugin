using System.Linq;

using Xamarin.UITest;
using Xamarin.UITest.Android;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace EntryCustomReturnUITests
{
	public static class TestHelpers
	{
		internal static string GetPlaceholderText(IApp app, string entryAutomationId)
		{
			if (app is AndroidApp)
			{
				return app.Query(x => x.Marked(entryAutomationId)?.Invoke("getHint"))?.FirstOrDefault()?.ToString();
			}

			return app.Query(x => x.Marked(entryAutomationId)?.Invoke("placeholder"))?.FirstOrDefault()?.ToString();
		}
	}
}
