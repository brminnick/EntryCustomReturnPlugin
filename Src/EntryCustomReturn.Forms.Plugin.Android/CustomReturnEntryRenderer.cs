using System;

using Android.Widget;
using Android.Runtime;
using Android.Views.InputMethods;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using EntryCustomReturn.Forms.Plugin.Android;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ExportRenderer(typeof(CustomReturnEntry), typeof(CustomReturnEntryRenderer))]
namespace EntryCustomReturn.Forms.Plugin.Android
{
	/// <summary>
	/// CustomReturnEntry Implementation
	/// </summary>
	[Preserve(AllMembers = true)]
	public class CustomReturnEntryRenderer : EntryRenderer
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Init()
		{
			var temp = DateTime.Now;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			var customEntry = Element as CustomReturnEntry;

			if (Control != null && customEntry != null)
			{
				Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);

				Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
				{
					if (customEntry?.ReturnType != ReturnType.Next)
						customEntry?.Unfocus();

					customEntry?.ReturnCommand?.Execute(null);
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
					Control.ImeOptions = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);
			}

		}
	}
}

