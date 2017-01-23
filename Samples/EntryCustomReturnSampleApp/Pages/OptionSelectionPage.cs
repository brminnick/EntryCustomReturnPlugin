using System;

using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class OptionSelectionPage : BaseContentPage<BaseViewModel>
	{
		#region Constant Fields
		readonly Button _openMultipleEntryPageButton, _openSelectEntryPageButton;
		#endregion

		#region Constructors
		public OptionSelectionPage()
		{
			_openMultipleEntryPageButton = new Button
			{
				Text = "Open Multiple Entry Page",
				AutomationId = AutomationIdConstants.OpenMultipleEntryPageButtonAutomationId
			};

			_openSelectEntryPageButton = new Button
			{
				Text = "Open Pick Entry Return Type Page",
				AutomationId = AutomationIdConstants.OpenPickEntryReturnTypeButtonAutomationId
			};

			Title = PageTitles.OptionSelectionPageTitle;

			NavigationPage.SetBackButtonTitle(this, "");

			Padding = new Thickness(10);

			Content = new StackLayout
			{
				Children = {
					_openSelectEntryPageButton,
					_openMultipleEntryPageButton
				}
			};
		}
		#endregion

		#region Methods
		protected override void SubscribeEventHandlers()
		{
			_openSelectEntryPageButton.Clicked += HandleOpenSelectEntryPageButtonClicked;
			_openMultipleEntryPageButton.Clicked += HandleOpenMultipleEntryPageButtonClicked;

			AreEventHandlersSubscribed = true;
		}

		protected override void UnsubscribeEventHandlers()
		{
			_openSelectEntryPageButton.Clicked -= HandleOpenSelectEntryPageButtonClicked;
			_openMultipleEntryPageButton.Clicked -= HandleOpenMultipleEntryPageButtonClicked;

			AreEventHandlersSubscribed = false;
		}

		void HandleOpenMultipleEntryPageButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleEntryPage()));
		}

		void HandleOpenSelectEntryPageButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickEntryReturnTypePage()));
		}
		#endregion
	}
}
