using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
    /// <summary>
    /// CustomReturnEntry Interface
    /// </summary>
    public class CustomReturnEntry : Entry
    {
        static BindableProperty _returnCommandProperty;
        static BindableProperty _returnTypeProperty;

        /// <summary>
        /// Command Property that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public static BindableProperty ReturnCommandProperty => _returnCommandProperty ?? 
            (_returnCommandProperty = BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(CustomReturnEntry), null));

        /// <summary>
        /// Return Type Property of the Entry
        /// </summary>
        public static BindableProperty ReturnTypeProperty => _returnTypeProperty ??
            (_returnTypeProperty = BindableProperty.Create(propertyName: nameof(ReturnType),
                                                            returnType: typeof(ReturnType),
                                                            declaringType: typeof(CustomReturnEntry),
                                                            defaultValue: ReturnType.Done));
            
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
    }
}
