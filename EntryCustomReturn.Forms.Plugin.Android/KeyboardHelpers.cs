using Android.Views.InputMethods;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturn.Forms.Plugin.Android
{
	static class KeyboardHelpers
	{
		internal static ImeAction GetKeyboardButtonType(ReturnType returnType)
		{
			switch (returnType)
			{
				case ReturnType.Go:
					return ImeAction.Go;
				case ReturnType.Next:
					return ImeAction.Next;
				case ReturnType.Send:
					return ImeAction.Send;
				case ReturnType.Search:
					return ImeAction.Search;
				case ReturnType.Done:
					return ImeAction.Done;
				case ReturnType.Default:
					return ImeAction.Done;
                default:
                    throw new System.Exception("Return Type Not Supported");
			}
		}
	}
}
