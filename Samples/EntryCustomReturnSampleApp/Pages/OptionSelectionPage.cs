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
		const string _pickerItemListEffectsText = "Effects";
		const string _pickerItemListCustomRenderersText = "CustomRenderers";
		#endregion

		#region Constructors
		public OptionSelectionPage()
		{
			_openMultileEntryPageButton = new Button
			{
				Text = "Multiple Entry Page",
				AutomationId = AutomationIdConstants.OpenMultipleCustomReturnEntryPageButtonAutomationId
			};

			_openPickerEntryPageButton = new Button
			{
				Text = "Return Type Picker Page",
				AutomationId = AutomationIdConstants.OpenSelectEntryPageUsingCustomRenderersButton
			};

			var pickerLabel = new Label
			{
				Text = "Generate Entrys Using"
			};

			var pickerItemSourceList = new List<string>
			{
				_pickerItemListEffectsText,
				_pickerItemListCustomRenderersText
			};

			_entryTypePicker = new Picker();
			_entryTypePicker.ItemsSource = pickerItemSourceList;
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
			if(_entryTypePicker.SelectedItem.Equals(_pickerItemListEffectsText))
				Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleEffectsEntryPage()));
			else if(_entryTypePicker.SelectedItem.Equals(_pickerItemListCustomRenderersText))
				Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleCustomRendererEntryPage()));
		}

		void HandleOpenSelectEntryPageButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickEntryReturnTypePage(false)));
		}
		#endregion
	}
}
