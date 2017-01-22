using System;

using Xamarin.Forms;

namespace CustomReturnEntry.Forms.Plugin.Abstractions
{
    /// <summary>
    /// CustomReturnEntry Interface
    /// </summary>
    public class CustomReturnEntry : Entry
	{
        /// <summary>
        /// Occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public new event EventHandler Completed;

        /// <summary>
        /// Return Type Property of the Entry
        /// </summary>
        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(propertyName: nameof(ReturnType),
                returnType: typeof(ReturnType),
                declaringType: typeof(CustomReturnEntry),
                defaultValue: ReturnType.Done);

        /// <summary>
        /// Type of the Keyboard Return Key
        /// </summary>
        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        /// <summary>
        /// Invoke Completed event
        /// </summary>
        public void InvokeCompleted()
        {
            Completed?.Invoke(this, null);
        }
    }

    /// <summary>
    /// Custom type for keyboard return key
    /// </summary>
    public enum ReturnType
    {
        Go,
        Next,
        Done,
        Send,
        Search
    }
}
