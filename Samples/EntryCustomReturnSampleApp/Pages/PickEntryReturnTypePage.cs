using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public class PickEntryReturnTypePage : BaseContentPage<PickEntryReturnTypeViewModel>
	{
		#region Constructors
		public PickEntryReturnTypePage()
		{
			var customizableEntry = new CustomReturnEntry
			{
				AutomationId = AutomationIdConstants.CustomizableEntryAutomationId
			};
			customizableEntry.SetBinding<PickEntryReturnTypeViewModel>(CustomReturnEntry.ReturnTypeProperty, vm => vm.EntryReturnType);
			customizableEntry.SetBinding<PickEntryReturnTypeViewModel>(CustomReturnEntry.PlaceholderProperty, vm => vm.EntryPlaceHolderText);

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
