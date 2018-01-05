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
        static BindableProperty _returnTypeProperty, _returnCommandProperty, _returnCommandParameterProperty;

        /// <summary>
        /// Return Type Property of the Keyboard Return Key
        /// </summary>
        public static BindableProperty ReturnTypeProperty => _returnTypeProperty ??
            (_returnTypeProperty = BindableProperty.CreateAttached(nameof(ReturnType),
                                                                    typeof(ReturnType),
                                                                    typeof(Entry),
                                                                    ReturnType.Default,
                                                                    propertyChanged: OnReturnTypeChanged));

        /// <summary>
        /// Command that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public static BindableProperty ReturnCommandProperty => _returnCommandProperty ??
            (_returnCommandProperty = BindableProperty.CreateAttached(nameof(ICommand),
                                                                        typeof(ICommand),
                                                                        typeof(Entry),
                                                                        null,
                                                                        propertyChanged: OnReturnCommandPropertyChanged));

        /// <summary>
        /// Backing store for the ReturnCommandParameter bindable property
        /// </summary>
        public static BindableProperty ReturnCommandParameterProperty => _returnCommandParameterProperty ??
            (_returnCommandParameterProperty = BindableProperty.CreateAttached("ReturnCommandParameter",
                                                                               typeof(object),
                                                                               typeof(CustomReturnEntry),
                                                                               null,
                                                                               propertyChanged: OnReturnCommandParameterPropertyChanged));

        /// <summary>
        /// Gets the Type of the Keyboard Return Key
        /// </summary>
        /// <returns>The return type.</returns>
        /// <param name="view">View.</param>
        public static ReturnType GetReturnType(BindableObject view) => (ReturnType)view.GetValue(ReturnTypeProperty);

        /// <summary>
        /// Sets the Type of the Keyboard Return Key
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="value">Value.</param>
        public static void SetReturnType(BindableObject view, ReturnType value) => view.SetValue(ReturnTypeProperty, value);

        /// <summary>
        /// Gets the Command that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        /// <returns>The return type.</returns>
        /// <param name="view">View.</param>
        public static ICommand GetReturnCommand(BindableObject view) => (ICommand)view.GetValue(ReturnCommandProperty);

        /// <summary>
        /// Set the Command that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="value">Value.</param>
        public static void SetReturnCommand(BindableObject view, ICommand value) => view.SetValue(ReturnCommandProperty, value);

        /// <summary>
        /// Gets the backing store for the Command that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        /// <returns>The return type.</returns>
        /// <param name="view">View.</param>
        public static object GetReturnCommandParameter(BindableObject view) => view.GetValue(ReturnCommandParameterProperty);

        /// <summary>
        /// Set the backing store for the Command that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="value">Value.</param>
        public static void SetReturnCommandParameter(BindableObject view, object value) => view.SetValue(ReturnCommandParameterProperty, value);

        static void OnReturnTypeChanged(BindableObject bindable, object oldValue, object newValue) => UpdateEffect(bindable);

        static void OnReturnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue) => UpdateEffect(bindable);

        static void OnReturnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue) => UpdateEffect(bindable);

        static void UpdateEffect(BindableObject bindable)
        {
            switch (bindable)
            {
                case Entry entry:
                    RemoveEffect(entry);
                    entry.Effects.Add(new EntryReturnTypeEffect());
                    break;
            }
        }

        static void RemoveEffect(Entry entry)
        {
            var effectToRemoveList = entry.Effects.Where(e => e is EntryReturnTypeEffect).ToList();

            foreach (var entryReturnTypeEffect in effectToRemoveList)
                entry.Effects.Remove(entryReturnTypeEffect);
        }
    }

    class EntryReturnTypeEffect : RoutingEffect
    {
        public EntryReturnTypeEffect() : base(EffectConstants.Name)
        {
        }
    }
}
