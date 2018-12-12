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

            if (args.PropertyName.Equals(CustomReturnEntry.ReturnTypeProperty.PropertyName))
                SetKeyboardReturnButton();
        }

        void SetKeyboardReturnButton()
        {
            if (Control is FormsTextBox formsTextBox)
            {
                KeyboardHelpers.SetKeyboardEnterButton(formsTextBox, CustomReturnEffect.GetReturnType(Element));
                Control.KeyUp += HandleKeyUp;
            }
        }

        void UnsetKeyboardReturnButton()
        {
            if (Control is FormsTextBox formsTextBox)
            {
                KeyboardHelpers.SetKeyboardEnterButton(formsTextBox, ReturnType.Default);
                Control.KeyUp -= HandleKeyUp;
            }
        }

        void HandleKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key is Windows.System.VirtualKey.Enter)
                ExecuteCommand();
        }

        void ExecuteCommand()
        {
            var returnCommand = CustomReturnEffect.GetReturnCommand(Element);
            var returnCommandParameter = CustomReturnEffect.GetReturnCommandParameter(Element);

            var canExecute = returnCommand?.CanExecute(returnCommandParameter) ?? true;

            if (canExecute)
                returnCommand?.Execute(returnCommandParameter);
        }
    }
}
