using MvvmSamples.Shared;
using MvvmSamples.Common.Forms;

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

			Padding = ViewHelpers.GetPagePadding();

			Content = ViewHelpers.CreateMultipleEntryPageLayout(false, ViewModel);
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
