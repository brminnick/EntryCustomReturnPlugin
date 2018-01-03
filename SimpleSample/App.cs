using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using SimpleSamples.Shared;

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
                Text = SelectionPageConstants.CustomRendererPageButtonText,
                AutomationId = AutomationIdConstants.CustomRendererButton
            };
            customRendererPageButton.Clicked += async (sender, e) => await Navigation.PushAsync(new CustomRendererPage());

            var effectsPageButton = new Button
            {
                Text = SelectionPageConstants.EfectsPageButtonText,
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
                Placeholder = CustomRendererPageConstants.CustomReturnEntryPlaceholderText,
                ReturnType = ReturnType.Go,
                ReturnCommand = new Command(async () => await Navigation.PopAsync()),
                AutomationId = AutomationIdConstants.CustomReturnEntry
            };
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
            CustomReturnEffect.SetReturnCommand(effectsEntry, new Command(async () => await Navigation.PopAsync()));

            Title = PageTitles.Effects;

            Content = effectsEntry;
        }
    }
}
