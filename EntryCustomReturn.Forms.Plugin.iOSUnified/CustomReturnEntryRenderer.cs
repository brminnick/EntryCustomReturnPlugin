﻿using System;

using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using EntryCustomReturn.Forms.Plugin.iOS;
using EntryCustomReturn.Forms.Plugin.Abstractions;

[assembly: ExportRenderer(typeof(CustomReturnEntry), typeof(CustomReturnEntryRenderer))]
namespace EntryCustomReturn.Forms.Plugin.iOS
{
    /// <summary>
    /// CustomReturnEntry Renderer for iOS
    /// </summary>
    [Preserve(AllMembers = true)]
    public sealed class CustomReturnEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// Used for registration with the dependency service
        /// </summary>
        /// <returns></returns>
        public new static void Init()
        {
            var temp = DateTime.Now;
        }

        /// <summary>
        /// Triggered when the Element changes
        /// </summary>
        /// <param name="e">ElementChangedEventArgs</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element is CustomReturnEntry customEntry)
            {
                Control.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);

                Control.ShouldReturn += HandleControlShoudlReturn;
            }
        }

        /// <summary>
        /// Triggered when an Element Property changes
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">PropertyChangedEventArgs</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(CustomReturnEntry.ReturnTypeProperty.PropertyName))
            {
                if (Control != null && sender is CustomReturnEntry customEntry)
                    Control.ReturnKeyType = KeyboardHelpers.GetKeyboardButtonType(customEntry.ReturnType);
            }
        }

        bool HandleControlShoudlReturn(UITextField textField)
        {
            if (Element is CustomReturnEntry customEntry)
            {
                var returnCommand = customEntry.ReturnCommand;
                var returnCommandParameter = customEntry.ReturnCommandParameter;

                var canExecute = returnCommand?.CanExecute(returnCommandParameter) ?? true;

                if (canExecute)
                {
                    returnCommand?.Execute(returnCommandParameter);

                    return true;
                }
            }

            return false;
        }
    }
}
