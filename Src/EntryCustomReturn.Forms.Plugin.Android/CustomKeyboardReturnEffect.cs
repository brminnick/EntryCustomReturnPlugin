using System;

using Android.App;
using Android.Widget;
using Android.Runtime;
using Android.Views.InputMethods;

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
			var customEntry = Element as CustomReturnEntry;
			var customControl = Control as EntryEditText;

			if (Control != null && customEntry != null)
			{
				KeyboardHelpers.SetKeyboardButtonType(customEntry.ReturnType, customControl);

				customControl.EditorAction += HandleEditorAction;
			}
		}

		void UnsetKeyboardReturnButton()
		{
			var customControl = Control as EntryEditText;

			if (Control != null)
			{
				KeyboardHelpers.SetKeyboardButtonType(ReturnType.Default, customControl);

				customControl.EditorAction -= HandleEditorAction;
			}
		}

		void HandleEditorAction(object sender, TextView.EditorActionEventArgs e)
		{
			var returnType = ReturnTypeEffect.GetReturnType(Element);

			ReturnTypeEffect.GetReturnCommandProperty(Element)?.Execute(null);
		}

		public static void HideSoftKeyboard(Activity activity)
		{
			var inputMethodManager = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);
			inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);
		}

	}
}
