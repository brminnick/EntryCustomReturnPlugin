using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;
using EntryCustomReturnSampleApp.Common.Forms;

namespace EntryCustomReturnSampleApp
{
	public class PickEffectsEntryReturnTypePage : BaseContentPage<PickEntryReturnTypeViewModel>
	{
		#region Constructors
		public PickEffectsEntryReturnTypePage()
		{
			Title = PageTitles.PickEntryReturnTypePageTitle;

			Padding = new Thickness(10);

			Content = ViewHelpers.CreatePickEntryReturnTypePageLayout(false, ViewModel);
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
