using System.Text;

namespace EntryCustomReturnSampleApp.Shared
{
	public static class StringBuilderHelpers
	{
        public static StringBuilder ConvertTextInputToResultsLabel(string defaultReturnTypeEntryText,
                                                                   string nextReturnTypeEntryText,
                                                                   string doneReturnTypeEntryText,
                                                                   string sendReturnTypeEntryText,
                                                                   string searchReturnTypeEntryText,
                                                                   string goReturnTypeEntryText,
                                                                   object commandParamter = null)
		{
			var outputStringBuilder = new StringBuilder();
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

            outputStringBuilder.AppendLine($"Command Parameter Type: {commandParamter.GetType()}");

            return outputStringBuilder;
		}
	}
}
