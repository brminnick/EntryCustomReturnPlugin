using Xamarin.Forms;

namespace SimpleXamlSample
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new SelectionPage());
    }
}
