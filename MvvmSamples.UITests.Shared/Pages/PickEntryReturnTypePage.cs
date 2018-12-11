using System;
using System.Linq;
using System.Threading;

using Xamarin.UITest;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using MvvmSamples.Shared;

using Tests.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MvvmSamples.UITests.Shared
{
    public class PickEntryReturnTypePage : BasePage
    {
        #region Constant Fields
        readonly Query _customizableEntry, _entryReturnTypePicker;
        #endregion

        #region Constructors
        public PickEntryReturnTypePage(IApp app) : base(app, PageTitles.PickEntryReturnTypePageTitle)
        {
            _customizableEntry = x => x.Marked(AutomationIdConstants.CustomizableEntryAutomationId);
            _entryReturnTypePicker = x => x.Marked(AutomationIdConstants.EntryReturnTypePickerAutomationId);
        }
        #endregion

        #region Properties
        public string CustomizableEntryPlaceholder => TestHelpers.GetPlaceholderText(App, AutomationIdConstants.CustomizableEntryAutomationId);
        public string PickerText => App.Query(_entryReturnTypePicker)?.FirstOrDefault()?.Text;
        #endregion

        #region Methods
        public void SelectReturnTypeFromPicker(ReturnType returnType)
        {
            SelectReturnTypeFromPicker(returnType, _entryReturnTypePicker);
        }

        public void EnterText(string text)
        {
            App.ClearText(_customizableEntry);
            App.EnterText(_customizableEntry, text);
            App.DismissKeyboard();
        }

        void SelectReturnTypeFromPicker(ReturnType returnType, Query pickerQuery)
        {
            App.WaitForElement(pickerQuery);
            App.Tap(pickerQuery);

            ScrollToPickerLocation(returnType);

            SelectValueFromPicker(returnType);

            App.Screenshot($"Selected Return Type From Picker: {returnType.ToString()}");
        }

        void ScrollToPickerLocation(ReturnType returnType)
        {
            if (OnAndroid)
            {
                App.Query(x => x.Marked("select_dialog_listview").Invoke("smoothScrollToPosition", (int)returnType - 1));
            }
            else
            {
                App.Query(x => x.Class("UIPickerView").Invoke("selectRow", (int)returnType + 1, "inComponent", 0, "animated", true));

                var maxNumberInEnum = Enum.GetValues(typeof(ReturnType)).Length - 1;

                if (returnType == (ReturnType)maxNumberInEnum)
                    App.Query(x => x.Class("UIPickerView").Invoke("selectRow", (int)returnType - 1, "inComponent", 0, "animated", true));
            }
        }

        void SelectValueFromPicker(ReturnType returnType)
        {
            if (OniOS && returnType.ToString().Equals(PickerText))
            {
                var nextReturnType = returnType + 2;
                TapPickerValue(nextReturnType);
            }

            TapPickerValue(returnType);

            if (OniOS)
                TapDoneButtonOniOSPicker();

        }

        void TapPickerValue(ReturnType returnType)
        {
            Thread.Sleep(500);

            if (OnAndroid)
            {
                App.Tap(returnType.ToString());
            }
            else if (returnType is ReturnType.Done)
            {
                var doneQuery = App.Query("Done");
                var donePickerQuery = doneQuery?.Where(x => x.Class is "UILabel").LastOrDefault();

                var donePickerXCoordinate = donePickerQuery?.Rect?.CenterX ?? 500;
                var donePickerYCoordinate = donePickerQuery?.Rect?.CenterY ?? 0;

                App.TapCoordinates(donePickerXCoordinate, donePickerYCoordinate);
            }
            else
            {
                App.Tap(returnType.ToString());
            }
        }

        void TapDoneButtonOniOSPicker()
        {
            if (OnAndroid)
                return;

            var doneQuery = App.Query("Done");

            var pickerDoneButtonQuery = doneQuery?.Where(x => x.Class is "UIButtonLabel")?.FirstOrDefault();

            var pickerDoneButtonX = pickerDoneButtonQuery?.Rect?.CenterX ?? 500;
            var pickerDoneButtonY = pickerDoneButtonQuery?.Rect?.CenterY ?? 0;

            App.TapCoordinates(pickerDoneButtonX, pickerDoneButtonY);

        }
        #endregion
    }
}
