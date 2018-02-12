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
    }
}
