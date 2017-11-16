using NUnit.Framework;

using Xamarin.UITest;

namespace EntryCustomReturnUITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public abstract class BaseTest
    {
        #region Fields
        IApp _app;
        Platform _platform;
        MultipleEntryPage _multipleEntryPage;
        OptionSelectionPage _optionSelectionPage;
        PickEntryReturnTypePage _pickEntryReturnTypePage;
        #endregion

        #region Constructors
        protected BaseTest(Platform platform) => _platform = platform;
        #endregion

        #region Properties
        protected IApp App => _app;
        protected Platform Platform => _platform;
        protected MultipleEntryPage MultipleEntryPage => _multipleEntryPage;
        protected OptionSelectionPage OptionSelectionPage => _optionSelectionPage;
        protected PickEntryReturnTypePage PickEntryReturnTypePage => _pickEntryReturnTypePage;
        #endregion

        #region Methods
        [SetUp]
        public virtual void TestSetup()
        {
            _app = AppInitializer.StartApp(Platform);

            App.Screenshot("App Launched");

            _multipleEntryPage = new MultipleEntryPage(App);
            _optionSelectionPage = new OptionSelectionPage(App);
            _pickEntryReturnTypePage = new PickEntryReturnTypePage(App);
        }
        #endregion
    }

}
