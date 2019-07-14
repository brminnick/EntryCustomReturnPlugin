using System;

using Windows.UI.Xaml.Input;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.UWP;

using EntryCustomReturn.Forms.Plugin.UWP;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ExportRenderer(typeof(CustomReturnEntry), typeof(CustomReturnEntryRenderer))]
namespace EntryCustomReturn.Forms.Plugin.UWP
{
    [Preserve(AllMembers = true)]
    public sealed class CustomReturnEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// Used for registration with the dependency service
        /// </summary>
        /// <returns></returns>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element is CustomReturnEntry customEntry)
            {
                KeyboardHelpers.SetKeyboardEnterButton(Control, customEntry.ReturnType);

                Control.KeyUp += HandleControlKeyUp;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(CustomReturnEntry.ReturnTypeProperty.PropertyName))
            {
                if (Control != null && sender is CustomReturnEntry customEntry)
                    KeyboardHelpers.SetKeyboardEnterButton(Control, customEntry.ReturnType);
            }

        }

        void ExecuteCommand(in CustomReturnEntry customEntry)
        {
            var returnCommand = customEntry.ReturnCommand;
            var returnCommandParameter = customEntry.ReturnCommandParameter;

            var canExecute = returnCommand?.CanExecute(returnCommandParameter) ?? true;

            if (canExecute)
                returnCommand?.Execute(returnCommandParameter);
        }

        void HandleControlKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key is Windows.System.VirtualKey.Enter
                && Element is CustomReturnEntry customEntry)
            {
                ExecuteCommand(customEntry);
            }
        }
    }
}
