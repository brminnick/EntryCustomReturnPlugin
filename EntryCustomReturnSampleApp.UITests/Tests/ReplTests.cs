using Xamarin.UITest;

using NUnit.Framework;

using Tests.Shared;

namespace EntryCustomReturnSampleApp.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class ReplTests
    {
        #region Constant Fields
        readonly Platform _platform;
        #endregion

        #region Fields
        IApp _app;
        #endregion

        #region Constructors
        public ReplTests(Platform platform) => _platform = platform;
        #endregion

        #region Methods
        [SetUp]
        public void TestSetup() => _app = AppInitializer.StartApp(_platform);

        [Ignore]
        [Test]
        public void ReplTest() => _app.Repl();
        #endregion
    }
}
