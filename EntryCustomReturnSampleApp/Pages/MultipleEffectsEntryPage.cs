using MvvmSamples.Shared;
using MvvmSamples.Common.Forms;

namespace EntryCustomReturnSampleApp
{
    public class MultipleEffectsEntryPage : BaseContentPage<MultipleEntryViewModel>
    {
        #region Constructors
        public MultipleEffectsEntryPage()
        {
            Title = PageTitles.MultipleEntryPageTitle;

            Padding = GetDefaultPagePadding();

            Content = ViewHelpers.CreateMultipleEntryPageLayout(true);
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
