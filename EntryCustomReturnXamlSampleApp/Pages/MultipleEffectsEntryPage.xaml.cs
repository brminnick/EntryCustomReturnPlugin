using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturnXamlSampleApp
{
    public partial class MultipleEffectsEntryPage : ContentPage
    {
        public MultipleEffectsEntryPage()
        {
            InitializeComponent();

            CustomReturnEffect.SetReturnCommand(DefaultReturnTypeEntry, new Command(() => NextReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(NextReturnTypeEntry, new Command(() => DoneReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(DoneReturnTypeEntry, new Command(() => SendReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(SendReturnTypeEntry, new Command(() => SearchReturnTypeEntry.Focus()));
            CustomReturnEffect.SetReturnCommand(SearchReturnTypeEntry, new Command(() => GoReturnTypeEntry.Focus()));
        }
    }
}
