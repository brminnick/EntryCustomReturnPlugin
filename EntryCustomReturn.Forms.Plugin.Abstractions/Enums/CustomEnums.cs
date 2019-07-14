namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
    /// <summary>
    /// Custom type for keyboard return key
    /// </summary>
    public enum ReturnType
    {
        /// <summary>
        /// Uses the default keyboard return key
        /// </summary>
		Default,

        /// <summary>
        /// Uses the Done keyboard return key
        /// </summary>
        Done,

        /// <summary>
        /// Uses the Go keyboard return key
        /// </summary>
        Go,

        /// <summary>
        /// Uses the Next keyboard return key
        /// </summary>
        Next,

        /// <summary>
        /// Uses the Search keyboard return key
        /// </summary>
        Search,

        /// <summary>
        /// Uses the Send keyboard return key
        /// </summary>
        Send,
    }
}
