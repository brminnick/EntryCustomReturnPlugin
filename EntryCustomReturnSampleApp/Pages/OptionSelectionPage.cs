using System;
using System.Collections.Generic;

using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class OptionSelectionPage : BaseContentPage<BaseViewModel>
	{
		#region Constant Fields
		readonly Button _openMultileEntryPageButton, _openPickerEntryPageButton;
		readonly Picker _entryTypePicker;
		#endregion

		#region Constructors
		public OptionSelectionPage()
		{
			_openMultileEntryPageButton = new Button
			{
				Text = "Multiple Entry Page",
				AutomationId = AutomationIdConstants.OpenMultileEntryPageButtonAutomationId
			};

			_openPickerEntryPageButton = new Button
			{
				Text = "Return Type Picker Page",
				AutomationId = AutomationIdConstants.OpenPickerEntryPageButtonAutomationId
			};

			var pickerLabel = new Label
			{
				Text = "Generate Entrys Using"
			};

			_entryTypePicker = new Picker
			{
				AutomationId = AutomationIdConstants.EntryTypePickerAutomationId,
				ItemsSource = PickerConstants.PickerItemSourceList
			};
			_entryTypePicker.SelectedIndex = 0;

			Title = PageTitles.OptionSelectionPageTitle;

			NavigationPage.SetBackButtonTitle(this, "");

			Padding = new Thickness(10);

			Content = new StackLayout
			{
				Children = {
					pickerLabel,
					_entryTypePicker,
					_openPickerEntryPageButton,
					_openMultileEntryPageButton
	}
			};
		}
		#endregion

		#region Methods
		protected override void SubscribeEventHandlers()
		{
			_openPickerEntryPageButton.Clicked += HandleOpenSelectEntryPageButtonClicked;
			_openMultileEntryPageButton.Clicked += HandleOpenMultipleEntryPageButtonClicked;

			AreEventHandlersSubscribed = true;
		}

		protected override void UnsubscribeEventHandlers()
		{
			_openPickerEntryPageButton.Clicked -= HandleOpenSelectEntryPageButtonClicked;
			_openMultileEntryPageButton.Clicked -= HandleOpenMultipleEntryPageButtonClicked;

			AreEventHandlersSubscribed = false;
		}

		void HandleOpenMultipleEntryPageButtonClicked(object sender, EventArgs e)
		{
			if (_entryTypePicker.SelectedItem.Equals(PickerConstants.PickerItemListEffectsText))
				Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleEffectsEntryPage()));
			else if (_entryTypePicker.SelectedItem.Equals(PickerConstants.PickerItemListCustomRenderersText))
				Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleCustomRendererEntryPage()));
		}

		void HandleOpenSelectEntryPageButtonClicked(object sender, EventArgs e)
		{
			if (_entryTypePicker.SelectedItem.Equals(PickerConstants.PickerItemListEffectsText))
				Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickEffectsEntryReturnTypePage()));
			else if (_entryTypePicker.SelectedItem.Equals(PickerConstants.PickerItemListCustomRenderersText))
				Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickCustomRendererEntryReturnTypePage()));
		}
		#endregion
	}
}
