using System;

using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using EntryCustomReturn.Forms.Plugin.iOS;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ResolutionGroupName("EntryCustomReturn.Forms.Plugin")]
[assembly: ExportEffect(typeof(CustomKeyboardReturnEffect), nameof(CustomKeyboardReturnEffect))]
namespace EntryCustomReturn.Forms.Plugin.iOS
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

		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

			if (args.PropertyName == CustomReturnEntry.ReturnTypeProperty.PropertyName)
				SetKeyboardReturnButton();
		}

		void SetKeyboardReturnButton()
		{
            if (Control is UITextField textFieldControl)
            {
                textFieldControl.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(Element));
                textFieldControl.ShouldReturn += HandleShouldReturn;
            }
            else if(Control is UITextView textViewControl)
            {
				textViewControl.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(CustomReturnEffect.GetReturnType(Element));
				textViewControl.ShouldChangeText += HandleShouldChangeText;
            }
		}

        void UnsetKeyboardReturnButton()
		{
            if (Control is UITextField textFieldControl)
            {
                textFieldControl.ReturnKeyType = UIReturnKeyType.Default;
                textFieldControl.ShouldReturn -= HandleShouldReturn;
            }
            else if (Control is UITextView textViewControl)
            {
                textViewControl.ReturnKeyType = UIReturnKeyType.Default;
                textViewControl.ShouldChangeText -= HandleShouldChangeText;
            }
		}

		bool HandleShouldReturn(UITextField textField)
		{
            CustomReturnEffect.GetReturnCommand(Element)?.Execute(CustomReturnEffect.GetReturnCommandParameter(Element));
			return true;
		}

		bool HandleShouldChangeText(UITextView textView, NSRange range, string text)
		{
            if (text.Equals("\n"))
                CustomReturnEffect.GetReturnCommand(Element)?.Execute(CustomReturnEffect.GetReturnCommandParameter(Element));

			return true;
		}
	}
}
