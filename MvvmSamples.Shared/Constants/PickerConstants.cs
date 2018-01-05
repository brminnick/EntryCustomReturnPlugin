using System.Collections.Generic;

namespace MvvmSamples.Shared
{
	public static class PickerConstants
	{
		public const string PickerItemListEffectsText = "Effects";
		public const string PickerItemListCustomRenderersText = "CustomRenderers";

		public static readonly List<string> PickerItemSourceList = new List<string>
			{
				PickerItemListEffectsText,
				PickerItemListCustomRenderersText
			};
	}

	public enum CustomEntryType
	{
		Effects,
		CustomRenderers
	}
}
