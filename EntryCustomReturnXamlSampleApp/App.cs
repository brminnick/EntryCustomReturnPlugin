using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EntryCustomReturnXamlSampleApp
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new OptionSelectionPage());
    }
}
