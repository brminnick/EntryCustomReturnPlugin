using NUnit.Framework;

using Xamarin.UITest;
using SimpleSample.Shared;

namespace SimpleSample.UITests
{
    public class Tests : SimpleSampleBaseTest
    {
        public Tests(Platform platform) : base(platform)
        {
        }

        public override void TestSetup()
        {
            base.TestSetup();

            SelectionPage.WaitForPageToLoad();
        }

        [Test]
        public void CustomRendererTest()
        {
            //Arrange

            //Act
            SelectionPage.TapCustomRendererPageButton();
            CustomRendererPage.TapCustomReturnEntryReturnButton();

            //Assert
            App.WaitForElement(PageTitles.Selection);
        }

        [Test]
        public void EffectsTest()
        {
            //Arrange

            //Act
            SelectionPage.TapEffectsPageButton();
            EffectsPage.TapEffectsEntryReturnButton();

            //Assert
            App.WaitForElement(PageTitles.Selection);
        }
    }
}
