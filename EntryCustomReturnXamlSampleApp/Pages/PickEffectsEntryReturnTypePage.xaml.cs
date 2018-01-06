using System;
using System.Collections.Generic;

using Xamarin.Forms;

using EntryCustomReturn.Forms.Plugin.Abstractions;

using MvvmSamples.Common.Forms;

namespace EntryCustomReturnXamlSampleApp
{
    public partial class PickEffectsEntryReturnTypePage : BaseContentPage<PickEntryReturnTypeViewModel>
    {
        public PickEffectsEntryReturnTypePage()
        {
            InitializeComponent();

            CustomizableEntry.SetBinding(CustomReturnEffect.ReturnTypeProperty, nameof(ViewModel.EntryReturnType));
        }

        protected override void SubscribeEventHandlers()
        {

        }

        protected override void UnsubscribeEventHandlers()
        {

        }
    }
}
