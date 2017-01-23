using NUnit.Framework;

using Xamarin.UITest;

namespace EntryCustomReturnUITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public abstract class BaseTest
	{
		protected IApp App;
		protected Platform Platform;

		protected MultipleEntryPage MultipleEntryPage;
		protected OptionSelectionPage OptionSelectionPage;
		protected PickEntryReturnTypePage PickEntryReturnTypePage;


		protected BaseTest(Platform platform)
		{
			Platform = platform;
		}

		[SetUp]
		public virtual void TestSetup()
		{
			App = AppInitializer.StartApp(Platform);

			App.Screenshot("App Launched");

			MultipleEntryPage = new MultipleEntryPage(App, Platform);
			OptionSelectionPage = new OptionSelectionPage(App, Platform);
			PickEntryReturnTypePage = new PickEntryReturnTypePage(App, Platform);
		}
	}

}
