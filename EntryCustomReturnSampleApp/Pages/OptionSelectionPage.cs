using System;

using Xamarin.Forms;

using MvvmSamples.Shared;
using MvvmSamples.Common.Forms;

namespace EntryCustomReturnSampleApp
{
    public class OptionSelectionPage : BaseContentPage<BaseViewModel>
    {
        #region Constant Fields
        readonly Button _openMultipleEntryPageButton, _openPickerEntryPageButton;
        readonly Picker _entryTypePicker;
        #endregion

        #region Constructors
        public OptionSelectionPage()
        {
            _openMultipleEntryPageButton = new Button
            {
                Text = OpenSelectionPageConstants.OpenMultipleEntryPageButtonText,
                AutomationId = AutomationIdConstants.OpenMultileEntryPageButtonAutomationId
            };

            _openPickerEntryPageButton = new Button
            {
                Text = OpenSelectionPageConstants.OpenPickerEntryPageButtonText,
                AutomationId = AutomationIdConstants.OpenPickerEntryPageButtonAutomationId
            };

            var pickerLabel = new Label
            {
                Text = OpenSelectionPageConstants.PickerLabelText
            };

            _entryTypePicker = new Picker
            {
                AutomationId = AutomationIdConstants.EntryTypePickerAutomationId,
                ItemsSource = PickerConstants.PickerItemSourceList
            };
            _entryTypePicker.SelectedIndex = 0;

            Title = PageTitles.OptionSelectionPageTitle;

            NavigationPage.SetBackButtonTitle(this, "");

            Padding = new Thickness(10);

            Content = new StackLayout
            {
                Children = {
                    pickerLabel,
                    _entryTypePicker,
                    _openPickerEntryPageButton,
                    _openMultipleEntryPageButton
                }
            };
        }
        #endregion

        #region Methods
        protected override void SubscribeEventHandlers()
        {
            _openPickerEntryPageButton.Clicked += HandleOpenSelectEntryPageButtonClicked;
            _openMultipleEntryPageButton.Clicked += HandleOpenMultipleEntryPageButtonClicked;
        }

        protected override void UnsubscribeEventHandlers()
        {
            _openPickerEntryPageButton.Clicked -= HandleOpenSelectEntryPageButtonClicked;
            _openMultipleEntryPageButton.Clicked -= HandleOpenMultipleEntryPageButtonClicked;
        }

        void HandleOpenMultipleEntryPageButtonClicked(object sender, EventArgs e)
        {
            switch (_entryTypePicker.SelectedItem)
            {
                case PickerConstants.PickerItemListEffectsText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleEffectsEntryPage()));
                    break;

                case PickerConstants.PickerItemListCustomRenderersText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new MultipleCustomRendererEntryPage()));
                    break;

                default:
                    throw new Exception("Selected Item Not Supported");
            }
        }

        void HandleOpenSelectEntryPageButtonClicked(object sender, EventArgs e)
        {
            switch (_entryTypePicker.SelectedItem)
            {
                case PickerConstants.PickerItemListEffectsText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickEffectsEntryReturnTypePage()));
                    break;

                case PickerConstants.PickerItemListCustomRenderersText:
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new PickCustomRendererEntryReturnTypePage()));
                    break;

                default:
                    throw new Exception("Selected Item Not Supported");
            }
        }
        #endregion
    }
}
