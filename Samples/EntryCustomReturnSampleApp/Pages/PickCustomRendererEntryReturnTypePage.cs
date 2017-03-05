using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class PickCustomRendererEntryReturnTypePage : BaseContentPage<PickEntryReturnTypeViewModel>
	{
		#region Constructors
		public PickCustomRendererEntryReturnTypePage()
		{
			Title = PageTitles.PickEntryReturnTypePageTitle;

			Padding = new Thickness(10);

			Content = ViewHelpers.CreatePickEntryReturnTypePageLayout(false);
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
