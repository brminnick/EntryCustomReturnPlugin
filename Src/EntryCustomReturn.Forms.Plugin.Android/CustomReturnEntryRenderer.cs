using System;

using Android.Widget;
using Android.Runtime;
using Android.Views.InputMethods;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using EntryCustomReturn.Forms.Plugin.Droid;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ExportRenderer(typeof(CustomReturnEntry), typeof(CustomReturnEntryRenderer))]
namespace EntryCustomReturn.Forms.Plugin.Droid
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
				SetKeyboardButtonType(customEntry.ReturnType);

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
					SetKeyboardButtonType(customEntry.ReturnType);
			}

		}

		void SetKeyboardButtonType(ReturnType returnType)
		{
			switch (returnType)
			{
				case ReturnType.Go:
					Control.ImeOptions = ImeAction.Go;
					Control.SetImeActionLabel("Go", ImeAction.Go);
					break;
				case ReturnType.Next:
					Control.ImeOptions = ImeAction.Next;
					Control.SetImeActionLabel("Next", ImeAction.Next);
					break;
				case ReturnType.Send:
					Control.ImeOptions = ImeAction.Send;
					Control.SetImeActionLabel("Send", ImeAction.Send);
					break;
				case ReturnType.Search:
					Control.ImeOptions = ImeAction.Search;
					Control.SetImeActionLabel("Search", ImeAction.Search);
					break;
				default:
					Control.ImeOptions = ImeAction.Done;
					Control.SetImeActionLabel("Done", ImeAction.Done);
					break;
			}
		}
	}
}

