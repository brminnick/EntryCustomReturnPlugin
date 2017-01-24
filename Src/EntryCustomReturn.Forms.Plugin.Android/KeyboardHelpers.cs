using System;
using System.Diagnostics;

using Android.Widget;
using Android.Views.InputMethods;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturn.Forms.Plugin.Android
{
	static class KeyboardHelpers
	{
		internal static void SetKeyboardButtonType(ReturnType returnType, EditText control)
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
