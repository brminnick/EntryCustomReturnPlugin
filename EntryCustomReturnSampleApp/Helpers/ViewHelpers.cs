using System;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using MvvmSamples.Shared;
using MvvmSamples.Common.Forms;

namespace EntryCustomReturnSampleApp
{
    public static class ViewHelpers
    {
        public static View CreatePickEntryReturnTypePageLayout(bool shouldUseEffects)
        {
            Entry customizableEntry;

            if (shouldUseEffects)
            {
                customizableEntry = new Entry();
                customizableEntry.SetBinding(CustomReturnEffect.ReturnTypeProperty, nameof(PickEntryReturnTypeViewModel.EntryReturnType));
            }
            else
            {
                customizableEntry = new CustomReturnEntry();
                customizableEntry.SetBinding(CustomReturnEntry.ReturnTypeProperty, nameof(PickEntryReturnTypeViewModel.EntryReturnType));
            }

            customizableEntry.AutomationId = AutomationIdConstants.CustomizableEntryAutomationId;
            customizableEntry.SetBinding(Entry.PlaceholderProperty, nameof(PickEntryReturnTypeViewModel.EntryPlaceHolderText));

            var entryReturnTypePicker = new Picker
            {
                AutomationId = AutomationIdConstants.EntryReturnTypePickerAutomationId
            };
            entryReturnTypePicker.SetBinding(Picker.ItemsSourceProperty, nameof(PickEntryReturnTypeViewModel.EntryReturnTypePickerSource));
            entryReturnTypePicker.SetBinding(Picker.SelectedItemProperty, nameof(PickEntryReturnTypeViewModel.PickerSelection));

            return new StackLayout
            {
                Children = {
                    customizableEntry,
                    entryReturnTypePicker
                }
            };
        }

        public static View CreateMultipleEntryPageLayout(bool shouldUseEffects)
        {
            var defaultReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                        EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Default,
                                                        MultipleEntryPageConstants.DefaultReturnTypeEntryPlaceholder,
                                                        AutomationIdConstants.DefaultReturnTypeEntryAutomationId,
                                                        nameof(MultipleEntryViewModel.DefaultReturnTypeEntryText));

            var nextReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Next,
                                                    MultipleEntryPageConstants.NextReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.NextReturnTypeEntryAutomationId,
                                                    nameof(MultipleEntryViewModel.NextReturnTypeEntryText));

            var doneReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Done,
                                                    MultipleEntryPageConstants.DoneReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.DoneReturnTypeEntryAutomationId,
                                                    nameof(MultipleEntryViewModel.DoneReturnTypeEntryText));

            var sendReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Send,
                                                    MultipleEntryPageConstants.SendReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.SendReturnTypeEntryAutomationId,
                                                    nameof(MultipleEntryViewModel.SendReturnTypeEntryText));

            var searchReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Search,
                                                    MultipleEntryPageConstants.SearchReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.SearchReturnTypeEntryAutomationId,
                                                    nameof(MultipleEntryViewModel.SearchReturnTypeEntryText));

            var goReturnTypeEntry = CreateEntry(shouldUseEffects,
                                                    EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Go,
                                                    MultipleEntryPageConstants.GoReturnTypeEntryPlaceholder,
                                                    AutomationIdConstants.GoReturnTypeEntryAutomationId,
                                                    nameof(MultipleEntryViewModel.GoReturnTypeEntryText));

            ConfigureEntryReturnCommand(defaultReturnTypeEntry, () => nextReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(nextReturnTypeEntry, () => doneReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(doneReturnTypeEntry, () => sendReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(sendReturnTypeEntry, () => searchReturnTypeEntry.Focus());
            ConfigureEntryReturnCommand(searchReturnTypeEntry, () => goReturnTypeEntry.Focus());
            ConfigureGoReturnTypeEntryCommandBinding(goReturnTypeEntry);

            var goButton = new Button
            {
                Text = MultipleEntryPageConstants.GoButtonText,
                AutomationId = AutomationIdConstants.GoButtonAutomationId
            };
            goButton.SetBinding(Button.CommandProperty, nameof(MultipleEntryViewModel.GoButtonCommand));
            goButton.SetBinding(Button.CommandParameterProperty, nameof(MultipleEntryViewModel.GoButtonCommandParameter));

            var resultLabel = new Label
            {
                AutomationId = AutomationIdConstants.ResultsLabelAutomationId
            };
            resultLabel.SetBinding(Label.TextProperty, nameof(MultipleEntryViewModel.ResultLabelText));

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

        static Entry CreateEntry(bool shouldUseEffects, EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType returnType, string placeholder, string automationId, string bindingSource)
        {
            Entry entry;

            if (shouldUseEffects)
            {
                entry = new Entry();
                CustomReturnEffect.SetReturnType(entry, returnType);
            }
            else
            {
                entry = new CustomReturnEntry { ReturnType = returnType };
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
                    throw new NotSupportedException("Invalid Type");
            }
        }

        static void ConfigureGoReturnTypeEntryCommandBinding(Entry goReturnTypeEntry)
        {
            switch (goReturnTypeEntry)
            {
                case CustomReturnEntry customReturnEntry:
                    customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandProperty, nameof(MultipleEntryViewModel.GoReturnTypeEntryReturnCommand));
                    customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandParameterProperty, nameof(MultipleEntryViewModel.GoReturnTypeEntryReturnCommandParameter));
                    break;
                case Entry baseEntry:
                    baseEntry.SetBinding(CustomReturnEffect.ReturnCommandProperty, nameof(MultipleEntryViewModel.GoReturnTypeEntryReturnCommand));
                    baseEntry.SetBinding(CustomReturnEffect.ReturnCommandParameterProperty, nameof(MultipleEntryViewModel.GoReturnTypeEntryReturnCommandParameter));
                    break;
                default:
                    throw new NotSupportedException("Invalid Type");
            }

            Device.BeginInvokeOnMainThread(goReturnTypeEntry.Unfocus);
        }
    }
}
