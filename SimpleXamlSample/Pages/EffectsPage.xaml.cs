using EntryCustomReturn.Forms.Plugin.Abstractions;

using SimpleSamples.Common.Forms;

namespace SimpleXamlSample
{
    public partial class EffectsPage : BaseEntryContentPage
    {
        public EffectsPage()
        {
            InitializeComponent();

            CustomReturnEffect.SetReturnCommand(EffectsEntry, BaseEntryReturnCommand);
        }

        void HandleToggled(object sender, Xamarin.Forms.ToggledEventArgs e) => BaseEntryReturnCommandCanExecute = e.Value;
    }
}
