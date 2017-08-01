using System;
using System.Collections.Generic;

using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace EntryCustomReturnSampleApp
{
    public class OptionSelectionPage : BaseContentPage<BaseViewModel>
    {
        #region Constant Fields
        readonly Button _openMultileEntryPageButton, _openPickerEntryPageButton;
        readonly Picker _customEntryTypePicker, _inputTypePicker;
        #endregion

        #region Constructors
        public OptionSelectionPage()
        {
            _openMultileEntryPageButton = new Button
            {
                Text = "Multiple Entry Page",
                AutomationId = AutomationIdConstants.OpenMultileEntryPageButton
            };

            _openPickerEntryPageButton = new Button
            {
                Text = "Return Type Picker Page",
                AutomationId = AutomationIdConstants.OpenPickerEntryPageButton
            };

            var customEntryTypeLabel = new Label { Text = "Generate" };

            _customEntryTypePicker = new Picker
            {
                AutomationId = AutomationIdConstants.CustomEntryTypePicker,
                ItemsSource = PickerConstants.CustomEntryPickerItemSourceList
            };
            _customEntryTypePicker.SelectedIndex = 0;

            var inputTypeLabel = new Label { Text = "Using" };

            _inputTypePicker = new Picker
            {
                AutomationId = AutomationIdConstants.InputTypePicker,
                ItemsSource = PickerConstants.InputViewPickerItemSourceList
            };
            _inputTypePicker.SelectedIndex = 0;

            Title = PageTitles.OptionSelectionPageTitle;

            NavigationPage.SetBackButtonTitle(this, "");

            Padding = new Thickness(10);

            Content = new StackLayout
            {
                Children = {
                    customEntryTypeLabel,
                    _customEntryTypePicker,
                    inputTypeLabel,
                    _inputTypePicker,
                    _openPickerEntryPageButton,
                    _openMultileEntryPageButton
    }
            };
        }
        #endregion

        #region Methods
        protected override void SubscribeEventHandlers()
        {
            _openPickerEntryPageButton.Clicked += HandleOpenSelectEntryPageButtonClicked;
            _openMultileEntryPageButton.Clicked += HandleOpenMultipleEntryPageButtonClicked;

            AreEventHandlersSubscribed = true;
        }

        protected override void UnsubscribeEventHandlers()
        {
            _openPickerEntryPageButton.Clicked -= HandleOpenSelectEntryPageButtonClicked;
            _openMultileEntryPageButton.Clicked -= HandleOpenMultipleEntryPageButtonClicked;

            AreEventHandlersSubscribed = false;
        }

        void HandleOpenMultipleEntryPageButtonClicked(object sender, EventArgs e)
        {
            var inputTypeSelected = (InputViewType)_inputTypePicker.SelectedIndex;

            switch (_customEntryTypePicker.SelectedItem)
            {
                case PickerConstants.CustomEntryTypePickerItemListEffectsText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleEffectsEntryPage(inputTypeSelected)));
                    break;

                case PickerConstants.CustomEntryTypePickerItemListCustomRenderersText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleCustomRendererEntryPage(inputTypeSelected)));
                    break;

                default:
                    throw new Exception($"Unsupported EntryTypePicker: {_customEntryTypePicker.SelectedItem}");
            }
        }

        void HandleOpenSelectEntryPageButtonClicked(object sender, EventArgs e)
        {
            var inputTypeSelected = (InputViewType)_inputTypePicker.SelectedIndex;

            switch (_customEntryTypePicker.SelectedItem)
            {
                case PickerConstants.CustomEntryTypePickerItemListEffectsText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickEffectsEntryReturnTypePage(inputTypeSelected)));
                    break;

                case PickerConstants.CustomEntryTypePickerItemListCustomRenderersText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickCustomRendererEntryReturnTypePage(inputTypeSelected)));
                    break;

                default:
                    throw new Exception($"Unsupported EntryTypePicker: {_customEntryTypePicker.SelectedItem}");
            }
        }
        #endregion
    }
}
