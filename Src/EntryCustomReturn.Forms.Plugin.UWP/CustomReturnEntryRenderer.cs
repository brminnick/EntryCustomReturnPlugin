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

            var customEntry = Element as CustomReturnEntry;


            if (Control != null && customEntry != null)
            {
                KeyboardHelpers.SetKeyboardEnterButton(Control, customEntry.ReturnType);

                Control.KeyUp += (sender, eventArgs) =>
                {
                    if (eventArgs.Key == Windows.System.VirtualKey.Enter)
                        customEntry.ReturnCommand?.Execute(null);
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomReturnEntry.ReturnTypeProperty.PropertyName)
            {
                var customEntry = sender as CustomReturnEntry;

                if (Control != null && customEntry != null)
                    KeyboardHelpers.SetKeyboardEnterButton(Control, customEntry.ReturnType);
            }

        }
    }
}
