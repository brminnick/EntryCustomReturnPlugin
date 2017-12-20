using System.Windows.Input;

using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;
using System.Text;

namespace EntryCustomReturnSampleApp
{
    public class MultipleEntryViewModel : BaseViewModel
    {
        #region Fields
        string _resultLabelText, _nextReturnTypeEntryText, _doneReturnTypeEntryText, _goReturnTypeEntryText,
            _searchReturnTypeEntryText, _sendReturnTypeEntryText, _defaultReturnTypeEntryText;

        ICommand _goButtonCommand, _goReturnTypeEntryReturnCommand;
        #endregion

        #region Properties
        public ICommand GoButtonCommand => _goButtonCommand ??
            (_goButtonCommand = new Command<string>(ExecuteGoButtonCommand));

        public ICommand GoReturnTypeEntryReturnCommand => _goReturnTypeEntryReturnCommand ??
            (_goReturnTypeEntryReturnCommand = new Command<string>(ExecuteGoReturnTypeEntryReturnCommand));

        public string GoButtonCommandParameter => MultipleEntryPageConstants.GoButtonCommandParameterString;

        public string GoReturnTypeEntryReturnCommandParameter => MultipleEntryPageConstants.GoReturnTypeCommandParameterString;

        public string ResultLabelText
        {
            get => _resultLabelText;
            set => SetProperty(ref _resultLabelText, value);
        }

        public string NextReturnTypeEntryText
        {
            get => _nextReturnTypeEntryText;
            set => SetProperty(ref _nextReturnTypeEntryText, value);
        }

        public string DoneReturnTypeEntryText
        {
            get => _doneReturnTypeEntryText;
            set => SetProperty(ref _doneReturnTypeEntryText, value);
        }

        public string DefaultReturnTypeEntryText
        {
            get => _defaultReturnTypeEntryText;
            set => SetProperty(ref _defaultReturnTypeEntryText, value);
        }

        public string GoReturnTypeEntryText
        {
            get => _goReturnTypeEntryText;
            set => SetProperty(ref _goReturnTypeEntryText, value);
        }

        public string SearchReturnTypeEntryText
        {
            get => _searchReturnTypeEntryText;
            set => SetProperty(ref _searchReturnTypeEntryText, value);
        }

        public string SendReturnTypeEntryText
        {
            get => _sendReturnTypeEntryText;
            set => SetProperty(ref _sendReturnTypeEntryText, value);
        }
        #endregion

        #region Methods
        void ExecuteGoButtonCommand(string commandParameter) => OutputTextInputToResultsLabel(commandParameter);

        void ExecuteGoReturnTypeEntryReturnCommand(string commandParameter) => OutputTextInputToResultsLabel(commandParameter);

        void OutputTextInputToResultsLabel(string commandParameter)
        {
            ResultLabelText = StringBuilderHelpers.ConvertTextInputToResultsLabel(commandParameter,
                                                                                    DefaultReturnTypeEntryText,
                                                                                    NextReturnTypeEntryText,
                                                                                    DoneReturnTypeEntryText,
                                                                                    SendReturnTypeEntryText,
                                                                                    SearchReturnTypeEntryText,
                                                                                    GoReturnTypeEntryText);
        }
        #endregion
    }
}
