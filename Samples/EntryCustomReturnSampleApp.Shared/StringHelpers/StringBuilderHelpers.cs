using System.Text;

namespace EntryCustomReturnSampleApp.Shared
{
	public static class StringBuilderHelpers
	{
		public static string ConvertTextInputToResultsLabel(string nextReturnTypeEntryText,
													string doneReturnTypeEntryText,
													string sendReturnTypeEntryText,
													string searchReturnTypeEntryText,
													string goReturnTypeEntryText)
		{
			var outputStringBuilder = new StringBuilder();
			outputStringBuilder.AppendLine($"{nameof(nextReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{nextReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(doneReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{doneReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(sendReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{sendReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(searchReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{searchReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(goReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{goReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			return outputStringBuilder.ToString();
		}
	}
}
