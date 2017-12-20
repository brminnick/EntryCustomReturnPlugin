using NUnit.Framework;

using Xamarin.UITest;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp.UITests
{
    public class MultipleEntryPageTests : EntryCustomReturnSampleAppBaseTest
    {
        public MultipleEntryPageTests(Platform platform) : base(platform)
        {
        }

        public override void TestSetup()
        {
            base.TestSetup();

            OptionSelectionPage.WaitForPageToLoad();
        }

        [TestCase(CustomEntryType.Effects)]
        [TestCase(CustomEntryType.CustomRenderers)]
        public void EnterTextIntoMultipleEntriesUsingReturnButton(CustomEntryType customEntryType)
        {
            //Arrange
            const string enteredText = "Hello World";
            string expectedLabelTextStringBuilder = GetExpectedLabelText(enteredText, MultipleEntryPageConstants.GoReturnTypeCommandParameterString);

            //Act
            OptionSelectionPage.SetEntryPickerType(customEntryType);
            OptionSelectionPage.TapOpenMultipleEntryPageButton();

            MultipleEntryPage.EnterTextIntoAllEntrysUsingReturnButton(enteredText);

            //Assert
            var retrievedLabelText = MultipleEntryPage.ResultsLabelText;
            Assert.AreEqual(expectedLabelTextStringBuilder, retrievedLabelText);
        }

        [TestCase(CustomEntryType.Effects)]
        [TestCase(CustomEntryType.CustomRenderers)]
        public void EnterTextIntoMultipleEntriesWithoutUsingReturnButton(CustomEntryType customEntryType)
        {
            //Arrange
            const string enteredText = "Hello World";
            var expectedLabelTextStringBuilder = GetExpectedLabelText(enteredText, MultipleEntryPageConstants.GoButtonCommandParameterString);

            //Act
            OptionSelectionPage.SetEntryPickerType(customEntryType);
            OptionSelectionPage.TapOpenMultipleEntryPageButton();

            MultipleEntryPage.EnterDefaultReturnTypeEntryText(enteredText);
            MultipleEntryPage.EnterNextReturnTypeEntryText(enteredText);
            MultipleEntryPage.EnterDoneReturnTypeEntryText(enteredText);
            MultipleEntryPage.EnterSendReturnTypeEntryText(enteredText);
            MultipleEntryPage.EnterSearchReturnTypeEntryText(enteredText);
            MultipleEntryPage.EnterGoReturnTypeEntryText(enteredText);

            MultipleEntryPage.TapGoButton();

            //Assert
            var retrievedLabelText = MultipleEntryPage.ResultsLabelText;
            Assert.AreEqual(expectedLabelTextStringBuilder, retrievedLabelText);
        }

        string GetExpectedLabelText(string enteredText, string commandParameterText) =>
            StringBuilderHelpers.ConvertTextInputToResultsLabel(commandParameterText, enteredText, enteredText, enteredText, enteredText, enteredText, enteredText);
    }
}
