using Xamarin.UITest;

<<<<<<< HEAD:SimpleSample.UITests/Pages/EffectsPage.cs
using SimpleSample.Shared;
=======
using Tests.Shared;
using SimpleSamples.Shared;
>>>>>>> Add-Xaml-Documentation:SimpleSamples.UITests.Shared/Pages/EffectsPage.cs

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace SimpleSamples.UITests.Shared
{
    public class EffectsPage : BaseEntryPage
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