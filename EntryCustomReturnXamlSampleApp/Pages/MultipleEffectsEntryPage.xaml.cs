using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using MvvmSamples.Common.Forms;

namespace EntryCustomReturnXamlSampleApp
{
    public partial class MultipleEffectsEntryPage : BaseContentPage<MultipleEntryViewModel>
    {
        public MultipleEffectsEntryPage()
        {
            InitializeComponent();

            CustomReturnEffect.SetReturnCommand(DefaultReturnTypeEntry, new Command(() => NextReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(NextReturnTypeEntry, new Command(() => DoneReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(DoneReturnTypeEntry, new Command(() => SendReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(SendReturnTypeEntry, new Command(() => SearchReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(SearchReturnTypeEntry, new Command(() => GoReturnTypeEntry.Focus()));

            Padding = GetDefaultPagePadding();
        }

        protected override void SubscribeEventHandlers()
        {

        }

        protected override void UnsubscribeEventHandlers()
        {

        }
    }
}
