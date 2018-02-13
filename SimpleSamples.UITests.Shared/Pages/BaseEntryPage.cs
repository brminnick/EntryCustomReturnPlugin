using Xamarin.UITest;

using Tests.Shared;
using SimpleSamples.Shared;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using System;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Android;

namespace SimpleSamples.UITests.Shared
{
    public abstract class BaseEntryPage : BasePage
    {
        Query _canExecuteSwitch;

        protected BaseEntryPage(IApp app, string title) : base(app, title)
        {
            _canExecuteSwitch = x => x.Marked(AutomationIdConstants.CanExecuteSwitch);
        }

        public void ToggleCanExecuteSwitch()
        {
            App.Tap(_canExecuteSwitch);
            App.Screenshot("Toggled Can Execute Switch");
        }

        public void AcceptClosingDialogPopup()
        {
            App.Tap(EntryConstants.OKString);
            App.Screenshot($"{EntryConstants.OKString} Tapped");
        }

        public void SetCanExecuteSwitch(bool canExecute)
        {
            App.WaitForElement(_canExecuteSwitch);

            switch(App)
            {
                case iOSApp iosApp:
                    App.Query(x => x.Class("UISwitch").Invoke("setOn", canExecute));
                    break;

                case AndroidApp androidApp:
                    App.Query(x => x.Class("SwitchCompat").Invoke("setChecked", canExecute));
                    break;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
