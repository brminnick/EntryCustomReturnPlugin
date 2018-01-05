using Xamarin.UITest;

using Tests.Shared;

using SimpleSamples.UITests.Shared;

namespace SimpleSample.UITests
{
    public abstract class SimpleSampleBaseTest : BaseTest
    {
        #region Constructors
        protected SimpleSampleBaseTest(Platform platform) : base(platform) { }
        #endregion

        #region Properties
        protected SelectionPage SelectionPage { get; private set; }
        protected EffectsPage EffectsPage { get; private set; }
        protected CustomRendererPage CustomRendererPage { get; private set; }
        #endregion

        #region Methods
        public override void TestSetup()
        {
            base.TestSetup();

            SelectionPage = new SelectionPage(App);
            EffectsPage = new EffectsPage(App);
            CustomRendererPage = new CustomRendererPage(App);
        }
        #endregion
    }
}
