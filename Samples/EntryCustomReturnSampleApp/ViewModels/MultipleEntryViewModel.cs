using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text;
namespace EntryCustomReturnSampleApp
{
	public class MultipleEntryViewModel : BaseViewModel
	{
		#region Fields
		string _resultLabelText, _nextReturnTypeEntryText, _doneReturnTypeEntryText, _goReturnTypeEntryText,
			_searchReturnTypeEntryText, _sendReturnTypeEntryText;
		ICommand _goButtonCommand, _goReturnTypeEntryReturnCommand;
		#endregion

		#region Properties
		public ICommand GoButtonCommand => _goButtonCommand ??
			(_goButtonCommand = new Command(ExecuteGoButtonCommand));

		public ICommand GoReturnTypeEntryReturnCommand => _goReturnTypeEntryReturnCommand ??
			(_goReturnTypeEntryReturnCommand = new Command(ExecuteGoReturnTypeEntryReturnCommand));

		public string ResultLabelText
		{
			get { return _resultLabelText; }
			set { SetProperty(ref _resultLabelText, value); }
		}

		public string NextReturnTypeEntryText
		{
			get { return _nextReturnTypeEntryText; }
			set { SetProperty(ref _nextReturnTypeEntryText, value); }
		}

		public string DoneReturnTypeEntryText
		{
			get { return _doneReturnTypeEntryText; }
			set { SetProperty(ref _doneReturnTypeEntryText, value); }
		}

		public string GoReturnTypeEntryText
		{
			get { return _goReturnTypeEntryText; }
			set { SetProperty(ref _goReturnTypeEntryText, value); }
		}

		public string SearchReturnTypeEntryText
		{
			get { return _searchReturnTypeEntryText; }
			set { SetProperty(ref _searchReturnTypeEntryText, value); }
		}

		public string SendReturnTypeEntryText
		{
			get { return _sendReturnTypeEntryText; }
			set { SetProperty(ref _sendReturnTypeEntryText, value); }
		}
		#endregion

		#region Methods
		void ExecuteGoButtonCommand()
		{
			OutputTextInputToResultsLabel();
		}

		void ExecuteGoReturnTypeEntryReturnCommand(object obj)
		{
			OutputTextInputToResultsLabel();
		}

		void OutputTextInputToResultsLabel()
		{
			var outputStringBuilder = new StringBuilder();
			outputStringBuilder.AppendLine($"{nameof(NextReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{NextReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(DoneReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{DoneReturnTypeEntryText}");
			outputStringBuilder.AppendLine();
			
			outputStringBuilder.AppendLine($"{nameof(SendReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{SendReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(SearchReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{SearchReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			outputStringBuilder.AppendLine($"{nameof(GoReturnTypeEntryText)}:");
			outputStringBuilder.AppendLine($"\t{GoReturnTypeEntryText}");
			outputStringBuilder.AppendLine();

			ResultLabelText = outputStringBuilder.ToString();
		}
		#endregion
	}
}
