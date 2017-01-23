using NUnit.Framework;

using Xamarin.UITest;
using System.Text;

namespace EntryCustomReturnUITests
{
	public class MultipleEntryPageTests : BaseTest
	{
		public MultipleEntryPageTests(Platform platform) : base(platform)
		{
		}

		public override void TestSetup()
		{
			base.TestSetup();

			OptionSelectionPage.WaitForPageToLoad();
			OptionSelectionPage.TapOpenMultipleEntryPageButton();
		}

		[Test]
		public void EnterTextIntoMultipleEntriesUsingReturnButton()
		{
			//Arrange
			const string enteredText = "Hello World";
			var expectedLabelTextStringBuilder = GetExpectedLabelText(enteredText);


			//Act
			MultipleEntryPage.EnterTextIntoAllEntrysUsingReturnButton(enteredText);

			//Assert
			var retrievedLabelText = MultipleEntryPage.ResultsLabelText;
			Assert.AreEqual(expectedLabelTextStringBuilder,retrievedLabelText);
		}

		[Test]
		public void EnterTextIntoMultipleEntriesWithoutUsingReturnButton()
		{
			//Arrange
			const string enteredText = "Hello World";
			var expectedLabelTextStringBuilder = GetExpectedLabelText(enteredText);

			//Act
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
		string GetExpectedLabelText(string enteredText)
		{
			var expectedLabelTextStringBuilder = new StringBuilder();
			expectedLabelTextStringBuilder.AppendLine("NextReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"DoneReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"GoReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"SearchReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			expectedLabelTextStringBuilder.AppendLine($"SendReturnTypeEntryText:");
			expectedLabelTextStringBuilder.AppendLine($"\t{enteredText}");
			expectedLabelTextStringBuilder.AppendLine();

			return expectedLabelTextStringBuilder.ToString();
		}
	}
}
