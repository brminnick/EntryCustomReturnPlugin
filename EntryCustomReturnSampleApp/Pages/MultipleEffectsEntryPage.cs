using EntryCustomReturnSampleApp.Shared;
using EntryCustomReturnSampleApp.Common.Forms;

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

        }

        protected override void UnsubscribeEventHandlers()
        {

        }
        #endregion
    }
}
