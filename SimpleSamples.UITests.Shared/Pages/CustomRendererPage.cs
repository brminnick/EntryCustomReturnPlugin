using Xamarin.UITest;

<<<<<<< HEAD:SimpleSample.UITests/Pages/CustomRendererPage.cs
using SimpleSample.Shared;
=======
using Tests.Shared;
using SimpleSamples.Shared;
>>>>>>> Add-Xaml-Documentation:SimpleSamples.UITests.Shared/Pages/CustomRendererPage.cs

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace SimpleSamples.UITests.Shared
{
    public class CustomRendererPage : BaseEntryPage
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