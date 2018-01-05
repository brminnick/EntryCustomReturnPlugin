using System;

using Xamarin.Forms;

using MvvmSamples.Shared;
using MvvmSamples.Common.Forms;

namespace EntryCustomReturnXamlSampleApp
{
    public partial class OptionSelectionPage : BaseContentPage<BaseViewModel>
    {
        public OptionSelectionPage()
        {
            InitializeComponent();

            EntryTypePicker.SelectedIndex = 0;
            NavigationPage.SetBackButtonTitle(this, "");
        }

        protected override void SubscribeEventHandlers()
        {
            OpenPickerEntryPageButton.Clicked += HandleOpenSelectEntryPageButtonClicked;
            OpenMultipleEntryPageButton.Clicked += HandleOpenMultipleEntryPageButtonClicked;
        }

        protected override void UnsubscribeEventHandlers()
        {
            OpenPickerEntryPageButton.Clicked -= HandleOpenSelectEntryPageButtonClicked;
            OpenMultipleEntryPageButton.Clicked -= HandleOpenMultipleEntryPageButtonClicked;
        }

        void HandleOpenMultipleEntryPageButtonClicked(object sender, EventArgs e)
        {
            switch (EntryTypePicker.SelectedItem)
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
            switch (EntryTypePicker.SelectedItem)
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
    }
}
