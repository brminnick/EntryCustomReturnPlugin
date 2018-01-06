using Xamarin.UITest;

using Tests.Shared;

namespace MvvmSamples.UITests.Shared
{
    public abstract class EntryCustomReturnSampleAppBaseTest : BaseTest
    {
        #region Constructors
        protected EntryCustomReturnSampleAppBaseTest(Platform platform) : base(platform) { }
        #endregion

        #region Properties
        protected MultipleEntryPage MultipleEntryPage { get; private set; }
        protected OptionSelectionPage OptionSelectionPage { get; private set; }
        protected PickEntryReturnTypePage PickEntryReturnTypePage { get; private set; }
        #endregion

        #region Methods
        public override void TestSetup()
        {
            base.TestSetup();

            MultipleEntryPage = new MultipleEntryPage(App);
            OptionSelectionPage = new OptionSelectionPage(App);
            PickEntryReturnTypePage = new PickEntryReturnTypePage(App);
        }
        #endregion
    }

}
