using Xamarin.UITest;

using Tests.Shared;
using SimpleSample.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace SimpleSample.UITests
{
    public class CustomRendererPage : BasePage
    {
        readonly Query _customReturnEntry;

        public CustomRendererPage(IApp app) : base(app, PageTitles.CustomRenderer) =>
            _customReturnEntry = x => x.Marked(AutomationIdConstants.CustomReturnEntry);

        public void TapCustomReturnEntryReturnButton()
        {
            App.Tap(_customReturnEntry);
            App.PressEnter();

            App.Screenshot("Custom Return Entry Return Button Tapped");
        }
    }
}