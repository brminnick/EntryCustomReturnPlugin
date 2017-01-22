using Xamarin.Forms;

namespace EntryCustomReturnSampleApp
{
	public abstract class BaseContentPage<T> : ContentPage where T : BaseViewModel, new()
	{
		#region Constructors
		protected BaseContentPage()
		{
			BindingContext = new T();
		}
		#endregion

		#region Properties
		protected T ViewModel => GetViewModel();
		protected bool AreEventHandlersSubscribed { get; set; }
		#endregion

		#region Methods
		protected abstract void SubscribeEventHandlers();
				  
		protected abstract void UnsubscribeEventHandlers();

		protected override void OnAppearing()
		{
			base.OnAppearing();

			SubscribeEventHandlers();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			UnsubscribeEventHandlers();
		}

		T GetViewModel()
		{
			if (BindingContext is T)
				return BindingContext as T;

			return null;
		}
		#endregion
	}
}
