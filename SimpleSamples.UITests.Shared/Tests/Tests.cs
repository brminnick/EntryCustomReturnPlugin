using NUnit.Framework;

using Xamarin.UITest;
using SimpleSamples.Shared;

namespace SimpleSample.UITests
{
    public class Tests : SimpleSampleBaseTest
    {
        #region Constructors
        public Tests(Platform platform) : base(platform)
        {
        }
        #endregion

        #region Methods
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
            CustomRendererPage.AcceptClosingDialogPopup();

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
            EffectsPage.AcceptClosingDialogPopup();

            //Assert
            App.WaitForElement(PageTitles.Selection);
        }
        #endregion
    }
}
