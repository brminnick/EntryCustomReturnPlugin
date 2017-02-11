using System;
namespace EntryCustomReturnSampleApp.Shared
{
	public static class AutomationIdConstants
	{
		#region MultipleEntryPage
		public const string GoButtonAutomationId = "GoButton";
		public const string GoReturnTypeEntryAutomationId = "GoReturnTypeEntry";
		public const string DefaultReturnTypeEntryAutomationId = "DefaultReturnTypeEntry";
		public const string DoneReturnTypeEntryAutomationId = "DoneReturnTypeEntry";
		public const string NextReturnTypeEntryAutomationId = "NextReturnTypeEntry";
		public const string ResultsLabelAutomationId = "ResultsLabel";
		public const string SearchReturnTypeEntryAutomationId = "SearchReturnTypeEntry";
		public const string SendReturnTypeEntryAutomationId = "SendReturnTypeEntry";
		#endregion

		#region OptionSelectionPage
		public const string OpenMultileEntryPageButtonAutomationId = "OpenMultileEntryPageButton";
		public const string OpenPickerEntryPageButtonAutomationId = "OpenPickerEntryPageButton";
		public const string EntryTypePickerAutomationId = "EntryTypePicker";
		#endregion

		#region PickEntryReturnType
		public const string CustomizableEntryAutomationId = "CustomizableEntry";
		public const string EntryReturnTypePickerAutomationId = "EntryReturnTypePicker";
		#endregion
	}
}
