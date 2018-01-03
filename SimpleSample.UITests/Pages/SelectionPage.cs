using Xamarin.UITest;

using Tests.Shared;
using SimpleSamples.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace SimpleSample.UITests
{
    public class SelectionPage : BasePage
    {
        #region Constant Fields
        readonly Query _customRendererPageButton, _effectsPageButton;
        #endregion

        #region Constructors
        public SelectionPage(IApp app) : base(app, PageTitles.Selection)
        {
            _customRendererPageButton = x => x.Marked(AutomationIdConstants.CustomRendererButton);
            _effectsPageButton = x => x.Marked(AutomationIdConstants.EffectsButton);
        }
        #endregion

        #region Methods
        public void TapCustomRendererPageButton()
        {
            App.Tap(_customRendererPageButton);
            App.Screenshot("Custom Renderer Page Button Tapped");
        }

        public void TapEffectsPageButton()
        {
            App.Tap(_effectsPageButton);
            App.Screenshot("Effects Page Button Tapped");
        }
        #endregion
    }
}
