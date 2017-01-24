using System;

using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class OptionSelectionPage : BaseContentPage<BaseViewModel>
	{
		#region Constant Fields
		readonly Button _openMultipleCustomReturnEntryPageButton, _openSelectEntryPageUsingCustomRenderersButton, 
			_openSelectEntryPageUsingEffectsButton, _openMultipleEffectsEntryPageButton;
		#endregion

		#region Constructors
		public OptionSelectionPage()
		{
			_openMultipleCustomReturnEntryPageButton = new Button
			{
				Text = "Multiple CustomReturnEntry Page",
				AutomationId = AutomationIdConstants.OpenMultipleCustomReturnEntryPageButtonAutomationId
			};

			_openSelectEntryPageUsingCustomRenderersButton = new Button
			{
				Text = "CustomReturnEntry Return Type Picker Page",
				AutomationId = AutomationIdConstants.OpenSelectEntryPageUsingCustomRenderersButton
			};

			_openSelectEntryPageUsingEffectsButton = new Button
			{
				Text = "Effects Entry Return Type Picker Page",
				AutomationId = AutomationIdConstants.OpenSelectEntryPageUsingEffectsButton
			};

			_openMultipleEffectsEntryPageButton = new Button
			{
				Text = "Multiple Effects Entry Page",
				AutomationId = AutomationIdConstants.OpenMultipleEffectsEntryPageButtonAutomationId
			};

			Title = PageTitles.OptionSelectionPageTitle;

			NavigationPage.SetBackButtonTitle(this, "");

			Padding = new Thickness(10);

			Content = new StackLayout
			{
				Children = {
					_openSelectEntryPageUsingCustomRenderersButton,
					_openSelectEntryPageUsingEffectsButton,
					_openMultipleCustomReturnEntryPageButton,
					_openMultipleEffectsEntryPageButton
				}
			};
		}
		#endregion

		#region Methods
		protected override void SubscribeEventHandlers()
		{
			_openSelectEntryPageUsingEffectsButton.Clicked += HandleOpenSelectEntryPageUsingEffectsButtonClicked;
			_openSelectEntryPageUsingCustomRenderersButton.Clicked += HandleOpenSelectEntryPageUsingCustomRenderersButtonClicked;
			_openMultipleCustomReturnEntryPageButton.Clicked += HandleOpenMultipleCustomReturnEntryPageButtonClicked;
			_openMultipleEffectsEntryPageButton.Clicked += HandleOpenMultipleEffectsEntryPageButtonClicked;

			AreEventHandlersSubscribed = true;
		}

		protected override void UnsubscribeEventHandlers()
		{
			_openSelectEntryPageUsingEffectsButton.Clicked -= HandleOpenSelectEntryPageUsingEffectsButtonClicked;
			_openSelectEntryPageUsingCustomRenderersButton.Clicked -= HandleOpenSelectEntryPageUsingCustomRenderersButtonClicked;
			_openMultipleCustomReturnEntryPageButton.Clicked -= HandleOpenMultipleCustomReturnEntryPageButtonClicked;
			_openMultipleEffectsEntryPageButton.Clicked -= HandleOpenMultipleEffectsEntryPageButtonClicked;

			AreEventHandlersSubscribed = false;
		}

		void HandleOpenSelectEntryPageUsingEffectsButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickEntryReturnTypePage(true)));
		}

		void HandleOpenMultipleCustomReturnEntryPageButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleEntryPage(false)));
		}

		void HandleOpenSelectEntryPageUsingCustomRenderersButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickEntryReturnTypePage(false)));
		}

		void HandleOpenMultipleEffectsEntryPageButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleEntryPage(true)));
		}
		#endregion
	}
}
