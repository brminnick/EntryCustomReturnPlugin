using Xamarin.Forms;

namespace SimpleXamlSample
{
    public partial class CustomRendererPage : ContentPage
    {
        public CustomRendererPage()
        {
            InitializeComponent();

            CustomReturnEntry.ReturnCommand = new Command(async () => await Navigation.PopAsync());
        }
    }
}
