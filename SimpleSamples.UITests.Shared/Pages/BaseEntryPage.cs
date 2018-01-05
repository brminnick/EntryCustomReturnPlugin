using Tests.Shared;
using Xamarin.UITest;
using SimpleSamples.Shared;

namespace SimpleSamples.UITests.Shared
{
    public abstract class BaseEntryPage : BasePage
    {
        protected BaseEntryPage(IApp app, string title) : base(app, title)
        {
        }

        public void AcceptClosingDialogPopup()
        {
            App.Tap(EntryConstants.OKString);
            App.Screenshot($"{EntryConstants.OKString} Tapped");
        }
    }
}
