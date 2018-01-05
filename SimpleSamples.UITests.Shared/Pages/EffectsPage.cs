using Xamarin.UITest;

using Tests.Shared;
using SimpleSamples.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace SimpleSamples.UITests.Shared
{
    public class EffectsPage : BasePage
    {
        #region Constant Fields
        readonly Query _effectsEntry;
        #endregion

        #region Constructors
        public EffectsPage(IApp app) : base(app, PageTitles.Effects) =>
            _effectsEntry = x => x.Marked(AutomationIdConstants.EffectsEntry);
        #endregion

        #region Methods
        public void TapEffectsEntryReturnButton()
        {
            App.Tap(_effectsEntry);
            App.PressEnter();

            App.Screenshot("Effects Entry Return Button Tapped");
        }
        #endregion
    }
}