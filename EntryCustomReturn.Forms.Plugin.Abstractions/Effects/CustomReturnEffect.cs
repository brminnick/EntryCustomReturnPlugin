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
        static BindableProperty _returnTypeProperty, _returnCommandProperty;

        /// <summary>
        /// Return Type Property of the Keyboard Return Key
        /// </summary>
        public static BindableProperty ReturnTypeProperty => _returnTypeProperty ??
            (_returnTypeProperty = BindableProperty.CreateAttached(propertyName: nameof(ReturnType),
                                                                    returnType: typeof(ReturnType),
                                                                    declaringType: typeof(Entry),
                                                                    defaultValue: ReturnType.Default,
                                                                    propertyChanged: OnReturnTypeChanged));

        /// <summary>
        /// Command that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public static BindableProperty ReturnCommandProperty => _returnCommandProperty ??
            (_returnCommandProperty = BindableProperty.CreateAttached(propertyName: nameof(ICommand),
                                                                        returnType: typeof(ICommand),
                                                                        declaringType: typeof(Entry),
                                                                        defaultValue: null,
                                                                        propertyChanged: OnReturnCommandPropertyChanged));


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

        static void OnReturnTypeChanged(BindableObject bindable, object oldValue, object newValue) => UpdateEffect(bindable);

        static void OnReturnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue) => UpdateEffect(bindable);

        static void UpdateEffect(BindableObject bindable)
        {
            var entry = bindable as Entry;

            if (entry == null)
                return;

            RemoveEffect(entry);

            entry.Effects.Add(new EntryReturnTypeEffect());
        }

        static void RemoveEffect(Entry entry)
        {
            var toRemove = entry.Effects.FirstOrDefault(e => e is EntryReturnTypeEffect);
            if (toRemove != null)
                entry.Effects.Remove(toRemove);
        }
    }

    class EntryReturnTypeEffect : RoutingEffect
    {
        public EntryReturnTypeEffect() : base(EffectConstants.Name)
        {
        }
    }
}
