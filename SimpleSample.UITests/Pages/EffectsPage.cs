using Xamarin.UITest;

using Tests.Shared;
using SimpleSample.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace SimpleSample.UITests
{
    public class EffectsPage : BasePage
    {
        readonly Query _effectsEntry;

        public EffectsPage(IApp app) : base(app, PageTitles.Effects) =>
            _effectsEntry = x => x.Marked(AutomationIdConstants.EffectsEntry);

        public void TapEffectsEntryReturnButton()
        {
            App.Tap(_effectsEntry);
            App.PressEnter();

            App.Screenshot("Effects Entry Return Button Tapped");
        }
    }
}