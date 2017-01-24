using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class MultipleEffectsEntryPage : BaseContentPage<MultipleEntryViewModel>
	{
		#region Constructors
		public MultipleEffectsEntryPage()
		{
			Title = PageTitles.MultipleEntryPageTitle;

			Padding = new Thickness(10);

			Content = ViewHelpers.CreateMultipleEntryPageLayout(true);
		}

		#endregion

		#region Methods
		protected override void SubscribeEventHandlers()
		{
			AreEventHandlersSubscribed = true;
		}

		protected override void UnsubscribeEventHandlers()
		{
			AreEventHandlersSubscribed = false;
		}
		#endregion
	}
}
