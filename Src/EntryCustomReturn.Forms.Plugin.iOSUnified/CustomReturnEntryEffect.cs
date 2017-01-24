using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using EntryCustomReturn.Forms.Plugin.iOS;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ResolutionGroupName("EntryCustomReturn.Forms.Plugin")]
[assembly: ExportEffect(typeof(CustomReturnEntryEffect), nameof(CustomReturnEntryEffect))]
namespace EntryCustomReturn.Forms.Plugin.iOS
{
	public class CustomReturnEntryEffect : PlatformEffect
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
			var customControl = Control as UITextField;

			if (customControl == null)
				return;

			customControl.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(ReturnTypeEffect.GetReturnType(Element));

			customControl.ShouldReturn += HandleShouldReturn;
		}

		void UnsetKeyboardReturnButton()
		{
			var customControl = Control as UITextField;

			if (customControl == null)
				return;

			customControl.ReturnKeyType = UIReturnKeyType.Default;

			customControl.ShouldReturn -= HandleShouldReturn;
		}

		bool HandleShouldReturn(UITextField textField)
		{
			ReturnTypeEffect.GetReturnCommandProperty(Element)?.Execute(null);
			return true;
		}
	}
}
