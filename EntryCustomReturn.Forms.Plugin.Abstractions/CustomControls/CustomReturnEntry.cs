using System.Windows.Input;

using Xamarin.Forms;

namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
    /// <summary>
    /// CustomReturnEntry Interface
    /// </summary>
    public class CustomReturnEntry : Entry
    {
        static BindableProperty _returnCommandProperty, _returnTypeProperty, _returnCommandParameterProperty;

        /// <summary>
        /// Command Property that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public static BindableProperty ReturnCommandProperty => _returnCommandProperty ??
            (_returnCommandProperty = BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(CustomReturnEntry)));

        /// <summary>
        /// Return Type Property of the Entry
        /// </summary>
        public static BindableProperty ReturnTypeProperty => _returnTypeProperty ??
            (_returnTypeProperty = BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(CustomReturnEntry), ReturnType.Default));

        /// <summary>
        /// Backing store for the ReturnCommandParameter bindable property
        /// </summary>
        public static readonly BindableProperty ReturnCommandParameterProperty = _returnCommandParameterProperty ??
            (_returnCommandParameterProperty = BindableProperty.Create(nameof(ReturnCommandParameter), typeof(object), typeof(CustomReturnEntry)));

        /// <summary>
        /// Type of the Keyboard Return Key
        /// </summary>
        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        /// <summary>
        /// Occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public ICommand ReturnCommand
        {
            get => (ICommand)GetValue(ReturnCommandProperty);
            set => SetValue(ReturnCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the ReturnCommand parameter
        /// </summary>
        public object ReturnCommandParameter
        {
            get => GetValue(ReturnCommandParameterProperty);
            set => SetValue(ReturnCommandParameterProperty, value);
        }
    }
}
