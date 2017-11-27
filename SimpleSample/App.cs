using System;

using Xamarin.Forms;
using EntryCustomReturn.Forms.Plugin.Abstractions;

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
            var customRendererPageButton = new Button { Text = "Custom Renderer Page" };
            customRendererPageButton.Clicked += async (sender, e) => await Navigation.PushAsync(new CustomRendererPage());

            var effectsPageButton = new Button { Text = "Efects Page" };
            effectsPageButton.Clicked += async (sender, e) => await Navigation.PushAsync(new EffectsPage());

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
            Title = "Custom Renderer";

            Content = new CustomReturnEntry
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Placeholder = "Custom Return Entry",
                ReturnType = ReturnType.Go,
                ReturnCommand = new Command(async () => await Navigation.PopAsync())
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
            };
            CustomReturnEffect.SetReturnType(effectsEntry, ReturnType.Go);
            CustomReturnEffect.SetReturnCommand(effectsEntry, new Command(async () => await Navigation.PopAsync()));

            Title = "Effects";

            Content = effectsEntry;
        }
    }
}
