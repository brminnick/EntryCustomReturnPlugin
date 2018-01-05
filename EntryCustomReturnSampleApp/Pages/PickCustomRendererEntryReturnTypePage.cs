using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;
using EntryCustomReturnSampleApp.Common.Forms;

namespace EntryCustomReturnSampleApp
{
    public class PickCustomRendererEntryReturnTypePage : BaseContentPage<PickEntryReturnTypeViewModel>
    {
        #region Constructors
        public PickCustomRendererEntryReturnTypePage()
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
