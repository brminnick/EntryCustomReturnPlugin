using System;
using System.Diagnostics;

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
	public class CustomKeyboardReturnEffect : PlatformEffect
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
			var customControl = Control as EntryEditText;
			var entry = Element as Entry;

			if (customControl != null && entry != null)
			{
				customControl.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(ReturnTypeEffect.GetReturnType(entry));

				customControl.EditorAction += HandleEditorAction;
			}
		}

		void UnsetKeyboardReturnButton()
		{
			var customControl = Control as EntryEditText;

			try
			{
				if (customControl != null)
				{
					customControl.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(ReturnType.Default);
					customControl.EditorAction -= HandleEditorAction;
				}
			}
			catch (ObjectDisposedException e)
			{
				Debug.WriteLine(e);
			}
		}

		void HandleEditorAction(object sender, TextView.EditorActionEventArgs e)
		{
			ReturnTypeEffect.GetReturnCommandProperty(Element)?.Execute(null);
		}
	}
}
