using System.Windows.Input;

using Xamarin.Forms;

namespace EntryCustomReturn.Forms.Plugin.Abstractions
{
	/// <summary>
	/// CustomReturnEntry Interface
	/// </summary>
	public class CustomReturnEntry : Entry
	{
        /// <summary>
        /// Command Property that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public static readonly BindableProperty ReturnCommandProperty =
            BindableProperty.Create(nameof(ReturnCommand), 
                                    typeof(ICommand), 
                                    typeof(CustomReturnEntry));

        /// <summary>
        /// Backing store for the ReturnCommandParameter bindable property
        /// </summary>
        public static readonly BindableProperty ReturnCommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), 
                                    typeof(object), 
                                    typeof(CustomReturnEntry));

        /// <summary>
        /// Return Type Property of the Entry
        /// </summary>
        public static readonly BindableProperty ReturnTypeProperty =
			BindableProperty.Create(nameof(ReturnType),
                                    typeof(ReturnType),
                                    typeof(CustomReturnEntry),
                                    ReturnType.Done);

		/// <summary>
		/// Type of the Keyboard Return Key
		/// </summary>
		public ReturnType ReturnType
		{
			get { return (ReturnType)GetValue(ReturnTypeProperty); }
			set { SetValue(ReturnTypeProperty, value); }
		}

		/// <summary>
		/// Occurs when the user finalizes the text in an entry with the return key
		/// </summary>
		public ICommand ReturnCommand
		{
			get { return (ICommand)GetValue(ReturnCommandProperty); }
			set { SetValue(ReturnCommandProperty, value); }
		}

        /// <summary>
        /// Gets or sets the ReturnCommand parameter
        /// </summary>
        public object CommandParameter
        {
            get { return GetValue(ReturnCommandParameterProperty); }
            set { SetValue(ReturnCommandParameterProperty, value); }
        }
    }
}
