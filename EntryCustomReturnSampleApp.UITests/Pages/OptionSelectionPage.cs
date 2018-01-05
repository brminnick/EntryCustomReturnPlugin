using System.Linq;
using System.Collections.Generic;

using Xamarin.UITest;

using MvvmSamples.Shared;

using Tests.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace EntryCustomReturnSampleApp.UITests
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
		public OptionSelectionPage(IApp app) : base(app, PageTitles.OptionSelectionPageTitle)
		{
			_openSelectEntryPageButton = x => x.Marked(AutomationIdConstants.OpenPickerEntryPageButtonAutomationId);
			_openMultipleEntryPageButton = x => x.Marked(AutomationIdConstants.OpenMultileEntryPageButtonAutomationId);
			_entryTypePicker = x => x.Marked(AutomationIdConstants.EntryTypePickerAutomationId);
		}
		#endregion

		#region Methods
		public void TapOpenSelectEntryPageButton()
		{
			App.Tap(_openSelectEntryPageButton);
			App.Screenshot("Open Select Entry Page Button Tapped");
		}

		public void TapOpenMultipleEntryPageButton()
		{
			App.Tap(_openMultipleEntryPageButton);
			App.Screenshot("Open Multiple Entry Page Button Tapped");
		}

		public void SetEntryPickerType(CustomEntryType customEntryType)
		{
			App.Tap(_entryTypePicker);
			App.Tap(_pickerListDictionary.FirstOrDefault(x => x.Key == customEntryType).Value);

			if (OniOS)
				App.Tap("Done");
		}
		#endregion
	}
}
