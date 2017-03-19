# Custom `Xamarin.Forms.Entry` Keyboard Return Button

| ReturnType | Android | iOS | UWP |
|--------------------|---------|-----|-----| 
| **Default**            |![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/Android/DefaultButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/iOS/DefaultButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Done**            |![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/Android/DoneButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/iOS/DoneButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Go**            |![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/Android/GoButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/iOS/GoButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Next**            |![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/Android/NextButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/iOS/NextButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Search**            |![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/Android/SearchButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/iOS/SearchButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/UWP/SearchButton.png)|
| **Send**            |![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/Android/SendButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/iOS/SendButton.png)|![](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Artwork/Return%20Button%20Images/UWP/DefaultButton.png)|

**Platform Support**

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|Xamarin.iOS|Yes|iOS 8+|
|Xamarin.iOS Unified|Yes|iOS 8+|
|Xamarin.Android|Yes|API 15+|
|Windows 10 UWP|Yes|10+|
|Windows Phone Silverlight|No||
|Windows Phone RT|No||
|Windows Store RT|No||
|Xamarin.Mac|No||

# Setup 

* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.CustomReturnEntry/ [![NuGet](https://img.shields.io/nuget/v/Xam.Plugins.Forms.CustomReturnEntry.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugins.Forms.CustomReturnEntry/)
* Install into your PCL project and Client projects.

## iOS
In the `FinishedLaunching` method of `AppDelegate.cs`, add `CustomReturnEntryRenderer.Init();`:
```
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
                        ...
      
			global::Xamarin.Forms.Forms.Init();

			EntryCustomReturn.Forms.Plugin.iOS.CustomReturnEntryRenderer.Init();
  
                        ...
		}
	}
```

**Note:** You must call  `EntryCustomReturn.Forms.Plugin.iOS.CustomReturnEntryRenderer.Init();` *after* you call `Xamarin.Forms.Forms.Init();`

## Android
In the `Oncreated` method of `MainActivity.cs`, add `CustomReturnEntryRenderer.Init();`:
```
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			...

			global::Xamarin.Forms.Forms.Init(this, bundle);

			EntryCustomReturn.Forms.Plugin.Droid.CustomReturnEntryRenderer.Init();

			...
		}
	}
```
**Note:** You must call  `EntryCustomReturn.Forms.Plugin.Droid.CustomReturnEntryRenderer.Init();` *after* you call `Xamarin.Forms.Init(this, bundle);`

## UWP
In the `OnLaunched` method of `App.xaml.cs`, add `CustomReturnEntryRenderer.Init();`:
```
	public partial class App : Application
	{
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
			...

			global::Xamarin.Forms.Forms.Init(e);

			EntryCustomReturn.Forms.Plugin.UWP.CustomReturnEntryRenderer.Init();

			...
		}
	}
```
**Note:** You must call  `EntryCustomReturn.Forms.Plugin.UWP.CustomReturnEntryRenderer.Init();` *after* you call `Xamarin.Forms.Forms.Init(e);`

# Usage in Xamarin.Forms Project
The EntryCustomReturnPlugin can be consumed either as a [`CustomRenderer`](https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/entry/#Consuming_the_Custom_Control/) or as an [`Effect`](https://developer.xamarin.com/guides/xamarin-forms/effects/creating/#Consuming_the_Effect_in_C).

## Custom Renderer

### 1. Set the `ReturnType` Property
 
The `ReturnType` Property is an enum containing 6 different types: Default, Go, Next, Done, Send, Search.

```
var goReturnTypeCustomEntry = new CustomReturnEntry
{
	ReturnType = ReturnType.Go
};
```

It can also be used as a [Bindable Property to bind to a ViewModel](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Samples/EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L25)
```
var viewModel = new MyViewModel();
var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(CustomReturnEntry.ReturnTypeProperty, nameof(viewModel.EntryReturnType));
```

### 2. Set the `ReturnCommand` Command
 
 `ReturnCommand` will fire when the user finalizes the text in an entry with the return key.
 
```
goReturnTypeCustomEntry.ReturnCommand = new Command(() => Navigation.PushAsync(new ContentPage())); 
```

It can also be used as a [Bindable Property to bind to a ViewModel](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Samples/EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L195)
```
 var viewModel = new MyViewModel();
 var customReturnEntry = new CustomReturnEntry();
 customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandProperty, nameof(viewModel.EntryReturnCommand));
```

## Effect

### 1. Set the `ReturnType` Property

The `ReturnType` Property is an enum containing 6 different types: Default, Go, Next, Done, Send, Search.

```
var goReturnTypeEntry = new Entry()
ReturnTypeEffect.SetReturnType(goReturnTypeEntry, ReturnType.Go);
```

It can also be used as a [Bindable Property to bind to a ViewModel](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Samples/EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L21)

```
var viewModel = new MyViewModel();
var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(ReturnTypeEffect.ReturnTypeProperty, nameof(viewModel.EntryReturnType));
```

### 2. Set the `ReturnCommand` Command
 
 `ReturnCommand` will fire when the user finalizes the text in an entry with the return key.
 ```
 ReturnTypeEffect.SetReturnCommand(goReturnTypeEntry, new Command(() => Navigation.PushAsync(new ContentPage()));
 ```
 
 It can also be used as a [Bindable Property to bind to a ViewModel](https://github.com/brminnick/EntryCustomReturnPlugin/blob/master/Samples/EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L192)
 ```
 var viewModel = new MyViewModel();
 var customReturnEntry = new CustomReturnEntry();
 customReturnEntry.SetBinding(ReturnTypeEffect.ReturnCommandProperty, nameof(viewModel.EntryReturnCommand));
 ```

![iPhone Demo](./Artwork/iOS%20Gif.gif)
