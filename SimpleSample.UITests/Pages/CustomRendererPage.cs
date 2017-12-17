using Xamarin.UITest;

using Tests.Shared;
using SimpleSample.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace SimpleSample.UITests
{
    public class CustomRendererPage : BasePage
    {
        #region Constant Fields
        readonly Query _customReturnEntry;
        #endregion

        #region Constructors
        public CustomRendererPage(IApp app) : base(app, PageTitles.CustomRenderer) =>
            _customReturnEntry = x => x.Marked(AutomationIdConstants.CustomReturnEntry);
        #endregion

        #region Methods
        public void TapCustomReturnEntryReturnButton()
        {
            App.Tap(_customReturnEntry);
            App.PressEnter();

            App.Screenshot("Custom Return Entry Return Button Tapped");
        }
        #endregion
    }
}