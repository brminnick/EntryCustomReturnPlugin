using Xamarin.UITest;

using Tests.Shared;
using SimpleSample.Shared;

namespace SimpleSample.UITests
{
    public abstract class BaseEntryPage : BasePage
    {
        protected BaseEntryPage(IApp app, string pageTitle) : base(app, pageTitle)
        {
        }

        public void AcceptClosingDialogPopup()
        {
            App.WaitForElement(EntryConstants.CommandParameterString);
            App.Tap(EntryConstants.OKString);

            App.Screenshot("Ok Tapped");
        }
    }
}
