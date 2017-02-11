using System;
using System.Linq;

using Xamarin.UITest;

using EntryCustomReturnSampleApp.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturnUITests
{
	public class PickEntryReturnTypePage : BasePage
	{
		#region Constant Fields
		readonly Query _customizableEntry, _entryReturnTypePicker;
		#endregion

		#region Constructors
		public PickEntryReturnTypePage(IApp app, Platform platform) : base(app, platform, PageTitles.PickEntryReturnTypePageTitle)
		{
			_customizableEntry = x => x.Marked(AutomationIdConstants.CustomizableEntryAutomationId);
			_entryReturnTypePicker = x => x.Marked(AutomationIdConstants.EntryReturnTypePickerAutomationId);
		}
		#endregion

		#region Properties
		public string CustomizableEntryPlaceholder => TestHelpers.GetPlaceholderText(app, AutomationIdConstants.CustomizableEntryAutomationId);
		#endregion

		#region Methods
		public void SelectReturnTypeFromPicker(ReturnType returnType)
		{
			SelectReturnTypeFromPicker(returnType, _entryReturnTypePicker);
		}

		public void EnterText(string text)
		{
			app.ClearText(_customizableEntry);
			app.EnterText(_customizableEntry, text);
			app.DismissKeyboard();
		}

		void SelectReturnTypeFromPicker(ReturnType returnType, Query pickerQuery)
		{
			app.WaitForElement(pickerQuery);
			app.Tap(pickerQuery);

			if (OnAndroid)
			{
				app.Query(x => x.Marked("select_dialog_listview").Invoke("smoothScrollToPosition", (int)returnType - 1));
				app.Tap(returnType.ToString());
			}
			else
			{
				app.Query(x => x.Class("UIPickerView").Invoke("selectRow", (int)returnType, "inComponent", 0, "animated", true));

				var maxNumberInEnum = Enum.GetValues(typeof(ReturnType)).Length - 1;

				if (returnType == (ReturnType)maxNumberInEnum)
					app.Query(x => x.Class("UIPickerView").Invoke("selectRow", (int)returnType - 1, "inComponent", 0, "animated", true));

				SelectValueFromPicker(returnType);

				app.Tap(x => x.Marked("Done"));
			}

			app.Screenshot($"Selected Return Type From Picker: {returnType.ToString()}");
		}

		void SelectValueFromPicker(ReturnType returnType)
		{
			switch (returnType)
			{
				case ReturnType.Done:
					var deviceCenterXCoordinate = app.Query()?.FirstOrDefault()?.Rect?.CenterX;

					var donePickerQuery = app.Query("Done")?.LastOrDefault();
					var donePickerXCoordinate = donePickerQuery?.Rect?.CenterX ?? deviceCenterXCoordinate ?? 500;
					var donePickerYCoordinate = donePickerQuery?.Rect?.CenterY ?? 0;

					app.TapCoordinates(donePickerXCoordinate, donePickerYCoordinate);
					break;

				default:
					app.Tap(returnType.ToString());
					break;
			}
		}
		#endregion
	}
}
