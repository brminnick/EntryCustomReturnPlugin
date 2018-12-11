using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using EntryCustomReturn.Forms.Plugin.iOS;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ResolutionGroupName(EffectConstants.ResolutionGroupName)]
[assembly: ExportEffect(typeof(CustomKeyboardReturnEffect), nameof(CustomKeyboardReturnEffect))]
namespace EntryCustomReturn.Forms.Plugin.iOS
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
            if (Control is UITextField uiTextField)
            {
                uiTextField.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(Element));
                uiTextField.ShouldReturn += HandleShouldReturn;
            }
        }

        void UnsetKeyboardReturnButton()
        {
            if (Control is UITextField uiTextField)
            {
                uiTextField.ReturnKeyType = UIReturnKeyType.Default;
                uiTextField.ShouldReturn -= HandleShouldReturn;
            }
        }

        bool HandleShouldReturn(UITextField textField)
        {
            var returnCommand = CustomReturnEffect.GetReturnCommand(Element);
            var returnCommandParameter = CustomReturnEffect.GetReturnCommandParameter(Element);

            var canExecute = returnCommand?.CanExecute(returnCommandParameter) ?? false;

            if (canExecute)
            {
                returnCommand?.Execute(returnCommandParameter);

                return true;
            }

            return false;
        }
    }
}
