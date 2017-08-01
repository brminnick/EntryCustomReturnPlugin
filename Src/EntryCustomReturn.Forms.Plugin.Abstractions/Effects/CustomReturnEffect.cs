using System;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
    /// <summary>
    /// CustomReturnEffect Interface
    /// </summary>
    public static class CustomReturnEffect
    {
        /// <summary>
        /// Return Type Property of the Keyboard Return Key
        /// </summary>
        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.CreateAttached(nameof(ReturnType),
                                            typeof(ReturnType),
                                            typeof(InputView),
                                            ReturnType.Default,
                                            propertyChanged: OnReturnTypeChanged);

        /// <summary>
        /// Command that occurs when the user finalizes the text in an InputView with the return key
        /// </summary>
        public static readonly BindableProperty ReturnCommandProperty =
            BindableProperty.CreateAttached(nameof(Command),
                                            typeof(ICommand),
                                            typeof(InputView),
                                            null,
                                            propertyChanged: OnReturnCommandPropertyChanged);

        /// <summary>
        /// Backing store for the ReturnCommandParameter bindable property
        /// </summary>
        public static readonly BindableProperty ReturnCommandParameterProperty =
            BindableProperty.CreateAttached("CommandParameter",
                                            typeof(object),
                                            typeof(CustomReturnEntry),
                                            null,
                                            propertyChanged: OnReturnCommandParameterPropertyChanged);

        /// <summary>
        /// Gets the Type of the Keyboard Return Key
        /// </summary>
        /// <returns>The return type.</returns>
        /// <param name="view">View.</param>
        public static ReturnType GetReturnType(BindableObject view) =>
            (ReturnType)view.GetValue(ReturnTypeProperty);

        /// <summary>
        /// Sets the Type of the Keyboard Return Key
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="value">Value.</param>
        public static void SetReturnType(BindableObject view, ReturnType value) =>
            view.SetValue(ReturnTypeProperty, value);

        /// <summary>
        /// Gets the Command that occurs when the user finalizes the text in an InputView with the return key
        /// </summary>
        /// <returns>The return type.</returns>
        /// <param name="view">View.</param>
        public static ICommand GetReturnCommand(BindableObject view) =>
            (ICommand)view.GetValue(ReturnCommandProperty);

        /// <summary>
        /// Set the Command that occurs when the user finalizes the text in an InputView with the return key
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="value">Value.</param>
        public static void SetReturnCommand(BindableObject view, ICommand value) =>
            view.SetValue(ReturnCommandProperty, value);

        /// <summary>
        /// Gets the backing store for the Command that occurs when the user finalizes the text in an InputView with the return key
        /// </summary>
        /// <returns>The return type.</returns>
        /// <param name="view">View.</param>
        public static object GetReturnCommandParameter(BindableObject view) =>
            view.GetValue(ReturnCommandParameterProperty);

        /// <summary>
        /// Set the backing store for the Command that occurs when the user finalizes the text in an InputView with the return key
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="value">Value.</param>
        public static void SetReturnCommandParameter(BindableObject view, object value) =>
            view.SetValue(ReturnCommandParameterProperty, value);

        static void OnReturnTypeChanged(BindableObject bindable, object oldValue, object newValue) =>
            UpdateEffect(bindable);

        static void OnReturnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            UpdateEffect(bindable);

        static void OnReturnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            UpdateEffect(bindable);

        static void UpdateEffect(BindableObject bindable)
        {
            var inputView = bindable as InputView;

            if (inputView == null)
                return;

            RemoveEffect(inputView);

            inputView.Effects.Add(new EntryReturnTypeEffect());


            void RemoveEffect(InputView view)
            {
                var toRemove = inputView.Effects.FirstOrDefault(e => e is EntryReturnTypeEffect);
                if (toRemove != null)
                    inputView.Effects.Remove(toRemove);
            }
        }
    }

    class EntryReturnTypeEffect : RoutingEffect
    {
        public EntryReturnTypeEffect() : base(EffectConstants.Name)
        {
        }
    }
}
