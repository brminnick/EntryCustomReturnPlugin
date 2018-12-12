using System;
using System.Diagnostics;

using Android.Views;
using Android.Widget;
using Android.Runtime;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using EntryCustomReturn.Forms.Plugin.Android;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ResolutionGroupName(EffectConstants.ResolutionGroupName)]
[assembly: ExportEffect(typeof(CustomKeyboardReturnEffect), nameof(CustomKeyboardReturnEffect))]
namespace EntryCustomReturn.Forms.Plugin.Android
{
    [Preserve(AllMembers = true)]
    sealed class CustomKeyboardReturnEffect : PlatformEffect
    {
        protected override void OnAttached() => SetKeyboardReturnButton();

        protected override void OnDetached() => UnsetKeyboardReturnButton();

        void SetKeyboardReturnButton()
        {
            if (Element is Entry entry
                && Control is FormsEditText customControl)
            {
                customControl.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(entry));

                customControl.EditorAction += HandleEditorAction;
                customControl.KeyPress += HandleKeyPress;
            }
        }

        void UnsetKeyboardReturnButton()
        {
            try
            {
                if (Control is FormsEditText formsEditText)
                {
                    formsEditText.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(ReturnType.Default);
                    formsEditText.EditorAction -= HandleEditorAction;
                    formsEditText.KeyPress -= HandleKeyPress;
                }
            }
            catch (ObjectDisposedException e)
            {
                Debug.WriteLine(e);
            }
        }

        void HandleEditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            if (e?.Event?.KeyCode is Keycode.Enter)
                return;

            ExecuteCommand();
        }

        void HandleKeyPress(object sender, global::Android.Views.View.KeyEventArgs e)
        {
            if (e?.Event?.KeyCode is Keycode.Enter && e?.Event?.Action is KeyEventActions.Up)
                ExecuteCommand();

            e.Handled = false;
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
