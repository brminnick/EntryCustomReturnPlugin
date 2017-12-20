using System.Text;

namespace EntryCustomReturnSampleApp.Shared
{
	public static class StringBuilderHelpers
	{
		public static string ConvertTextInputToResultsLabel(string commandParameterText,
                                                                string defaultReturnTypeEntryText,
            													string nextReturnTypeEntryText,
            													string doneReturnTypeEntryText,
            													string sendReturnTypeEntryText,
            													string searchReturnTypeEntryText,
            													string goReturnTypeEntryText)
		{
			var outputStringBuilder = new StringBuilder();

            outputStringBuilder.AppendLine(commandParameterText);
            outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(defaultReturnTypeEntryText)}: {defaultReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(nextReturnTypeEntryText)}: {nextReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(doneReturnTypeEntryText)}: {doneReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(sendReturnTypeEntryText)}: {sendReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(searchReturnTypeEntryText)}: {searchReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(goReturnTypeEntryText)}: {goReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			return outputStringBuilder.ToString();
		}
	}
}
