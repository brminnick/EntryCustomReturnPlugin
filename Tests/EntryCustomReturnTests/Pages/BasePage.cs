using Xamarin.UITest;

namespace EntryCustomReturnUITests
{
	public abstract class BasePage
	{
		protected readonly IApp app;
		protected readonly bool OnAndroid, OniOS;

		string _pageTitle;

		protected BasePage(IApp app, Platform platform, string pageTitle)
		{
			this.app = app;

			OnAndroid = platform == Platform.Android;
			OniOS = platform == Platform.iOS;

			_pageTitle = pageTitle;
		}

		public string PageTitle => _pageTitle;

		public virtual void WaitForPageToLoad()
		{
			app.WaitForElement(PageTitle);
			app.Screenshot("Page Loaded");
		}
	}
}
