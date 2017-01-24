using System;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using EntryCustomReturnSampleApp.Shared;
using System.Linq.Expressions;

namespace EntryCustomReturnSampleApp
{
	public class MultipleEntryPage : BaseContentPage<MultipleEntryViewModel>
	{
		#region Constructors
		public MultipleEntryPage(bool shouldUseEffects)
		{
			var nextReturnTypeEntry = CreateEntry<MultipleEntryViewModel>(shouldUseEffects,
																		  ReturnType.Next,
																		  "Return Type: Next",
																		  AutomationIdConstants.NextReturnTypeEntryAutomationId,
																		  vm => vm.NextReturnTypeEntryText);

			var goReturnTypeEntry = CreateEntry<MultipleEntryViewModel>(shouldUseEffects,
																		ReturnType.Go,
																	   	"Return Type: Go",
																	   	AutomationIdConstants.GoReturnTypeEntryAutomationId,
																	   	vm => vm.GoReturnTypeEntryText);

			var searchReturnTypeEntry = CreateEntry<MultipleEntryViewModel>(shouldUseEffects,
																		   ReturnType.Search,
																		   "Return Type: Search",
																		   AutomationIdConstants.SearchReturnTypeEntryAutomationId,
																		   vm => vm.SearchReturnTypeEntryText);

			var sendReturnTypeEntry = CreateEntry<MultipleEntryViewModel>(shouldUseEffects,
																		  	ReturnType.Send,
																			"Return Type: Send",
																		  	AutomationIdConstants.SendReturnTypeEntryAutomationId,
																	 		vm => vm.SendReturnTypeEntryText);

			var doneReturnTypeEntry = CreateEntry<MultipleEntryViewModel>(shouldUseEffects,
																		  ReturnType.Done,
																		  "Return Type: Done",
																		  AutomationIdConstants.DoneReturnTypeEntryAutomationId,
																		  vm => vm.DoneReturnTypeEntryText);

			ConfigureEntryReturnCommand(shouldUseEffects, nextReturnTypeEntry, () => doneReturnTypeEntry.Focus());
			ConfigureEntryReturnCommand(shouldUseEffects, doneReturnTypeEntry, () => sendReturnTypeEntry.Focus());
			ConfigureEntryReturnCommand(shouldUseEffects, sendReturnTypeEntry, () => searchReturnTypeEntry.Focus());
			ConfigureEntryReturnCommand(shouldUseEffects, searchReturnTypeEntry, () => goReturnTypeEntry.Focus());
			ConfigureGoReturnTypeEntryCommandBinding(shouldUseEffects, goReturnTypeEntry);

			var goButton = new Button
			{
				Text = "Go",
				AutomationId = AutomationIdConstants.GoButtonAutomationId
			};
			goButton.SetBinding<MultipleEntryViewModel>(Button.CommandProperty, vm => vm.GoButtonCommand);

			var resultLabel = new Label
			{
				AutomationId = AutomationIdConstants.ResultsLabelAutomationId
			};
			resultLabel.SetBinding<MultipleEntryViewModel>(Label.TextProperty, vm => vm.ResultLabelText);


			Title = PageTitles.MultipleEntryPageTitle;

			Padding = new Thickness(10);

			var mainStackLayout = new StackLayout
			{
				Children = {
					nextReturnTypeEntry,
					doneReturnTypeEntry,
					sendReturnTypeEntry,
					searchReturnTypeEntry,
					goReturnTypeEntry,
					goButton,
					resultLabel
				}
			};

			Content = new ScrollView
			{
				Content = mainStackLayout
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

		Entry CreateEntry<T>(bool shouldUseEffects, ReturnType returnType, string placeholder, string automationId, Expression<Func<T, object>> textPropertyBindingSource)
		{
			Entry entry;

			switch (shouldUseEffects)
			{
				case true:
					entry = new Entry();
					ReturnTypeEffect.SetReturnType(entry, returnType);
					break;
				case false:
					entry = new CustomReturnEntry
					{
						ReturnType = returnType,
					};
					break;
				default:
					throw new Exception("Invalid Type");
			}
			entry.Placeholder = placeholder;
			entry.AutomationId = automationId;
			entry.SetBinding<T>(Entry.TextProperty, textPropertyBindingSource);

			return entry;
		}

		void ConfigureEntryReturnCommand(bool shouldUseEffects, Entry entry, Action action)
		{
			var command = new Command(action);

			switch (shouldUseEffects)
			{
				case true:
					ReturnTypeEffect.SetReturnCommandProperty(entry, command);
					break;
				case false:
					((CustomReturnEntry)entry).ReturnCommand = command;
					break;
				default:
					throw new Exception("Invalid Type");
			}
		}

		void ConfigureGoReturnTypeEntryCommandBinding(bool shouldUseEffects, Entry goReturnTypeEntry)
		{
			switch (shouldUseEffects)
			{
				case true:
					goReturnTypeEntry.SetBinding<MultipleEntryViewModel>(ReturnTypeEffect.ReturnCommandProperty, vm => vm.GoReturnTypeEntryReturnCommand);
					break;
				case false:
					goReturnTypeEntry.SetBinding<MultipleEntryViewModel>(CustomReturnEntry.ReturnCommandProperty, vm => vm.GoReturnTypeEntryReturnCommand);
					break;
			}
		}
		#endregion
	}
}
