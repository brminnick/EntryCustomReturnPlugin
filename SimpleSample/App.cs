using System.Threading.Tasks;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using SimpleSample.Shared;

namespace SimpleSample
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new SelectionPage());
    }

    class SelectionPage : ContentPage
    {
        public SelectionPage()
        {
            var customRendererPageButton = new Button
            {
                Text = "Custom Renderer Page",
                AutomationId = AutomationIdConstants.CustomRendererButton
            };
            customRendererPageButton.Clicked += async (sender, e) => await Navigation.PushAsync(new CustomRendererPage());

            var effectsPageButton = new Button
            {
                Text = "Efects Page",
                AutomationId = AutomationIdConstants.EffectsButton
            };
            effectsPageButton.Clicked += async (sender, e) => await Navigation.PushAsync(new EffectsPage());

            Title = PageTitles.Selection;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    customRendererPageButton,
                    effectsPageButton
                }
            };
        }
    }

    class CustomRendererPage : ContentPage
    {
        public CustomRendererPage()
        {
            Title = PageTitles.CustomRenderer;

            Content = new CustomReturnEntry
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Placeholder = "Custom Return Entry",
                ReturnType = ReturnType.Go,
                ReturnCommand = new Command<string>(async title => await ExecuteEntryCommand(title)),
                ReturnCommandParameter = EntryConstants.CommandParameterString,
                AutomationId = AutomationIdConstants.CustomReturnEntry
            };
        }

        async Task ExecuteEntryCommand(string title)
        {
            await DisplayAlert(title, "", EntryConstants.OKString);
            await Navigation.PopAsync();
        }
    }

    class EffectsPage : ContentPage
    {
        public EffectsPage()
        {
            var effectsEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Placeholder = "Effects Entry",
                AutomationId = AutomationIdConstants.EffectsEntry
            };
            CustomReturnEffect.SetReturnType(effectsEntry, ReturnType.Go);
            CustomReturnEffect.SetReturnCommand(effectsEntry, new Command<string>(async title => await ExecuteEntryCommand(title)));
            CustomReturnEffect.SetReturnCommandParameter(effectsEntry, EntryConstants.CommandParameterString);

            Title = PageTitles.Effects;

            Content = effectsEntry;
        }

        async Task ExecuteEntryCommand(string title)
        {
            await DisplayAlert(title, "", EntryConstants.OKString);
            await Navigation.PopAsync();
        }
    }
}
