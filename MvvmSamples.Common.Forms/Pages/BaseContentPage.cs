using System;

using Xamarin.Forms;

namespace EntryCustomReturnSampleApp.Common.Forms
{
    public abstract class BaseContentPage<T> : ContentPage where T : BaseViewModel, new()
    {
        #region Fields
        readonly Lazy<T> _viewModelHolder = new Lazy<T>();
        #endregion

        #region Constructors
        protected BaseContentPage() => BindingContext = ViewModel;
        #endregion

        #region Properties
        protected T ViewModel => _viewModelHolder.Value;
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
