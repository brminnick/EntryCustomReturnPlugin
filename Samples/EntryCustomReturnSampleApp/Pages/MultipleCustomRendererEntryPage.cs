using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class MultipleCustomRendererEntryPage : BaseContentPage<MultipleEntryViewModel>
	{
		#region Constant Fields
		const bool _shouldUseEffects = false;
		#endregion

		#region Constructors
		public MultipleCustomRendererEntryPage()
		{
			Title = PageTitles.MultipleEntryPageTitle;

			Padding = new Thickness(10);

			Content = ViewHelpers.CreateMultipleEntryPageLayout(false);
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
