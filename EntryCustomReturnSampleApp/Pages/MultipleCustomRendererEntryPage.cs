using MvvmSamples.Shared;
using MvvmSamples.Common.Forms;

namespace EntryCustomReturnSampleApp
{
	public class MultipleCustomRendererEntryPage : BaseContentPage<MultipleEntryViewModel>
	{
		#region Constructors
		public MultipleCustomRendererEntryPage()
		{
			Title = PageTitles.MultipleEntryPageTitle;

			Padding = GetDefaultPagePadding();

			Content = ViewHelpers.CreateMultipleEntryPageLayout(false);
		}

		#endregion

		#region Methods
		protected override void SubscribeEventHandlers()
		{
			
		}

		protected override void UnsubscribeEventHandlers()
		{
			
		}
		#endregion
	}
}
