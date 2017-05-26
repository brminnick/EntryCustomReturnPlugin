using System;

using Android.Views;
using Android.Widget;
using Android.Runtime;
using Android.Text.Method;

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
	public sealed class CustomReturnEntryRenderer : EntryRenderer
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

				Control.KeyPress += (sender, keyEventArgs) =>
				{
					if (keyEventArgs?.Event?.KeyCode == Keycode.Enter && keyEventArgs?.Event?.Action == KeyEventActions.Up)
						customEntry.ReturnCommand?.Execute(null);

					keyEventArgs.Handled = false;
				};

				Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
				{
					if (args?.Event?.KeyCode == Keycode.Enter)
						return;

					customEntry.ReturnCommand?.Execute(null);
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

