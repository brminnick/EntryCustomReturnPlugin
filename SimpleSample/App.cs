using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using SimpleSamples.Shared;
using SimpleSamples.Common.Forms;

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

            var customReturnEntry = new CustomReturnEntry
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Placeholder = CustomRendererPageConstants.CustomReturnEntryPlaceholderText,
                ReturnType = ReturnType.Go,
                ReturnCommand = BaseEntryReturnCommand,
                ReturnCommandParameter = EntryConstants.CommandParameterString,
                AutomationId = AutomationIdConstants.CustomReturnEntry
            };

            var canExecuteLabel = new Label { Text = "Can Execute" };

            var canExecuteSwitch = new Switch { AutomationId = AutomationIdConstants.CanExecuteSwitch };
            canExecuteSwitch.Toggled += (sender, e) => BaseEntryReturnCommandCanExecute = e.Value;

            var baseCanExecuteStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children ={
                    canExecuteLabel,
                    canExecuteSwitch
                }
            };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    customReturnEntry,
                    baseCanExecuteStackLayout
                }
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
            CustomReturnEffect.SetReturnCommand(effectsEntry, BaseEntryReturnCommand);
            CustomReturnEffect.SetReturnCommandParameter(effectsEntry, EntryConstants.CommandParameterString);

            var canExecuteLabel = new Label { Text = "Can Execute" };

            var canExecuteSwitch = new Switch { AutomationId = AutomationIdConstants.CanExecuteSwitch };
            canExecuteSwitch.Toggled += (sender, e) => BaseEntryReturnCommandCanExecute = e.Value;

            var baseCanExecuteStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children ={
                    canExecuteLabel,
                    canExecuteSwitch
                }
            };

            Title = PageTitles.Effects;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    effectsEntry,
                    baseCanExecuteStackLayout
                }
            };
        }
    }
}
