using System;
using System.Linq;

using Xamarin.UITest;

using EntryCustomReturnSampleApp.Shared;
using EntryCustomReturn.Forms.Plugin.Abstractions;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace EntryCustomReturnUITests
{
	public class MultipleEntryPage : BasePage
	{
		#region Constant Fields
		readonly Query _nextReturnTypeEntry, _defaultReturnTypeEntry, _doneReturnTypeEntry, _goReturnTypeEntry,
			_searchReturnTypeEntry, _sendReturnTypeEntry, _goButton, _resultsLabel;
		#endregion

		#region Constructors
		public MultipleEntryPage(IApp app, Platform platform) : base(app, platform, PageTitles.MultipleEntryPageTitle)
		{
			_defaultReturnTypeEntry = x => x.Marked(AutomationIdConstants.DefaultReturnTypeEntryAutomationId);
			_nextReturnTypeEntry = x => x.Marked(AutomationIdConstants.NextReturnTypeEntryAutomationId);
			_doneReturnTypeEntry = x => x.Marked(AutomationIdConstants.DoneReturnTypeEntryAutomationId);
			_goReturnTypeEntry = x => x.Marked(AutomationIdConstants.GoReturnTypeEntryAutomationId);
			_searchReturnTypeEntry = x => x.Marked(AutomationIdConstants.SearchReturnTypeEntryAutomationId);
			_sendReturnTypeEntry = x => x.Marked(AutomationIdConstants.SendReturnTypeEntryAutomationId);
			_goButton = x => x.Marked(AutomationIdConstants.GoButtonAutomationId);
			_resultsLabel = x => x.Marked(AutomationIdConstants.ResultsLabelAutomationId);
		}
		#endregion

		#region Properties
		public string ResultsLabelText => app.Query(_resultsLabel)?.FirstOrDefault()?.Text;
		#endregion

		#region Methods
		public void EnterTextIntoAllEntrysUsingReturnButton(string text)
		{
			app.Tap(_defaultReturnTypeEntry);

			for (int i = 0; i < Enum.GetNames(typeof(ReturnType)).Length; i++)
			{
				ClearThenEnterText(text);
				app.PressEnter();
			}

			app.Screenshot($"Entered Text Into All Entrys Using Return Button: {text}");
		}

		public void EnterDefaultReturnTypeEntryText(string text)
		{
			app.Tap(_defaultReturnTypeEntry);
			ClearThenEnterText(text);
			app.DismissKeyboard();
			app.Screenshot($"Entered Default Return Type Entry Text: {text}");
		}

		public void EnterNextReturnTypeEntryText(string text)
		{
			app.Tap(_nextReturnTypeEntry);
			ClearThenEnterText(text);
			app.DismissKeyboard();
			app.Screenshot($"Entered Next Return Type Entry Text: {text}");
		}

		public void EnterGoReturnTypeEntryText(string text)
		{
			app.Tap(_goReturnTypeEntry);
			ClearThenEnterText(text);
			app.DismissKeyboard();
			app.Screenshot($"Entered Go Return Type Entry Text: {text}");
		}

		public void EnterSearchReturnTypeEntryText(string text)
		{
			app.Tap(_searchReturnTypeEntry);
			ClearThenEnterText(text);
			app.DismissKeyboard();
			app.Screenshot($"Entered Search Return Type Entry Text: {text}");
		}

		public void EnterSendReturnTypeEntryText(string text)
		{
			app.Tap(_sendReturnTypeEntry);
			ClearThenEnterText(text);
			app.DismissKeyboard();
			app.Screenshot($"Entered Send Return Type Entry Text: {text}");
		}

		public void EnterDoneReturnTypeEntryText(string text)
		{
			app.Tap(_doneReturnTypeEntry);
			ClearThenEnterText(text);
			app.DismissKeyboard();
			app.Screenshot($"Entered Done Return Type Entry Text: {text}");
		}

		public void TapGoButton()
		{
			app.Tap(_goButton);
			app.Screenshot("Go Button Tapped");
		}

		void ClearThenEnterText(string text)
		{
			app.ClearText();
			app.EnterText(text);
		}
		#endregion
	}
}
