using NUnit.Framework;

using Xamarin.UITest;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturnUITests
{
	public class PickEntryReturnTypeTests : BaseTest
	{
		public PickEntryReturnTypeTests(Platform platform) : base(platform)
		{
		}

		public override void TestSetup()
		{
			base.TestSetup();

			OptionSelectionPage.WaitForPageToLoad();
			OptionSelectionPage.TapOpenSelectEntryPageButton();
		}

		[TestCase(ReturnType.Done)]
		[TestCase(ReturnType.Go)]
		[TestCase(ReturnType.Next)]
		[TestCase(ReturnType.Search)]
		[TestCase(ReturnType.Send)]
		[Test]
		public void VerifyKeyboardReturnType(ReturnType returnType)
		{
			//Arrange
			var expectedCustomizableEntryPlaceholder = returnType.ToString();

			//Act
			PickEntryReturnTypePage.SelectReturnTypeFromPicker(returnType);

			//Assert
			var retrievedCustomizableEntryPlaceholder = PickEntryReturnTypePage.CustomizableEntryPlaceholder;
			Assert.AreEqual(expectedCustomizableEntryPlaceholder, retrievedCustomizableEntryPlaceholder);
		}
	}
}
