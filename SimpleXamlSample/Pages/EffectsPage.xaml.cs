using System.Threading.Tasks;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using SimpleSamples.Shared;

namespace SimpleXamlSample
{
    public partial class EffectsPage : BaseEntryContentPage
    {
        public EffectsPage()
        {
            InitializeComponent();

            CustomReturnEffect.SetReturnCommand(EffectsEntry, new Command<string>(async title => await ExecuteEntryCommand(title)));
        }
    }
}
