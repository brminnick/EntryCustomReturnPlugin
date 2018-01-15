using System;

using Xamarin.Forms;

namespace SimpleXamlSample
{
    public partial class SelectionPage : ContentPage
    {
        public SelectionPage() => InitializeComponent();

		async void HandleEffectsPageButtonClicked(object sender, EventArgs e) => await Navigation.PushAsync(new EffectsPage());
        async void HandleCustomRendererPageButtonClicked(object sender, EventArgs e) => await Navigation.PushAsync(new CustomRendererPage());
    }
}
