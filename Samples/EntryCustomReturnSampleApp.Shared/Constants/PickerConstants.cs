using System.Collections.Generic;

namespace EntryCustomReturnSampleApp.Shared
{
	public static class PickerConstants
	{
		public const string CustomEntryTypePickerItemListEffectsText = "Effects";
		public const string CustomEntryTypePickerItemListCustomRenderersText = "CustomRenderers";
        public const string InputViewPickerItemListEntryText = "Entry";
        public const string InputViewPickerItemListEditorText = "Editor";

		public static readonly List<string> CustomEntryPickerItemSourceList = new List<string>
			{
				CustomEntryTypePickerItemListEffectsText,
				CustomEntryTypePickerItemListCustomRenderersText
			};

		public static readonly List<string> InputViewPickerItemSourceList = new List<string>
			{
                InputViewPickerItemListEditorText,
			    InputViewPickerItemListEntryText
			};
	}

	public enum CustomEntryType
	{
		Effects,
		CustomRenderers
	}

    public enum InputViewType
    {
		Editor,
        Entry
    }
}
