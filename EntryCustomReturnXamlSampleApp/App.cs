using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EntryCustomReturnXamlSampleApp
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new OptionSelectionPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("3498db")
            };
        }
    }
}
