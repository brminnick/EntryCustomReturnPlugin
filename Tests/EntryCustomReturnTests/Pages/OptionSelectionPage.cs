using System.Linq;
using System.Collections.Generic;

using Xamarin.UITest;

using EntryCustomReturnSampleApp.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace EntryCustomReturnUITests
{
	public class OptionSelectionPage : BasePage
	{
		#region Constant Fields
		readonly Query _openMultipleEntryPageButton, _openSelectEntryPageButton, _entryTypePicker;
		readonly Dictionary<CustomEntryType, string> _pickerListDictionary = new Dictionary<CustomEntryType, string>
		{
			{ CustomEntryType.CustomRenderers, PickerConstants.PickerItemListCustomRenderersText },
			{ CustomEntryType.Effects, PickerConstants.PickerItemListEffectsText }
		};
		#endregion

		#region Constructors
		public OptionSelectionPage(IApp app, Platform platform) : base(app, platform, PageTitles.OptionSelectionPageTitle)
		{
			_openSelectEntryPageButton = x => x.Marked(AutomationIdConstants.OpenPickerEntryPageButtonAutomationId);
			_openMultipleEntryPageButton = x => x.Marked(AutomationIdConstants.OpenMultileEntryPageButtonAutomationId);
			_entryTypePicker = x => x.Marked(AutomationIdConstants.EntryTypePickerAutomationId);
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

		public void SetEntryPickerType(CustomEntryType customEntryType)
		{
			app.Tap(_entryTypePicker);
			app.Tap(_pickerListDictionary.FirstOrDefault(x => x.Key == customEntryType).Value);

			if (OniOS)
				app.Tap("Done");
		}
		#endregion
	}
}
