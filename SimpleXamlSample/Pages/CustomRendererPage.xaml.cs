using Xamarin.Forms;

using SimpleSamples.Shared;
using SimpleSamples.Common.Forms;

namespace SimpleXamlSample
{
    public partial class CustomRendererPage : BaseEntryContentPage
    {
        public CustomRendererPage()
        {
            InitializeComponent();

			CustomReturnEntry.ReturnCommand = new Command<string>(async title => await ExecuteEntryCommand(title));
            CustomReturnEntry.ReturnCommandParameter = EntryConstants.CommandParameterString;
        }
    }
}
