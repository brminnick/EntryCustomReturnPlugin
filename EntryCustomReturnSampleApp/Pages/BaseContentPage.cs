using System;

using Xamarin.Forms;

namespace EntryCustomReturnSampleApp
{
    public abstract class BaseContentPage<T> : ContentPage where T : BaseViewModel, new()
    {
        #region Fields
        T _viewModel;
        #endregion

        #region Constructors
        protected BaseContentPage() => BindingContext = ViewModel;
        #endregion

        #region Properties
        protected T ViewModel => _viewModel ?? (_viewModel = new T());
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
        #endregion
    }
}
