using System;
using System.Threading.Tasks;

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
	public class CustomReturnEntryRenderer : EntryRenderer
	{
		/// <summary>
		/// Used for registration with the dependency service
		/// </summary>
		/// <returns></returns>
		public new async static Task Init()
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

				Control.ShouldReturn += (UITextField tf) =>
				{
					customEntry?.InvokeCompleted();
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
					SetKeyboardButtonType(customEntry.ReturnType);
			}

		}

		void SetKeyboardButtonType(ReturnType returnType)
		{
			switch (returnType)
			{
				case ReturnType.Go:
					Control.ReturnKeyType = UIReturnKeyType.Go;
					break;
				case ReturnType.Next:
					Control.ReturnKeyType = UIReturnKeyType.Next;
					break;
				case ReturnType.Send:
					Control.ReturnKeyType = UIReturnKeyType.Send;
					break;
				case ReturnType.Search:
					Control.ReturnKeyType = UIReturnKeyType.Search;
					break;
				case ReturnType.Done:
					Control.ReturnKeyType = UIReturnKeyType.Done;
					break;
				default:
					Control.ReturnKeyType = UIReturnKeyType.Default;
					break;
			}
		}
	}
}
