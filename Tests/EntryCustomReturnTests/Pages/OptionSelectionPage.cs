using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnUITests
{
	public class OptionSelectionPage : BasePage
	{
		#region Constant Fields
		readonly Query _openMultipleEntryPageButton, _openSelectEntryPageButton;
		#endregion

		#region Constructors
		public OptionSelectionPage(IApp app, Platform platform) : base(app, platform, PageTitles.OptionSelectionPageTitle)
		{
			_openSelectEntryPageButton = x => x.Marked(AutomationIdConstants.OpenPickEntryReturnTypeButtonAutomationId);
			_openMultipleEntryPageButton = x => x.Marked(AutomationIdConstants.OpenMultipleCustomReturnEntryPageButtonAutomationId);
		}
		#endregion

		#region Methods
		public void TapOpenSelectEntryPageButton()
		{
			app.Tap(_openSelectEntryPageButton);
			app.Screenshot("Open Select Entry Page Button Tapped");
		}

		public void TapOpenMultipleEntryPageButton()
		{
			app.Tap(_openMultipleEntryPageButton);
			app.Screenshot("Open Multiple Entry Page Button Tapped");
		}
		#endregion
	}
}
