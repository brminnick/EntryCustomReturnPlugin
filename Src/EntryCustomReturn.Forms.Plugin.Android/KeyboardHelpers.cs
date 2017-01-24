using Android.Views.InputMethods;

using Xamarin.Forms.Platform.Android;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturn.Forms.Plugin.Android
{
	public static class KeyboardHelpers
	{
		public static void SetKeyboardButtonType(ReturnType returnType, EntryEditText control)
		{
			switch (returnType)
			{
				case ReturnType.Go:
					control.ImeOptions = ImeAction.Go;
					control.SetImeActionLabel("Go", ImeAction.Go);
					break;
				case ReturnType.Next:
					control.ImeOptions = ImeAction.Next;
					control.SetImeActionLabel("Next", ImeAction.Next);
					break;
				case ReturnType.Send:
					control.ImeOptions = ImeAction.Send;
					control.SetImeActionLabel("Send", ImeAction.Send);
					break;
				case ReturnType.Search:
					control.ImeOptions = ImeAction.Search;
					control.SetImeActionLabel("Search", ImeAction.Search);
					break;
				default:
					control.ImeOptions = ImeAction.Done;
					control.SetImeActionLabel("Done", ImeAction.Done);
					break;
			}
		}
	}
}
