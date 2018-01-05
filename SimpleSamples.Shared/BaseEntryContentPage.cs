using System.Threading.Tasks;

using Xamarin.Forms;

namespace SimpleSamples.Shared
{
    public abstract class BaseEntryContentPage : ContentPage
    {
        protected async Task ExecuteEntryCommand(string title)
        {
            await DisplayAlert(title, "", EntryConstants.OKString);
            await Navigation.PopAsync();
        }
    }
}

