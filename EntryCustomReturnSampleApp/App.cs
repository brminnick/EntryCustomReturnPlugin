using Xamarin.Forms;

namespace EntryCustomReturnSampleApp
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
