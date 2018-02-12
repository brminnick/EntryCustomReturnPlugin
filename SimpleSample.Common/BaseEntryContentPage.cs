using System.Windows.Input;

using Xamarin.Forms;

using SimpleSamples.Shared;

namespace SimpleSamples.Common.Forms
{
    public abstract class BaseEntryContentPage : ContentPage
    {
        #region Fields
        ICommand _baseEntryReturnCommand;
        bool _baseEntryReturnCommandCanExecute;
        #endregion

        #region Constructors
        protected BaseEntryContentPage()
        {
            var canExecuteLabel = new Label { Text = "Can Execute" };

            var canExecuteSwitch = new Switch();
            canExecuteSwitch.Toggled += (sender, e) => _baseEntryReturnCommandCanExecute = e.Value;

            CanExecuteStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children ={
                    canExecuteLabel,
                    canExecuteSwitch
                }
            };
        }
        #endregion

        #region Properties
        protected ICommand BaseEntryReturnCommand => _baseEntryReturnCommand ??
            (_baseEntryReturnCommand = new Command<string>(async title => await ExecuteEntryCommand(title), CanEntryCommandExecute));

        protected StackLayout CanExecuteStackLayout { get; }
        #endregion

        #region Methods
        async System.Threading.Tasks.Task ExecuteEntryCommand(string title)
        {
            await DisplayAlert(title, "", EntryConstants.OKString);
            await Navigation.PopAsync();
        }

        bool CanEntryCommandExecute(string arg) => _baseEntryReturnCommandCanExecute;
        #endregion
    }
}

