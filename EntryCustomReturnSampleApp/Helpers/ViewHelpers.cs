using System;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using MvvmSamples.Shared;
using MvvmSamples.Common.Forms;

namespace EntryCustomReturnSampleApp
{
    public static class ViewHelpers
    {
        public static View CreatePickEntryReturnTypePageLayout(bool shouldUseEffects, PickEntryReturnTypeViewModel pickEntryReturnTypeViewModel)
        {
            Entry customizableEntry;

            switch (shouldUseEffects)
            {
                case true:
                    customizableEntry = new Entry();
                    CustomReturnEffect.SetReturnType(customizableEntry, ReturnType.Go);
                    customizableEntry.SetBinding(CustomReturnEffect.ReturnTypeProperty, nameof(pickEntryReturnTypeViewModel.EntryReturnType));
                    break;
                case false:
                    customizableEntry = new CustomReturnEntry();
                    customizableEntry.SetBinding(CustomReturnEntry.ReturnTypeProperty, nameof(pickEntryReturnTypeViewModel.EntryReturnType));
                    break;
                default:
                    throw new Exception("Invalid Type");
            }

            customizableEntry.AutomationId = AutomationIdConstants.CustomizableEntryAutomationId;
            customizableEntry.SetBinding(Entry.PlaceholderProperty, nameof(pickEntryReturnTypeViewModel.EntryPlaceHolderText));

            var entryReturnTypePicker = new Picker
            {
                AutomationId = AutomationIdConstants.EntryReturnTypePickerAutomationId
            };
            entryReturnTypePicker.SetBinding(Picker.ItemsSourceProperty, nameof(pickEntryReturnTypeViewModel.EntryReturnTypePickerSource));
            entryReturnTypePicker.SetBinding(Picker.SelectedItemProperty, nameof(pickEntryReturnTypeViewModel.PickerSelection));

            return new StackLayout
            {
                Children = {
                    customizableEntry,
                    entryReturnTypePicker
                }
            };
        }

        public static View CreateMultipleEntryPageLayout(bool shouldUseEffects, MultipleEntryViewModel multipleEntryViewModel)
        {
            var defaultReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                        ReturnType.Default,
                                                        MultipleEntryPageConstants.DefaultReturnTypeEntryPlaceholder,
                                                        AutomationIdConstants.DefaultReturnTypeEntryAutomationId,
                                                        nameof(multipleEntryViewModel.DefaultReturnTypeEntryText));

            var nextReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    ReturnType.Next,
                                                    MultipleEntryPageConstants.NextReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.NextReturnTypeEntryAutomationId,
                                                    nameof(multipleEntryViewModel.NextReturnTypeEntryText));

            var doneReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    ReturnType.Done,
                                                    MultipleEntryPageConstants.DoneReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.DoneReturnTypeEntryAutomationId,
                                                    nameof(multipleEntryViewModel.DoneReturnTypeEntryText));

            var sendReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    ReturnType.Send,
                                                    MultipleEntryPageConstants.SendReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.SendReturnTypeEntryAutomationId,
                                                    nameof(multipleEntryViewModel.SendReturnTypeEntryText));

            var searchReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    ReturnType.Search,
                                                    MultipleEntryPageConstants.SearchReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.SearchReturnTypeEntryAutomationId,
                                                    nameof(multipleEntryViewModel.SearchReturnTypeEntryText));

            var goReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    ReturnType.Go,
                                                    MultipleEntryPageConstants.GoReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.GoReturnTypeEntryAutomationId,
                                                    nameof(multipleEntryViewModel.GoReturnTypeEntryText));

            ConfigureEntryReturnCommand(defaultReturnTypeEntry, () => nextReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(nextReturnTypeEntry, () => doneReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(doneReturnTypeEntry, () => sendReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(sendReturnTypeEntry, () => searchReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(searchReturnTypeEntry, () => goReturnTypeEntry.Focus());
            ConfigureGoReturnTypeEntryCommandBinding(goReturnTypeEntry, multipleEntryViewModel);

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

            return new ScrollView { Content = mainStackLayout };
        }

        public static Thickness GetPagePadding()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                case Device.Android:
                    return new Thickness(10, 0, 10, 0);
                case Device.iOS:
                    return new Thickness(10, 10, 10, 0);
                default:
                    throw new Exception("OS Not Supported");
            }
        }

        static Entry CreateEntry(bool shouldUseEffects, ReturnType returnType, string placeholder, string automationId, string bindingSource)
        {
            Entry entry;

            switch (shouldUseEffects)
            {
                case true:
                    entry = new Entry();
                    CustomReturnEffect.SetReturnType(entry, returnType);
                    break;
                case false:
                    entry = new CustomReturnEntry { ReturnType = returnType };
                    break;
                default:
                    throw new Exception("Invalid Type");
            }
            entry.Placeholder = placeholder;
            entry.AutomationId = automationId;
            entry.SetBinding(Entry.TextProperty, bindingSource);

            return entry;
        }

        static void ConfigureEntryReturnCommand(Entry entry, Action action)
        {
            var command = new Command(action);

            switch (entry)
            {
                case CustomReturnEntry customReturnEntry:
                    customReturnEntry.ReturnCommand = command;
                    break;
                case Entry baseEntry:
                    CustomReturnEffect.SetReturnCommand(baseEntry, command);
                    break;
                default:
                    throw new Exception("Invalid Type");
            }
        }

        static void ConfigureGoReturnTypeEntryCommandBinding(Entry goReturnTypeEntry, MultipleEntryViewModel multipleEntryViewModel)
        {
            switch (goReturnTypeEntry)
            {
                case CustomReturnEntry customReturnEntry:
                    customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandProperty, nameof(multipleEntryViewModel.GoReturnTypeEntryReturnCommand));
                    break;
                case Entry baseEntry:
                    baseEntry.SetBinding(CustomReturnEffect.ReturnCommandProperty, nameof(multipleEntryViewModel.GoReturnTypeEntryReturnCommand));
                    break;
                default:
                    throw new Exception("Invalid Type");

            }

            Device.BeginInvokeOnMainThread(goReturnTypeEntry.Unfocus);
        }
    }
}
