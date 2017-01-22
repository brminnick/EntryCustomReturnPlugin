using System.Collections.Generic;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace EntryCustomReturnSampleApp
{
	public class SelectEntryViewModel : BaseViewModel
	{
		#region Fields
		string _entryPlaceHolderText;
		List<ReturnType> _entryReturnTypePickerSource;
		ReturnType _entryReturnType, _pickerSelection;
		#endregion

		#region Constructors
		public SelectEntryViewModel()
		{
			EntryReturnTypePickerSource = new List<ReturnType>();

			EntryReturnTypePickerSource.Add(ReturnType.Done);
			EntryReturnTypePickerSource.Add(ReturnType.Go);
			EntryReturnTypePickerSource.Add(ReturnType.Next);
			EntryReturnTypePickerSource.Add(ReturnType.Search);
			EntryReturnTypePickerSource.Add(ReturnType.Send);

			UpdateEntryReturnType();
		}
		#endregion

		#region Properties
		public string EntryPlaceHolderText
		{
			get { return _entryPlaceHolderText; }
			set { SetProperty(ref _entryPlaceHolderText, value); }
		}

		public List<ReturnType> EntryReturnTypePickerSource
		{
			get { return _entryReturnTypePickerSource; }
			set { SetProperty(ref _entryReturnTypePickerSource, value); }
		}

		public ReturnType EntryReturnType
		{
			get { return _entryReturnType; }
			set { SetProperty(ref _entryReturnType, value); }
		}

		public ReturnType PickerSelection
		{
			get { return _pickerSelection; }
			set { SetProperty(ref _pickerSelection, value, UpdateEntryReturnType); }
		}
		#endregion

		#region Methods
		void UpdateEntryReturnType()
		{
			EntryPlaceHolderText = PickerSelection.ToString();
			EntryReturnType = PickerSelection;
		}
		#endregion
	}
}
