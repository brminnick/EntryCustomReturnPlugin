using System;

using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using EntryCustomReturn.Forms.Plugin.iOS;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ExportRenderer(typeof(CustomReturnEntry), typeof(CustomReturnEntryRenderer))]
namespace EntryCustomReturn.Forms.Plugin.iOS
{
	[Preserve(AllMembers = true)]
	public sealed class CustomReturnEntryRenderer : EntryRenderer
	{
		/// <summary>
		/// Used for registration with the dependency service
		/// </summary>
		/// <returns></returns>
		public new static void Init()
		{
			var temp = DateTime.Now;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			var customEntry = Element as CustomReturnEntry;

			if (Control != null && customEntry != null)
			{
				Control.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);

				Control.ShouldReturn += (UITextField tf) =>
				{
					customEntry?.ReturnCommand?.Execute(null);
					return true;
				};
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CustomReturnEntry.ReturnTypeProperty.PropertyName)
			{
				var customEntry = sender as CustomReturnEntry;

				if (Control != null && customEntry != null)
					Control.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);
			}
		}
	}
}
