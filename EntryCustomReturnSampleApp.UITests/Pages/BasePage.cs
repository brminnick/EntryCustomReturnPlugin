using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Android;

namespace EntryCustomReturnSampleApp.UITests
{
    public abstract class BasePage
    {
        #region Constructors
        protected BasePage(IApp app, string pageTitle)
        {
            App = app;
            OnAndroid = app is AndroidApp;
            OniOS = app is iOSApp;
            PageTitle = pageTitle;
        }
        #endregion

        #region Properties
        public string PageTitle { get; }
        protected IApp App { get; }
        protected bool OnAndroid { get; }
        protected bool OniOS { get; }
        #endregion

        #region Methods
        public virtual void WaitForPageToLoad()
        {
            App.WaitForElement(PageTitle);
            App.Screenshot("Page Loaded");
        }
        #endregion
    }
}
