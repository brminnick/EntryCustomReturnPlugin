using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Android;

namespace EntryCustomReturnUITests
{
    public abstract class BasePage
    {
        #region Fields
        string _pageTitle;
        #endregion

        #region Constructors
        protected BasePage(IApp app, string pageTitle)
        {
            App = app;

            OnAndroid = app is AndroidApp;
            OniOS = app is iOSApp;

            _pageTitle = pageTitle;
        }
        #endregion

        #region Properties
        public string PageTitle => _pageTitle;
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
