using NUnit.Framework;

using Xamarin.UITest;

namespace EntryCustomReturnUITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public abstract class BaseTest
    {
        #region Constructors
        protected BaseTest(Platform platform) => Platform = platform;
        #endregion

        #region Properties
        protected Platform Platform { get; }

        protected IApp App { get; private set; }
        protected MultipleEntryPage MultipleEntryPage { get; private set; }
        protected OptionSelectionPage OptionSelectionPage { get; private set; }
        protected PickEntryReturnTypePage PickEntryReturnTypePage { get; private set; }
        #endregion

        #region Methods
        [SetUp]
        public virtual void TestSetup()
        {
            App = AppInitializer.StartApp(Platform);

            App.Screenshot("App Launched");

            MultipleEntryPage = new MultipleEntryPage(App);
            OptionSelectionPage = new OptionSelectionPage(App);
            PickEntryReturnTypePage = new PickEntryReturnTypePage(App);
        }
        #endregion
    }

}
