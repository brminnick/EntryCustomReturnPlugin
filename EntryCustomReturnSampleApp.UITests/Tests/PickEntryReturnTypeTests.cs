using NUnit.Framework;

using Xamarin.UITest;

using EntryCustomReturnSampleApp.Shared;
using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturnSampleApp.UITests
{
	public class PickEntryReturnTypeTests : EntryCustomReturnSampleAppBaseTest
	{
		public PickEntryReturnTypeTests(Platform platform) : base(platform)
		{
		}

		public override void TestSetup()
		{
			base.TestSetup();

			OptionSelectionPage.WaitForPageToLoad();
		}

		[TestCase(ReturnType.Default, CustomEntryType.Effects)]
		[TestCase(ReturnType.Done, CustomEntryType.Effects)]
		[TestCase(ReturnType.Go, CustomEntryType.Effects)]
		[TestCase(ReturnType.Next, CustomEntryType.Effects)]
		[TestCase(ReturnType.Search, CustomEntryType.Effects)]
		[TestCase(ReturnType.Send, CustomEntryType.Effects)]
		[TestCase(ReturnType.Default, CustomEntryType.CustomRenderers)]
		[TestCase(ReturnType.Done, CustomEntryType.CustomRenderers)]
		[TestCase(ReturnType.Go, CustomEntryType.CustomRenderers)]
		[TestCase(ReturnType.Next, CustomEntryType.CustomRenderers)]
		[TestCase(ReturnType.Search, CustomEntryType.CustomRenderers)]
		[TestCase(ReturnType.Send, CustomEntryType.CustomRenderers)]
		public void VerifyKeyboardReturnType(ReturnType returnType, CustomEntryType customEntryType)
		{
			//Arrange
			var expectedCustomizableEntryPlaceholder = returnType.ToString();

			//Act
			OptionSelectionPage.SetEntryPickerType(customEntryType);
			OptionSelectionPage.TapOpenSelectEntryPageButton();

			PickEntryReturnTypePage.SelectReturnTypeFromPicker(returnType);

			//Assert
			var retrievedCustomizableEntryPlaceholder = PickEntryReturnTypePage.CustomizableEntryPlaceholder;
			Assert.AreEqual(expectedCustomizableEntryPlaceholder, retrievedCustomizableEntryPlaceholder);
		}
	}
}
