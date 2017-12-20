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

            if (args.PropertyName == CustomReturnEntry.ReturnTypeProperty.PropertyName)
                SetKeyboardReturnButton();
        }

        void SetKeyboardReturnButton()
        {
            switch (Control)
            {
                case UITextField uiTextField:
                    uiTextField.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(Element));
                    uiTextField.ShouldReturn += HandleShouldReturn;
                    break;
            }
        }

        void UnsetKeyboardReturnButton()
        {
            switch (Control)
            {
                case UITextField uiTextField:
                    uiTextField.ReturnKeyType = UIReturnKeyType.Default;
                    uiTextField.ShouldReturn -= HandleShouldReturn;
                    break;
            }
        }

        bool HandleShouldReturn(UITextField textField)
        {
            CustomReturnEffect.GetReturnCommand(Element)?.Execute(CustomReturnEffect.GetReturnCommandParameter(Element));
            return true;
        }
    }
}
