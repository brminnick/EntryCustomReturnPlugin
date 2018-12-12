using System;

using Android.Views;
using Android.Widget;
using Android.Runtime;
using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using EntryCustomReturn.Forms.Plugin.Android;
using EntryCustomReturn.Forms.Plugin.Abstractions;


[assembly: ExportRenderer(typeof(CustomReturnEntry), typeof(CustomReturnEntryRenderer))]
namespace EntryCustomReturn.Forms.Plugin.Android
{
    /// <summary>
    /// CustomReturnEntry Implementation
    /// </summary>
    [Preserve(AllMembers = true)]
    public sealed class CustomReturnEntryRenderer : EntryRenderer
    {
        public CustomReturnEntryRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element is CustomReturnEntry customEntry)
            {
                Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);

                Control.KeyPress += (sender, keyEventArgs) =>
                {
                    if (keyEventArgs?.Event?.KeyCode is Keycode.Enter && keyEventArgs?.Event?.Action is KeyEventActions.Up)
                        ExecuteCommand(customEntry);

                    keyEventArgs.Handled = false;
                };

                Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
                {
                    if (args?.Event?.KeyCode is Keycode.Enter)
                        return;

                    ExecuteCommand(customEntry);
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(CustomReturnEntry.ReturnTypeProperty.PropertyName))
            {
                if (Control != null && sender is CustomReturnEntry customEntry)
                    Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);
            }
        }

        void ExecuteCommand(CustomReturnEntry customEntry)
        {
            var returnCommand = customEntry.ReturnCommand;
            var returnCommandParameter = customEntry.ReturnCommandParameter;

            var canExecute = returnCommand?.CanExecute(returnCommandParameter) ?? true;

            if (canExecute)
                returnCommand?.Execute(returnCommandParameter);
        }
    }
}

