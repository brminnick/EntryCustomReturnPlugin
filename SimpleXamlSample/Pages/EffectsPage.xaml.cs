using Xamarin.Forms;
using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace SimpleXamlSample
{
    public partial class EffectsPage : ContentPage
    {
        public EffectsPage()
        {
            InitializeComponent();

            CustomReturnEffect.SetReturnCommand(EffectsEntry, new Command(async () => await Navigation.PopAsync()));
        }
    }
}
