using System;
using System.Diagnostics;

using Android.Views;
using Android.Widget;
using Android.Runtime;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using EntryCustomReturn.Forms.Plugin.Android;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ResolutionGroupName("EntryCustomReturn.Forms.Plugin")]
[assembly: ExportEffect(typeof(CustomKeyboardReturnEffect), nameof(CustomKeyboardReturnEffect))]
namespace EntryCustomReturn.Forms.Plugin.Android
{
	[Preserve(AllMembers = true)]
	sealed class CustomKeyboardReturnEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			SetKeyboardReturnButton();
		}

		protected override void OnDetached()
		{
			UnsetKeyboardReturnButton();
		}

		void SetKeyboardReturnButton()
		{
			var entry = Element as InputView;

            if (Control is EntryEditText entryEditText)
			{
				entryEditText.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(entry));

				entryEditText.EditorAction += HandleEditorAction;
				entryEditText.KeyPress += HandleKeyPress;
			}
            else if(Control is EditText editText)
            {
				editText.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(entry));
                editText.InputType = global::Android.Text.InputTypes.TextFlagImeMultiLine;
				editText.EditorAction += HandleEditorAction;
				editText.KeyPress += HandleKeyPress;
            }
		}

        void HandleKeyPress(object sender, global::Android.Views.View.KeyEventArgs e)
        {
			if (e?.Event?.KeyCode == Keycode.Enter && e?.Event?.Action == KeyEventActions.Up)
				CustomReturnEffect.GetReturnCommand(Element)?.Execute(CustomReturnEffect.GetReturnCommandParameter(Element));

			e.Handled = false;
        }

        void UnsetKeyboardReturnButton()
		{
			try
			{
                if (Control is EntryEditText entryEditText)
				{
					entryEditText.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(ReturnType.Default);
					entryEditText.EditorAction -= HandleEditorAction;
                    entryEditText.KeyPress -= HandleKeyPress;
				}
				else if (Control is EditText editText)
				{
					editText.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(ReturnType.Default);
                    editText.InputType = default(global::Android.Text.InputTypes);
					editText.EditorAction -= HandleEditorAction;
					editText.KeyPress -= HandleKeyPress;
				}
			}
			catch (ObjectDisposedException e)
			{
				Debug.WriteLine(e);
			}
		}

		void HandleEditorAction(object sender, TextView.EditorActionEventArgs e)
		{
			if (e?.Event?.KeyCode == Keycode.Enter)
				return;
            
            CustomReturnEffect.GetReturnCommand(Element)?.Execute(CustomReturnEffect.GetReturnCommandParameter(Element));
		}
	}
}
