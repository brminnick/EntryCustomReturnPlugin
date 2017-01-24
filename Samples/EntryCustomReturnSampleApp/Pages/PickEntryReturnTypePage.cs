using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using EntryCustomReturnSampleApp.Shared;
using System;

namespace EntryCustomReturnSampleApp
{
	public class PickEntryReturnTypePage : BaseContentPage<PickEntryReturnTypeViewModel>
	{
		#region Constructors
		public PickEntryReturnTypePage(bool shouldUseEffects)
		{
			Entry customizableEntry;

			switch (shouldUseEffects)
			{
				case true:
					customizableEntry = new Entry();
					ReturnTypeEffect.SetReturnType(customizableEntry, ReturnType.Go);
					customizableEntry.SetBinding<PickEntryReturnTypeViewModel>(ReturnTypeEffect.ReturnTypeProperty, vm => vm.EntryReturnType);
					break;
				case false:
					customizableEntry = new CustomReturnEntry();
					customizableEntry.SetBinding<PickEntryReturnTypeViewModel>(CustomReturnEntry.ReturnTypeProperty, vm => vm.EntryReturnType);
					break;
				default:
					throw new Exception("Invalid Type");
			}

			customizableEntry.AutomationId = AutomationIdConstants.CustomizableEntryAutomationId;
			customizableEntry.SetBinding<PickEntryReturnTypeViewModel>(Entry.PlaceholderProperty, vm => vm.EntryPlaceHolderText);

			var entryReturnTypePicker = new Picker
			{
				AutomationId = AutomationIdConstants.EntryReturnTypePickerAutomationId
			};
			entryReturnTypePicker.SetBinding<PickEntryReturnTypeViewModel>(Picker.ItemsSourceProperty, vm => vm.EntryReturnTypePickerSource);
			entryReturnTypePicker.SetBinding<PickEntryReturnTypeViewModel>(Picker.SelectedItemProperty, vm => vm.PickerSelection);

			Title = PageTitles.PickEntryReturnTypePageTitle;

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
