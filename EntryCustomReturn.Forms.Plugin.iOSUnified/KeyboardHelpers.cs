using UIKit;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturn.Forms.Plugin.iOS
{
    static class KeyboardHelpers
    {
        internal static UIReturnKeyType GetKeyboardButtonType(in ReturnType returnType)
        {
            switch (returnType)
            {
                case ReturnType.Go:
                    return UIReturnKeyType.Go;
                case ReturnType.Next:
                    return UIReturnKeyType.Next;
                case ReturnType.Send:
                    return UIReturnKeyType.Send;
                case ReturnType.Search:
                    return UIReturnKeyType.Search;
                case ReturnType.Done:
                    return UIReturnKeyType.Done;
                case ReturnType.Default:
                    return UIReturnKeyType.Default;
                default:
                    throw new System.NotSupportedException($"{nameof(ReturnType)}, {returnType}, Not Supported");
            }
        }
    }
}
