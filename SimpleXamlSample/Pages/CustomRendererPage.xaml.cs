using SimpleSamples.Common.Forms;

namespace SimpleXamlSample
{
    public partial class CustomRendererPage : BaseEntryContentPage
    {
        public CustomRendererPage()
        {
            InitializeComponent();

            CustomReturnEntry.ReturnCommand = BaseEntryReturnCommand;
        }

        void HandleToggled(object sender, Xamarin.Forms.ToggledEventArgs e) => BaseEntryReturnCommandCanExecute = e.Value;
    }
}
