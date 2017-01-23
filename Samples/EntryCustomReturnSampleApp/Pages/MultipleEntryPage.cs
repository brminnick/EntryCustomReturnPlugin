using System;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class MultipleEntryPage : BaseContentPage<MultipleEntryViewModel>
	{
		#region Constant Fields
		readonly CustomReturnEntry _doneReturnTypeEntry, _nextReturnTypeEntry, _goReturnTypeEntry,
			_searchReturnTypeEntry, _sendReturnTypeEntry;
		#endregion

		#region Constructors
		public MultipleEntryPage()
		{
			_nextReturnTypeEntry = new CustomReturnEntry
			{
				ReturnType = ReturnType.Next,
				Placeholder = "Return Type: Next",
				AutomationId = AutomationIdConstants.NextReturnTypeEntryAutomationId
			};
			_nextReturnTypeEntry.SetBinding<MultipleEntryViewModel>(Entry.TextProperty, vm => vm.NextReturnTypeEntryText);

			_doneReturnTypeEntry = new CustomReturnEntry
			{
				ReturnType = ReturnType.Done,
				Placeholder = "Return Type: Done",
				AutomationId = AutomationIdConstants.DoneReturnTypeEntryAutomationId
			};
			_doneReturnTypeEntry.SetBinding<MultipleEntryViewModel>(Entry.TextProperty, vm => vm.DoneReturnTypeEntryText);

			_goReturnTypeEntry = new CustomReturnEntry
			{
				ReturnType = ReturnType.Go,
				Placeholder = "Return Type: Go",
				AutomationId = AutomationIdConstants.GoReturnTypeEntryAutomationId
			};
			_goReturnTypeEntry.SetBinding<MultipleEntryViewModel>(Entry.TextProperty, vm => vm.GoReturnTypeEntryText);

			_searchReturnTypeEntry = new CustomReturnEntry
			{
				ReturnType = ReturnType.Search,
				Placeholder = "Return Type: Search",
				AutomationId = AutomationIdConstants.SearchReturnTypeEntryAutomationId
			};
			_searchReturnTypeEntry.SetBinding<MultipleEntryViewModel>(Entry.TextProperty, vm => vm.SearchReturnTypeEntryText);

			_sendReturnTypeEntry = new CustomReturnEntry
			{
				ReturnType = ReturnType.Send,
				Placeholder = "Return Type: Send",
				AutomationId = AutomationIdConstants.SendReturnTypeEntryAutomationId
			};
			_sendReturnTypeEntry.SetBinding<MultipleEntryViewModel>(Entry.TextProperty, vm => vm.SendReturnTypeEntryText);

			var goButton = new Button
			{
				Text = "Go",
				AutomationId = AutomationIdConstants.GoButtonAutomationId
			};
			goButton.SetBinding<MultipleEntryViewModel>(Button.CommandProperty, vm => vm.GoButtonCommand);

			var resultLabel = new Label
			{
				AutomationId = AutomationIdConstants.ResultsLabelAutomationId
			};
			resultLabel.SetBinding<MultipleEntryViewModel>(Label.TextProperty, vm => vm.ResultLabelText);

			Title = PageTitles.MultipleEntryPageTitle;

			Padding = new Thickness(10);

			var mainStackLayout = new StackLayout
			{
				Children = {
					_nextReturnTypeEntry,
					_doneReturnTypeEntry,
					_sendReturnTypeEntry,
					_searchReturnTypeEntry,
					_goReturnTypeEntry,
					goButton,
					resultLabel
				}
			};

			Content = new ScrollView
			{
				Content = mainStackLayout
			};
		}
		#endregion

		#region Methods
		protected override void SubscribeEventHandlers()
		{
			_nextReturnTypeEntry.Completed += HandleNextReturnTypeEntryCompleted;
			_searchReturnTypeEntry.Completed += HandleSearchReturnTypeEntryCompleted;
			_doneReturnTypeEntry.Completed += HandleDoneReturnTypeEntryCompleted;
			_sendReturnTypeEntry.Completed += HandleSendReturnTypeEntryCompleted;
			_goReturnTypeEntry.Completed += HandleGoReturnTypeEntryCompleted;

			AreEventHandlersSubscribed = true;
		}

		protected override void UnsubscribeEventHandlers()
		{
			_nextReturnTypeEntry.Completed -= HandleNextReturnTypeEntryCompleted;
			_searchReturnTypeEntry.Completed -= HandleSearchReturnTypeEntryCompleted;
			_doneReturnTypeEntry.Completed -= HandleDoneReturnTypeEntryCompleted;
			_sendReturnTypeEntry.Completed -= HandleSendReturnTypeEntryCompleted;
			_goReturnTypeEntry.Completed -= HandleGoReturnTypeEntryCompleted;

			AreEventHandlersSubscribed = false;
		}

		void HandleNextReturnTypeEntryCompleted(object sender, EventArgs e)
		{
			_doneReturnTypeEntry.Focus();
		}

		void HandleSearchReturnTypeEntryCompleted(object sender, EventArgs e)
		{
			_goReturnTypeEntry.Focus();
		}

		void HandleDoneReturnTypeEntryCompleted(object sender, EventArgs e)
		{
			_sendReturnTypeEntry.Focus();
		}

		void HandleSendReturnTypeEntryCompleted(object sender, EventArgs e)
		{
			_searchReturnTypeEntry.Focus();
		}

		void HandleGoReturnTypeEntryCompleted(object sender, EventArgs e)
		{
			ViewModel?.GoButtonCommand?.Execute(null);
		}
		#endregion
	}
}
