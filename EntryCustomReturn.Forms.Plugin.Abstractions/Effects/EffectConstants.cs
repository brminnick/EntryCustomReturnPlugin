using System.ComponentModel;

namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
    /// <summary>
    /// Constants used internally for EntryCustomReturn
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EffectConstants
    {
        /// <summary>
        /// Used to define the Resolution Group Name for EntryCustomReturn Effects
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const string ResolutionGroupName = "EntryCustomReturn.Forms.Plugin";
        internal const string Name = ResolutionGroupName + "." + EffectName;
        const string EffectName = "CustomKeyboardReturnEffect";
    }
}
