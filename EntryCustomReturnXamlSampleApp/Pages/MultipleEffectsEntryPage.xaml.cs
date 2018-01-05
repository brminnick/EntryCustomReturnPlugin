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

            CustomReturnEffect.SetReturnType(DefaultReturnTypeEntry, ReturnType.Default);
            CustomReturnEffect.SetReturnType(NextReturnTypeEntry, ReturnType.Next);
            CustomReturnEffect.SetReturnType(DoneReturnTypeEntry, ReturnType.Done);
            CustomReturnEffect.SetReturnType(SendReturnTypeEntry, ReturnType.Send);
            CustomReturnEffect.SetReturnType(SearchReturnTypeEntry, ReturnType.Search);
            CustomReturnEffect.SetReturnType(GoReturnTypeEntry, ReturnType.Go);

            CustomReturnEffect.SetReturnCommand(DefaultReturnTypeEntry, new Command(() => NextReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(NextReturnTypeEntry, new Command(() => DoneReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(DoneReturnTypeEntry, new Command(() => SendReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(SendReturnTypeEntry, new Command(() => SearchReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(SearchReturnTypeEntry, new Command(() => GoReturnTypeEntry.Focus()));
            GoReturnTypeEntry.SetBinding(CustomReturnEffect.ReturnCommandProperty, nameof(ViewModel.GoReturnTypeEntryReturnCommand));

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
