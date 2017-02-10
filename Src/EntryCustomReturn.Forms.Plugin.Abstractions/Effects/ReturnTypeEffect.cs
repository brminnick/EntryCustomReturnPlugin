using System;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
	public static class ReturnTypeEffect
	{
		/// <summary>
		/// Return Type Property of the Entry
		/// </summary>
		public static readonly BindableProperty ReturnTypeProperty =
			BindableProperty.CreateAttached(propertyName: nameof(ReturnType),
				returnType: typeof(ReturnType),
				declaringType: typeof(Entry),
				defaultValue: ReturnType.Default,
				propertyChanged: OnReturnTypeChanged);

		/// <summary>
		/// Completed Event Property of the Entry
		/// </summary>
		public static readonly BindableProperty ReturnCommandProperty =
			BindableProperty.CreateAttached(propertyName: "Command",
				returnType: typeof(ICommand),
				declaringType: typeof(Entry),
				defaultValue: null,
				propertyChanged: OnReturnCommandPropertyChanged);

		/// <summary>
		/// Gets the ReturnType
		/// </summary>
		/// <returns>The return type.</returns>
		/// <param name="view">View.</param>
		public static ReturnType GetReturnType(BindableObject view)
		{
			return (ReturnType)view.GetValue(ReturnTypeProperty);
		}

		/// <summary>
		/// Sets the ReturnType
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="value">Value.</param>
		public static void SetReturnType(BindableObject view, ReturnType value)
		{
			view.SetValue(ReturnTypeProperty, value);
		}

		/// <summary>
		/// Gets the ReturnType
		/// </summary>
		/// <returns>The return type.</returns>
		/// <param name="view">View.</param>
		public static ICommand GetReturnCommandProperty(BindableObject view)
		{
			return (ICommand)view.GetValue(ReturnCommandProperty);
		}

		/// <summary>
		/// Sets the ReturnType
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="value">Value.</param>
		public static void SetReturnCommandProperty(BindableObject view, ICommand value)
		{
			view.SetValue(ReturnCommandProperty, value);
		}

		static void OnReturnTypeChanged(BindableObject bindable, object oldValue, object newValue)
		{
			UpdateEffect(bindable);
		}

		static void OnReturnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			UpdateEffect(bindable);
		}

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
