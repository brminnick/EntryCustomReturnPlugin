using System.Windows.Input;

using Xamarin.Forms;

using EntryCustomReturnSampleApp.Shared;

namespace MvvmSamples.Common.Forms
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
            (_goButtonCommand = new Command(ExecuteGoButtonCommand));

        public ICommand GoReturnTypeEntryReturnCommand => _goReturnTypeEntryReturnCommand ??
            (_goReturnTypeEntryReturnCommand = new Command(ExecuteGoReturnTypeEntryReturnCommand));

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
        void ExecuteGoButtonCommand() => OutputTextInputToResultsLabel();

        void ExecuteGoReturnTypeEntryReturnCommand() => OutputTextInputToResultsLabel();

        void OutputTextInputToResultsLabel() =>
            ResultLabelText = StringBuilderHelpers.ConvertTextInputToResultsLabel(DefaultReturnTypeEntryText,
                                                                                    NextReturnTypeEntryText,
                                                                                    DoneReturnTypeEntryText,
                                                                                    SendReturnTypeEntryText,
                                                                                    SearchReturnTypeEntryText,
                                                                                    GoReturnTypeEntryText);
        #endregion
    }
}
