using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
    public class PickEffectsEntryReturnTypePage : BaseContentPage<PickEntryReturnTypeViewModel>
    {
        #region Constructors
        public PickEffectsEntryReturnTypePage(InputViewType inputViewType)
        {
            Title = PageTitles.PickEntryReturnTypePageTitle;

            Padding = new Thickness(10);

            Content = ViewHelpers.CreatePickEntryReturnTypePageLayout(inputViewType, true, ViewModel);
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
