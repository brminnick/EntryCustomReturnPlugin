using System.Windows.Input;

using Xamarin.Forms;

using SimpleSamples.Shared;

namespace SimpleSamples.Common.Forms
{
    public abstract class BaseEntryContentPage : ContentPage
    {
        #region Fields
        ICommand _baseEntryReturnCommand;
        #endregion

        #region Properties
        protected ICommand BaseEntryReturnCommand => _baseEntryReturnCommand ??
            (_baseEntryReturnCommand = new Command<string>(async title => await ExecuteEntryCommand(title), CanEntryCommandExecute));

        protected bool BaseEntryReturnCommandCanExecute { get; set; }
        #endregion

        #region Methods
        async System.Threading.Tasks.Task ExecuteEntryCommand(string title)
        {
            await DisplayAlert(title, "", EntryConstants.OKString);
            await Navigation.PopAsync();
        }

        bool CanEntryCommandExecute(string arg) => BaseEntryReturnCommandCanExecute;
        #endregion
    }
}

