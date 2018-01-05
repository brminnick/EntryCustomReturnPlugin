using Xamarin.Forms;

using MvvmSamples.Common.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturnXamlSampleApp
{
    public partial class MultipleCustomRendererEntryPage : BaseContentPage<MultipleEntryViewModel>
    {
        public MultipleCustomRendererEntryPage()
        {
            InitializeComponent();

            DefaultReturnTypeEntry.ReturnCommand = new Command(() => NextReturnTypeEntry.Focus());
            NextReturnTypeEntry.ReturnCommand = new Command(() => DoneReturnTypeEntry.Focus());
            DoneReturnTypeEntry.ReturnCommand = new Command(() => SendReturnTypeEntry.Focus());
            SendReturnTypeEntry.ReturnCommand = new Command(() => SearchReturnTypeEntry.Focus());
            SearchReturnTypeEntry.ReturnCommand = new Command(() => GoReturnTypeEntry.Focus());
            GoReturnTypeEntry.SetBinding(CustomReturnEntry.ReturnCommandProperty, nameof(ViewModel.GoReturnTypeEntryReturnCommand));

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
