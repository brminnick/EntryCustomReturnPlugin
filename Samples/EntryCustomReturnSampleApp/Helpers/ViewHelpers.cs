using System;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;
using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
	public static class ViewHelpers
	{
		public static View CreatePickEntryReturnTypePageLayout(InputViewType inputViewType, bool shouldUseEffects, PickEntryReturnTypeViewModel pickEntryReturnTypeViewModel)
		{
			InputView customizableInputView;

			switch (shouldUseEffects)
			{
				case true:
                    customizableInputView = InitializeInputView(inputViewType);
                    CustomReturnEffect.SetReturnType(customizableInputView, ReturnType.Go);
					customizableInputView.SetBinding(CustomReturnEffect.ReturnTypeProperty, nameof(pickEntryReturnTypeViewModel.EntryReturnType));
					break;
				case false:
					customizableInputView = new CustomReturnEntry();
					customizableInputView.SetBinding(CustomReturnEntry.ReturnTypeProperty, nameof(pickEntryReturnTypeViewModel.EntryReturnType));
					break;
				default:
					throw new Exception("Invalid Type");
			}

			customizableInputView.AutomationId = AutomationIdConstants.CustomizableEntryAutomationId;
			customizableInputView.SetBinding(Entry.PlaceholderProperty, nameof(pickEntryReturnTypeViewModel.EntryPlaceHolderText));

			var entryReturnTypePicker = new Picker
			{
				AutomationId = AutomationIdConstants.EntryReturnTypePickerAutomationId
			};
			entryReturnTypePicker.SetBinding(Picker.ItemsSourceProperty, nameof(pickEntryReturnTypeViewModel.EntryReturnTypePickerSource));
			entryReturnTypePicker.SetBinding(Picker.SelectedItemProperty, nameof(pickEntryReturnTypeViewModel.PickerSelection));

			return new StackLayout
			{
				Children = {
                    customizableInputView,
					entryReturnTypePicker
				}
			};
		}

		public static View CreateMultipleEntryPageLayout(InputViewType inputViewType, bool shouldUseEffects, MultipleEntryViewModel multipleEntryViewModel)
		{
            var defaultReturnTypeEntry = CreateInputView(inputViewType,
                                                         shouldUseEffects,
                                                         ReturnType.Default,
                                                         "Return Type: Default",
                                                         AutomationIdConstants.DefaultReturnTypeEntryAutomationId,
                                                         nameof(multipleEntryViewModel.DefaultReturnTypeEntryText));

			var nextReturnTypeEntry = CreateInputView(inputViewType,
                                                      shouldUseEffects,
                                                      ReturnType.Next,
                                                      "Return Type: Next",
                                                      AutomationIdConstants.NextReturnTypeEntryAutomationId,
                                                      nameof(multipleEntryViewModel.NextReturnTypeEntryText));

			var doneReturnTypeEntry = CreateInputView(inputViewType,
                                                      shouldUseEffects,
                                                      ReturnType.Done,
                                                      "Return Type: Done",
                                                      AutomationIdConstants.DoneReturnTypeEntryAutomationId,
                                                      nameof(multipleEntryViewModel.DoneReturnTypeEntryText));

			var sendReturnTypeEntry = CreateInputView(inputViewType,
                                                      shouldUseEffects,
                                                      ReturnType.Send,
                                                      "Return Type: Send",
                                                      AutomationIdConstants.SendReturnTypeEntryAutomationId,
                                                      nameof(multipleEntryViewModel.SendReturnTypeEntryText));

			var searchReturnTypeEntry = CreateInputView(inputViewType,
                                                        shouldUseEffects,
                                                        ReturnType.Search,
                                                        "Return Type: Search",
                                                        AutomationIdConstants.SearchReturnTypeEntryAutomationId,
                                                        nameof(multipleEntryViewModel.SearchReturnTypeEntryText));

			var goReturnTypeEntry = CreateInputView(inputViewType,
                                                    shouldUseEffects,
                                                    ReturnType.Go,
                                                    "Return Type: Go",
                                                    AutomationIdConstants.GoReturnTypeEntryAutomationId,
                                                    nameof(multipleEntryViewModel.GoReturnTypeEntryText));

			ConfigureEntryReturnCommand(shouldUseEffects, defaultReturnTypeEntry, () => nextReturnTypeEntry.Focus());
			ConfigureEntryReturnCommand(shouldUseEffects, nextReturnTypeEntry, () => doneReturnTypeEntry.Focus());
			ConfigureEntryReturnCommand(shouldUseEffects, doneReturnTypeEntry, () => sendReturnTypeEntry.Focus());
			ConfigureEntryReturnCommand(shouldUseEffects, sendReturnTypeEntry, () => searchReturnTypeEntry.Focus());
			ConfigureEntryReturnCommand(shouldUseEffects, searchReturnTypeEntry, () => goReturnTypeEntry.Focus());
			ConfigureGoReturnTypeEntryCommandBinding(shouldUseEffects, goReturnTypeEntry, multipleEntryViewModel);

			var goButton = new Button
			{
				Text = "Go",
				AutomationId = AutomationIdConstants.GoButtonAutomationId
			};
			goButton.SetBinding(Button.CommandProperty, nameof(multipleEntryViewModel.GoButtonCommand));

			var resultLabel = new Label
			{
				AutomationId = AutomationIdConstants.ResultsLabelAutomationId
			};
			resultLabel.SetBinding(Label.TextProperty, nameof(multipleEntryViewModel.ResultLabelText));


			var mainStackLayout = new StackLayout
			{
				Children = {
					defaultReturnTypeEntry,
					nextReturnTypeEntry,
					doneReturnTypeEntry,
					sendReturnTypeEntry,
					searchReturnTypeEntry,
					goReturnTypeEntry,
					goButton,
					resultLabel
				}
			};

			return new ScrollView
			{
				Content = mainStackLayout
			};
		}

		public static Thickness GetPagePadding()
		{
			switch (Device.RuntimePlatform)
			{
				case Device.Windows:
				case Device.WinPhone:
				case Device.Android:
					return new Thickness(10, 0, 10, 0);
				case Device.iOS:
					return new Thickness(10, 10, 10, 0);
				default:
					throw new Exception("OS Not Supported");
			}
		}

		static InputView CreateInputView(InputViewType inputViewType, bool shouldUseEffects, ReturnType returnType, string placeholder, string automationId, string bindingSource)
		{
            InputView inputView;

			switch (shouldUseEffects)
			{
				case true:
                    inputView = InitializeInputView(inputViewType);
                    CustomReturnEffect.SetReturnType(inputView, returnType);
					break;
				case false:
					inputView = new CustomReturnEntry
					{
						ReturnType = returnType,
					};
					break;
				default:
					throw new Exception("Invalid Type");
			}

            switch(inputViewType)
            {
                case InputViewType.Entry:
					((Entry)inputView).Placeholder = placeholder;
                    break;
            }

			inputView.AutomationId = automationId;
			inputView.SetBinding(Entry.TextProperty, bindingSource);

			return inputView;
		}

		static void ConfigureEntryReturnCommand(bool shouldUseEffects, InputView entry, Action action)
		{
			var command = new Command(action);

			switch (shouldUseEffects)
			{
				case true:
					CustomReturnEffect.SetReturnCommand(entry, command);
					break;
				case false:
					((CustomReturnEntry)entry).ReturnCommand = command;
					break;
				default:
					throw new Exception("Invalid Type");
			}
		}

		static void ConfigureGoReturnTypeEntryCommandBinding(bool shouldUseEffects, InputView goReturnTypeEntry, MultipleEntryViewModel multipleEntryViewModel)
		{
			switch (shouldUseEffects)
			{
				case true:
					goReturnTypeEntry.SetBinding(CustomReturnEffect.ReturnCommandProperty, nameof(multipleEntryViewModel.GoReturnTypeEntryReturnCommand));
                    goReturnTypeEntry.SetBinding(CustomReturnEffect.ReturnCommandParameterProperty, nameof(multipleEntryViewModel.AdditionalText));
					break;
				case false:
					goReturnTypeEntry.SetBinding(CustomReturnEntry.ReturnCommandProperty, nameof(multipleEntryViewModel.GoReturnTypeEntryReturnCommand));
                    goReturnTypeEntry.SetBinding(CustomReturnEntry.ReturnCommandParameterProperty, nameof(multipleEntryViewModel.AdditionalText));
					break;
			}

			Device.BeginInvokeOnMainThread(goReturnTypeEntry.Unfocus);
		}

        static InputView InitializeInputView(InputViewType inputViewType)
        {
            switch(inputViewType)
            {
                case InputViewType.Entry:
                    return new Entry();

                case InputViewType.Editor:
                    return new Editor();

                default:
                    throw new Exception("InputViewType Not Supported");
            }
        }
	}
}
