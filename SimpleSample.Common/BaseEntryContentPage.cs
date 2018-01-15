using Xamarin.Forms;

using SimpleSamples.Shared;

namespace SimpleSamples.Common.Forms
{
    public abstract class BaseEntryContentPage : ContentPage
    {
        protected async System.Threading.Tasks.Task ExecuteEntryCommand(string title)
        {
            await DisplayAlert(title, "", EntryConstants.OKString);
            await Navigation.PopAsync();
        }
    }
}

