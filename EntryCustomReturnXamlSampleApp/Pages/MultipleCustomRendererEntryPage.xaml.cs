using Xamarin.Forms;

namespace EntryCustomReturnXamlSampleApp
{
    public partial class MultipleCustomRendererEntryPage : ContentPage
    {
        public MultipleCustomRendererEntryPage()
        {
            InitializeComponent();

            DefaultReturnTypeEntry.ReturnCommand = new Command(() => NextReturnTypeEntry.Focus());
            NextReturnTypeEntry.ReturnCommand = new Command(() => DoneReturnTypeEntry.Focus());
            DoneReturnTypeEntry.ReturnCommand = new Command(() => SendReturnTypeEntry.Focus());
            SendReturnTypeEntry.ReturnCommand = new Command(() => SearchReturnTypeEntry.Focus());
            SearchReturnTypeEntry.ReturnCommand = new Command(() => GoReturnTypeEntry.Focus());
        }
    }
}
