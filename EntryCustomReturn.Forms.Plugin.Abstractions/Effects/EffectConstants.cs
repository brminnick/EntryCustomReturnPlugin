using System.ComponentModel;

namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
    public static class EffectConstants
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
        public const string ResolutionGroupName = "EntryCustomReturn.Forms.Plugin";
		internal static string Name => $"{ResolutionGroupName}.{EffectName}";
		const string EffectName = "CustomKeyboardReturnEffect";
	}
}
