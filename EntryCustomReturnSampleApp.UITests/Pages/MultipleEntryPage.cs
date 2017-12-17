using System;
using System.Linq;

using Xamarin.UITest;

using EntryCustomReturnSampleApp.Shared;
using EntryCustomReturn.Forms.Plugin.Abstractions;

using Tests.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace EntryCustomReturnSampleApp.UITests
{
	public class MultipleEntryPage : BasePage
	{
		#region Constant Fields
		readonly Query _nextReturnTypeEntry, _defaultReturnTypeEntry, _doneReturnTypeEntry, _goReturnTypeEntry,
			_searchReturnTypeEntry, _sendReturnTypeEntry, _goButton, _resultsLabel;
		#endregion

		#region Constructors
		public MultipleEntryPage(IApp app) : base(app, PageTitles.MultipleEntryPageTitle)
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
		public string ResultsLabelText => App.Query(_resultsLabel)?.FirstOrDefault()?.Text;
		#endregion

		#region Methods
		public void EnterTextIntoAllEntrysUsingReturnButton(string text)
		{
			App.Tap(_defaultReturnTypeEntry);

			for (int i = 0; i < Enum.GetNames(typeof(ReturnType)).Length; i++)
			{
				ClearThenEnterText(text);
				App.PressEnter();
			}

            App.DismissKeyboard();

			App.Screenshot($"Entered Text Into All Entrys Using Return Button: {text}");
		}

		public void EnterDefaultReturnTypeEntryText(string text)
		{
			App.Tap(_defaultReturnTypeEntry);
			ClearThenEnterText(text);
			App.DismissKeyboard();
			App.Screenshot($"Entered Default Return Type Entry Text: {text}");
		}

		public void EnterNextReturnTypeEntryText(string text)
		{
			App.Tap(_nextReturnTypeEntry);
			ClearThenEnterText(text);
			App.DismissKeyboard();
			App.Screenshot($"Entered Next Return Type Entry Text: {text}");
		}

		public void EnterGoReturnTypeEntryText(string text)
		{
			App.Tap(_goReturnTypeEntry);
			ClearThenEnterText(text);
			App.DismissKeyboard();
			App.Screenshot($"Entered Go Return Type Entry Text: {text}");
		}

		public void EnterSearchReturnTypeEntryText(string text)
		{
			App.Tap(_searchReturnTypeEntry);
			ClearThenEnterText(text);
			App.DismissKeyboard();
			App.Screenshot($"Entered Search Return Type Entry Text: {text}");
		}

		public void EnterSendReturnTypeEntryText(string text)
		{
			App.Tap(_sendReturnTypeEntry);
			ClearThenEnterText(text);
			App.DismissKeyboard();
			App.Screenshot($"Entered Send Return Type Entry Text: {text}");
		}

		public void EnterDoneReturnTypeEntryText(string text)
		{
			App.Tap(_doneReturnTypeEntry);
			ClearThenEnterText(text);
			App.DismissKeyboard();
			App.Screenshot($"Entered Done Return Type Entry Text: {text}");
		}

		public void TapGoButton()
		{
			App.Tap(_goButton);
			App.Screenshot("Go Button Tapped");
		}

		void ClearThenEnterText(string text)
		{
			App.ClearText();
			App.EnterText(text);
		}
		#endregion
	}
}
