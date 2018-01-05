using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using SimpleSamples.Shared;
using SimpleSamples.Common.Forms;

namespace SimpleXamlSample
{
    public partial class EffectsPage : BaseEntryContentPage
    {
        public EffectsPage()
        {
            InitializeComponent();

            CustomReturnEffect.SetReturnType(EffectsEntry, ReturnType.Go);
            CustomReturnEffect.SetReturnCommand(EffectsEntry, new Command<string>(async title => await ExecuteEntryCommand(title)));
			CustomReturnEffect.SetReturnCommandParameter(EffectsEntry, EntryConstants.CommandParameterString);
        }
    }
}
