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
			var customControl = Control as FormsEditText;
			var entry = Element as Entry;

			if (customControl != null && entry != null)
			{
				customControl.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(entry));

				customControl.EditorAction += HandleEditorAction;
				customControl.KeyPress += HandleKeyPress;
			}
		}

        void HandleKeyPress(object sender, global::Android.Views.View.KeyEventArgs e)
        {
			if (e?.Event?.KeyCode == Keycode.Enter && e?.Event?.Action == KeyEventActions.Up)
				CustomReturnEffect.GetReturnCommand(Element)?.Execute(null);

			e.Handled = false;
        }

        void UnsetKeyboardReturnButton()
		{
			var customControl = Control as FormsEditText;

			try
			{
				if (customControl != null)
				{
					customControl.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(ReturnType.Default);
					customControl.EditorAction -= HandleEditorAction;
                    customControl.KeyPress -= HandleKeyPress;
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
            
            CustomReturnEffect.GetReturnCommand(Element)?.Execute(null);
		}
	}
}
