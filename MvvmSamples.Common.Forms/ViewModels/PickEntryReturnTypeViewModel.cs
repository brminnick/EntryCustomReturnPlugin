using System;
using System.Collections.Generic;

using EntryCustomReturn.Forms.Plugin.Abstractions;

namespace MvvmSamples.Common.Forms
{
	public class PickEntryReturnTypeViewModel : BaseViewModel
	{
		#region Fields
		string _entryPlaceHolderText;
		List<ReturnType> _entryReturnTypePickerSource;
		ReturnType _entryReturnType, _pickerSelection;
		#endregion

		#region Constructors
		public PickEntryReturnTypeViewModel()
		{
            EntryReturnTypePickerSource = new List<ReturnType>();

            foreach(ReturnType returnType in Enum.GetValues(typeof(ReturnType)))
                EntryReturnTypePickerSource.Add(returnType);
            
            UpdateEntryReturnType();
		}
		#endregion

		#region Properties
		public string EntryPlaceHolderText
		{
			get => _entryPlaceHolderText;
			set => SetProperty(ref _entryPlaceHolderText, value);
		}

		public List<ReturnType> EntryReturnTypePickerSource
		{
			get => _entryReturnTypePickerSource;
			set => SetProperty(ref _entryReturnTypePickerSource, value);
		}

		public ReturnType EntryReturnType
		{
			get => _entryReturnType;
			set => SetProperty(ref _entryReturnType, value);
		}

		public ReturnType PickerSelection
		{
			get => _pickerSelection;
			set => SetProperty(ref _pickerSelection, value, UpdateEntryReturnType);
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
