using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SimpleXamlSample
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new SelectionPage());
    }
}
