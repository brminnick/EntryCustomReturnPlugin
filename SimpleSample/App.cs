using System.Threading.Tasks;

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

    class CustomRendererPage : BaseEntryContentPage
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
                ReturnCommand = new Command<string>(async title => await ExecuteEntryCommand(title)),
                ReturnCommandParameter = EntryConstants.CommandParameterString,
                AutomationId = AutomationIdConstants.CustomReturnEntry
            };
        }
    }

    class EffectsPage : BaseEntryContentPage
    {
        public EffectsPage()
        {
            var effectsEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Placeholder = EffectsPageConstants.EffectsEntryPlaceholderText,
                AutomationId = AutomationIdConstants.EffectsEntry
            };
            CustomReturnEffect.SetReturnType(effectsEntry, ReturnType.Go);
            CustomReturnEffect.SetReturnCommand(effectsEntry, new Command<string>(async title => await ExecuteEntryCommand(title)));
            CustomReturnEffect.SetReturnCommandParameter(effectsEntry, EntryConstants.CommandParameterString);

            Title = PageTitles.Effects;

            Content = effectsEntry;
        }
    }
}
