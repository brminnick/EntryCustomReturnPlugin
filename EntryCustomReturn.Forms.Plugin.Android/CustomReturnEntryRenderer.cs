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
        /// <summary>
        /// Creates a new CustomReturnEntryRenderer
        /// </summary>
        /// <param name="context">Android context</param>
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

        /// <summary>
        /// Triggered when the Element changes
        /// </summary>
        /// <param name="e">ElementChangedEventArgs</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element is CustomReturnEntry customEntry)
            {
                Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);

                Control.KeyPress += HandleControlKeyPress;

                Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
                {
                    if (args?.Event?.KeyCode is Keycode.Enter)
                        return;

                    ExecuteCommand(customEntry);
                };
            }
        }

        /// <summary>
        /// Triggered when the Element Property changes
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">PropertyChangedEventArgs</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(CustomReturnEntry.ReturnTypeProperty.PropertyName))
            {
                if (Control != null && sender is CustomReturnEntry customEntry)
                    Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);
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

        void HandleControlKeyPress(object sender, KeyEventArgs e)
        {
            if (Control != null && Element is CustomReturnEntry customEntry)
            {
                if (e?.Event?.KeyCode is Keycode.Enter && e?.Event?.Action is KeyEventActions.Up)
                    ExecuteCommand(customEntry);
            }

            e.Handled = false;
        }
    }
}

