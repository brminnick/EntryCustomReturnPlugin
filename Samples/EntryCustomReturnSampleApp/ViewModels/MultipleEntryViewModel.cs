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
		ICommand _goButtonCommand;
		#endregion

		#region Properties
		public ICommand GoButtonCommand => _goButtonCommand ??
			(_goButtonCommand = new Command(ExecuteGoButtonCommand));

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
			var outputString = new StringBuilder();
			outputString.AppendLine($"{nameof(NextReturnTypeEntryText)}:");
			outputString.AppendLine($"\t{NextReturnTypeEntryText}");
			outputString.AppendLine();

			outputString.AppendLine($"{nameof(DoneReturnTypeEntryText)}:");
			outputString.AppendLine($"\t{DoneReturnTypeEntryText}");
			outputString.AppendLine();

			outputString.AppendLine($"{nameof(GoReturnTypeEntryText)}:");
			outputString.AppendLine($"\t{GoReturnTypeEntryText}");
			outputString.AppendLine();

			outputString.AppendLine($"{nameof(SearchReturnTypeEntryText)}:");
			outputString.AppendLine($"\t{SearchReturnTypeEntryText}");
			outputString.AppendLine();

			outputString.AppendLine($"{nameof(SendReturnTypeEntryText)}:");
			outputString.AppendLine($"\t{SendReturnTypeEntryText}");
			outputString.AppendLine();

			ResultLabelText = outputString.ToString();
		}
		#endregion
	}
}
