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

			Padding = ViewHelpers.GetPagePadding();

			Content = ViewHelpers.CreateMultipleEntryPageLayout(true, ViewModel);
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
