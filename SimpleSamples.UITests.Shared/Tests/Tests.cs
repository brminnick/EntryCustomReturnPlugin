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

        [TestCase(true)]
        [TestCase(false)]
        public void CustomRendererTest(bool canExecute)
        {
            //Arrange

            //Act
            SelectionPage.TapCustomRendererPageButton();

            CustomRendererPage.SetCanExecuteSwitch(canExecute);
            CustomRendererPage.TapCustomReturnEntryReturnButton();

            if(canExecute)
                CustomRendererPage.AcceptClosingDialogPopup();

            //Assert
            if (canExecute)
                App.WaitForElement(PageTitles.Selection);
            else
                App.WaitForElement(PageTitles.CustomRenderer);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void EffectsTest(bool canExecute)
        {
            //Arrange

            //Act
            SelectionPage.TapEffectsPageButton();
            EffectsPage.TapEffectsEntryReturnButton();

            if(canExecute)
                EffectsPage.AcceptClosingDialogPopup();

            //Assert
            if (canExecute)
                App.WaitForElement(PageTitles.Selection);
            else
                App.WaitForElement(PageTitles.Effects);
        }
        #endregion
    }
}
