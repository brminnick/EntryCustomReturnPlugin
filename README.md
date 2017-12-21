[![Build Status](https://www.bitrise.io/app/01a7d986a483dc66/status.svg?token=rLlWyVD2Qe1pY9nZy-mN0A&branch=master)](https://www.bitrise.io/app/01a7d986a483dc66)

# Custom `Xamarin.Forms.Entry` Keyboard Return Button

| ReturnType | Android | iOS | UWP |
|--------------------|---------|-----|-----|
| **Default**            |![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/Android/DefaultButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/iOS/DefaultButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Done**            |![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/Android/DoneButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/iOS/DoneButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Go**            |![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/Android/GoButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/iOS/GoButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Next**            |![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/Android/NextButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/iOS/NextButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/UWP/DefaultButton.png)|
| **Search**            |![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/Android/SearchButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/iOS/SearchButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/UWP/SearchButton.png)|
| **Send**            |![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/Android/SendButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/iOS/SendButton.png)|![](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/Return%20Button%20Images/UWP/DefaultButton.png)|

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

```csharp
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

**Note:** You must call  `EntryCustomReturn.Forms.Plugin.iOS.CustomReturnEntryRenderer.Init();` *after* you call `global::Xamarin.Forms.Forms.Init();`

## Android

In the `Oncreated` method of `MainActivity.cs`, add `CustomReturnEntryRenderer.Init();`:

```csharp
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

**Note:** You must call  `EntryCustomReturn.Forms.Plugin.Droid.CustomReturnEntryRenderer.Init();` *after* you call `global::Xamarin.Forms.Forms.Init(this, bundle);`

## UWP

In the `OnLaunched` method of `App.xaml.cs`, add `CustomReturnEntryRenderer.Init();`:

```csharp
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

**Note:** You must call  `EntryCustomReturn.Forms.Plugin.UWP.CustomReturnEntryRenderer.Init();` *after* you call `global::Xamarin.Forms.Forms.Init(e);`

# Usage in Xamarin.Forms Project

The EntryCustomReturnPlugin can be consumed either as a [`CustomRenderer`](https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/entry/#Consuming_the_Custom_Control/) or as an [`Effect`](https://developer.xamarin.com/guides/xamarin-forms/effects/creating/#Consuming_the_Effect_in_C).

## Custom Renderer

### 1. Set the `ReturnType` Property

The `ReturnType` property is an enum containing 6 different types: Default, Go, Next, Done, Send, Search.

```csharp
var goReturnTypeCustomEntry = new CustomReturnEntry
{
    ReturnType = ReturnType.Go
};
```

It can also be used as a [Bindable Property to bind to a ViewModel](./EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L25)

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(CustomReturnEntry.ReturnTypeProperty, nameof(viewModel.EntryReturnType));
```

### 2. Set the `ReturnCommand` Command

`ReturnCommand` will fire when the user finalizes the text in an entry with the return key.

```csharp
goReturnTypeCustomEntry.ReturnCommand = new Command(() => Navigation.PushAsync(new ContentPage()));
```

It can also be used as a [Bindable Property to bind to a ViewModel](./EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L185)

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandProperty nameof(viewModel.EntryReturnCommand));
```

### 3. Set the `ReturnCommandParameter` Property (New in v3.3.0)

The `ReturnCommandParameter` property is an object that can be passed to the `ReturnCommand` property.

```csharp
goReturnTypeCustomEntry.ReturnCommand = new Command<string>(async title => await DisplayAlert(title, "", "Ok"));
goReturnTypeCustomEntry.ReturnCommandParameter = "Return Button Tapped";
```

It can also be used as a Bindable Property to bind to a ViewModel

```csharp
var viewModel = new ViewModel();
BindingContext = viewModel;

var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandParameterProperty, nameof(viewModel.EntryReturnCommandParameter));
```

## Effect

### 1. Set the `ReturnType` Property

The `ReturnType` property is an enum containing 6 different types: Default, Go, Next, Done, Send, Search.

```csharp
var goReturnTypeEntry = new Entry()
CustomReturnEffect.SetReturnType(goReturnTypeEntry, ReturnType.Go);
```

It can also be used as a [Bindable Property to bind to a ViewModel](./EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L21)

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new Entry();
customReturnEntry.SetBinding(CustomReturnEffect.ReturnTypeProperty, nameof(viewModel.EntryReturnType));
```

### 2. Set the `ReturnCommand` Command

`ReturnCommand` will fire when the user finalizes the text in an entry with the return key.

```csharp
var goReturnTypeEntry = new Entry()
CustomReturnEffect.SetReturnCommand(goReturnTypeEntry, new Command(() => Navigation.PushAsync(new ContentPage()));
```

It can also be used as a [Bindable Property to bind to a ViewModel](./EntryCustomReturnSampleApp/Helpers/ViewHelpers.cs#L188)

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new Entry();
customReturnEntry.SetBinding(CustomReturnEffect.ReturnCommandProperty, nameof(viewModel.EntryReturnCommand));
```

### 3. Set the `ReturnCommandParameter` Property (New in v3.3.0)

The `ReturnCommandParameter` property is an object that can be passed to the `ReturnCommand` property.

```csharp
var goReturnTypeEntry = new Entry()
CustomReturnEffect.SetReturnCommand(goReturnTypeEntry, new Command<string>(async title => await DisplayAlert(title, "", "Ok")));
CustomReturnEffect.SetReturnCommandParameter(goReturnTypeEntry, "Return Button Tapped");
```

It can also be used as a Bindable Property to bind to a ViewModel

```csharp
var viewModel = new ViewModel();
BindingContext = viewModel;

var customReturnEntry = new Entry();
customReturnEntry.SetBinding(CustomReturnEffect.ReturnCommandParameterProperty, nameof(viewModel.EntryReturnCommandParameter));
```

![iPhone Demo](https://github.com/brminnick/Videos/blob/master/EntryCustomReturnPlugin/iOS%20Gif.gif)
