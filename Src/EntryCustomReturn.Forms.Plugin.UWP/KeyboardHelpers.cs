using Windows.UI.Xaml.Input;

using Xamarin.Forms.Platform.UWP;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturn.Forms.Plugin.UWP
{
    static class KeyboardHelpers
    {
        internal static InputScopeNameValue GetKeyboardButtonType(ReturnType returnType)
        {
            switch (returnType)
            {
                case ReturnType.Default:
                case ReturnType.Done:
                case ReturnType.Go:
                case ReturnType.Next:
                case ReturnType.Send:
                    return InputScopeNameValue.Default;
                case ReturnType.Search:
                    return InputScopeNameValue.Search;
                default:
                    throw new System.Exception("Return Type Not Supported");
            }
        }

        internal static void SetKeyboardEnterButton(FormsTextBox control, ReturnType returnType)
        {
            var scopeName = new InputScopeName()
            {
                NameValue = GetKeyboardButtonType(returnType)
            };
            var inputScope = new InputScope
            {
                Names = { scopeName }
            };
            control.InputScope = inputScope;
        }
    }
}
