﻿using EntryCustomReturn.Forms.Plugin.Abstractions;

using Xamarin.Forms;

namespace EntryCustomReturnSampleApp
{
	public class SelectEntryPage : BaseContentPage<SelectEntryViewModel>
	{
		#region Constructors
		public SelectEntryPage()
		{
			var customizableEntry = new CustomReturnEntry();
			customizableEntry.SetBinding<SelectEntryViewModel>(CustomReturnEntry.ReturnTypeProperty, vm => vm.EntryReturnType);
			customizableEntry.SetBinding<SelectEntryViewModel>(CustomReturnEntry.PlaceholderProperty, vm => vm.EntryPlaceHolderText);

			var entryReturnTypePicker = new Picker();
			entryReturnTypePicker.SetBinding<SelectEntryViewModel>(Picker.ItemsSourceProperty, vm => vm.EntryReturnTypePickerSource);
			entryReturnTypePicker.SetBinding<SelectEntryViewModel>(Picker.SelectedItemProperty, vm => vm.PickerSelection);

			Title = "Pick Return Type";

			Padding = new Thickness(10);

			Content = new StackLayout
			{
				Children = {
					customizableEntry,
					entryReturnTypePicker
				}
			};
		}
		#endregion

		#region Methods
		protected override void SubscribeEventHandlers()
		{
			AreEventHandlersSubscribed = true;
		}

		protected override void UnsubscribeEventHandlers()
		{
			AreEventHandlersSubscribed = false;
		}
		#endregion
	}
}
