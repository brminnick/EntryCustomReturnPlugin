using Windows.UI.Xaml.Input;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.UWP;

using EntryCustomReturn.Forms.Plugin.UWP;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ResolutionGroupName("EntryCustomReturn.Forms.Plugin")]
[assembly: ExportEffect(typeof(CustomKeyboardReturnEffect), nameof(CustomKeyboardReturnEffect))]
namespace EntryCustomReturn.Forms.Plugin.UWP
{
    [Preserve(AllMembers = true)]
    sealed class CustomKeyboardReturnEffect : PlatformEffect
    {
        protected override void OnAttached() => SetKeyboardReturnButton();

        protected override void OnDetached() => UnsetKeyboardReturnButton();

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == CustomReturnEntry.ReturnTypeProperty.PropertyName)
                SetKeyboardReturnButton();
        }

        void SetKeyboardReturnButton()
        {
            switch (Control)
            {
                case FormsTextBox formsTextBox:
                    KeyboardHelpers.SetKeyboardEnterButton(customControl, CustomReturnEffect.GetReturnType(Element));
                    Control.KeyUp += HandleKeyUp;
                    break;
            }
        }

        void UnsetKeyboardReturnButton()
        {
            switch (Control)
            {
                case FormsTextBox formsTextBox:
                    KeyboardHelpers.SetKeyboardEnterButton(customControl, ReturnType.Default);
                    Control.KeyUp -= HandleKeyUp;
                    break;
            }
        }

        void HandleKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                CustomReturnEffect.GetReturnCommand(Element)?.Execute(CustomKeyboardReturnEffect.GetReturnCommandParameter(Element));
        }
    }
}
