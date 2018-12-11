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

This plugin can be consumed as a [`CustomRenderer Control`](./README.md#usage-in-xamarinforms-project-as-a-custom-control) or as an [`Effect`](./README.md#usage-in-xamarinforms-project-as-an-effect).

# Setup

* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.CustomReturnEntry/ [![NuGet](https://img.shields.io/nuget/v/Xam.Plugins.Forms.CustomReturnEntry.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugins.Forms.CustomReturnEntry/) [![NuGet](https://img.shields.io/nuget/dt/Xam.Plugins.Forms.CustomReturnEntry.svg?label=Downloads)](https://www.nuget.org/packages/AsyncAwaitBestPractices/)
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

        EntryCustomReturn.Forms.Plugin.Android.CustomReturnEntryRenderer.Init();

        ...
    }
}
```

**Note:** You must call  `EntryCustomReturn.Forms.Plugin.Android.CustomReturnEntryRenderer.Init();` *after* you call `global::Xamarin.Forms.Forms.Init(this, bundle);`

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

# Usage in Xamarin.Forms Project as a Custom Control

This plugin can be consumed as a [`CustomRenderer Control`](./README.md#usage-in-xamarinforms-project-as-a-custom-control) or as an [`Effect`](./README.md#usage-in-xamarinforms-project-as-an-effect).

## 1. Set the `ReturnType` Property

The `ReturnType` property is an enum containing 6 different types: Default, Go, Next, Done, Send, Search.

#### Coded UI

```csharp
var goReturnTypeCustomEntry = new CustomReturnEntry
{
    ReturnType = EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Go
};
```

#### XAML UI

```xml
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="SimpleXamlSample.CustomRendererPage"
    xmlns:entryCustomReturn="clr-namespace:EntryCustomReturn.Forms.Plugin.Abstractions;assembly=EntryCustomReturn.Forms.Plugin.Abstractions">

    <ContentPage.Content>

        <entryCustomReturn:CustomReturnEntry
            x:Name = "MyCustomReturnEntry"
            HorizontalOptions="Center"
            VerticalOptions="Center"
            ReturnType="Go"/>

    </ContentPage.Content>
</ContentPage>
```

### Bindable Property

`ReturnType` can also be used as a `Bindable Property` to bind to a ViewModel

#### Coded UI

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(CustomReturnEntry.ReturnTypeProperty, nameof(MyViewModel.EntryReturnType));
```

#### XAML UI

```xml
<entryCustomReturn:CustomReturnEntry
    x:Name = "MyCustomReturnEntry"
    HorizontalOptions="Center"
    VerticalOptions="Center"
    ReturnType="{Binding EntryReturnType}"/>
```

## 2. Set the `ReturnCommand` Command

`ReturnCommand` will fire when the user finalizes the text in an entry with the return key.

#### Coded UI

```csharp
goReturnTypeCustomEntry.ReturnCommand = new Command(() => Navigation.PushAsync(new ContentPage()));
```

#### XAML UI
Use the [Coded UI example above](./README.md#coded-ui-2) to initialize a `Command` in the XAML Code Behind

### Bindable Property

`ReturnCommand` can also be used as a `Bindable Property` to bind to a ViewModel

#### Coded UI

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandProperty nameof(MyViewModel.EntryReturnCommand));
```

#### XAML UI

```xml
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:local="clr-namespace:SimpleXamlSample"
    x:Class="SimpleXamlSample.CustomRendererPage"
    xmlns:entryCustomReturn="clr-namespace:EntryCustomReturn.Forms.Plugin.Abstractions;assembly=EntryCustomReturn.Forms.Plugin.Abstractions"
    BindingContext="{Binding Source={local:MyViewModel}}">

    <ContentPage.Content>

        <entryCustomReturn:CustomReturnEntry
            x:Name = "MyCustomReturnEntry"
            HorizontalOptions="Center"
            VerticalOptions="Center"
            ReturnCommand="{Binding EntryReturnCommand}"/>

    </ContentPage.Content>
</ContentPage>
```

### 3. Set the `ReturnCommandParameter` Property

The `ReturnCommandParameter` property is an object that can be passed to the `ReturnCommand` property.

#### Coded UI

```csharp
goReturnTypeCustomEntry.ReturnCommand = new Command<string>(async title => await DisplayAlert(title, "", "Ok"));
goReturnTypeCustomEntry.ReturnCommandParameter = "Return Button Tapped";
```

#### XAML UI

```xml
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="SimpleXamlSample.CustomRendererPage"
    xmlns:entryCustomReturn="clr-namespace:EntryCustomReturn.Forms.Plugin.Abstractions;assembly=EntryCustomReturn.Forms.Plugin.Abstractions">

    <ContentPage.Content>

        <entryCustomReturn:CustomReturnEntry
            x:Name = "MyCustomReturnEntry"
            HorizontalOptions="Center"
            VerticalOptions="Center"
            ReturnCommandParameter="Return Button Tapped"/>

    </ContentPage.Content>
</ContentPage>
```

### Bindable Property

`ReturnCommandParameter` can also be used as a `Bindable Property` to bind to a ViewModel

#### Coded UI

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new CustomReturnEntry();
customReturnEntry.SetBinding(CustomReturnEntry.ReturnCommandParameterProperty, nameof(MyViewModel.EntryReturnCommandParameter));
```

#### XAML UI

```xml

<entryCustomReturn:CustomReturnEntry
    x:Name = "MyCustomReturnEntry"
    HorizontalOptions="Center"
    VerticalOptions="Center"
    ReturnCommandParameter="{Binding EntryReturnCommandParameter}"/>
```

# Usage in Xamarin.Forms Project as an Effect

This plugin can be consumed as a [`CustomRenderer Control`](./README.md#usage-in-xamarinforms-project-as-a-custom-control) or as an [`Effect`](./README.md#usage-in-xamarinforms-project-as-an-effect).

## 1. Set the `ReturnType` Property

The `ReturnType` property is an enum containing 6 different types: Default, Go, Next, Done, Send, Search.

#### Coded UI

```csharp
var goReturnTypeEntry = new Entry()
CustomReturnEffect.SetReturnType(goReturnTypeEntry, EntryCustomReturn.Forms.Plugin.Abstractions.ReturnType.Go);
```

#### XAML UI

```xml
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="SimpleXamlSample.CustomRendererPage"
    xmlns:entryCustomReturn="clr-namespace:EntryCustomReturn.Forms.Plugin.Abstractions;assembly=EntryCustomReturn.Forms.Plugin.Abstractions">

    <ContentPage.Content>

        <Entry
            x:Name = "GoReturnTypeEntry"
            HorizontalOptions="Center"
            VerticalOptions="Center"
            entryCustomReturn:CustomReturnEffect.ReturnType="{x:Static entryCustomReturn:ReturnType.Default}"/>


    </ContentPage.Content>
</ContentPage>
```

### Bindable Property

`ReturnType` can also be used as a `Bindable Property` to bind to a ViewModel

#### Coded UI

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new Entry();
customReturnEntry.SetBinding(CustomReturnEffect.ReturnTypeProperty, nameof(MyViewModel.EntryReturnType));
```

#### XAML UI

```xml
<Entry
    x:Name = "GoReturnTypeEntry"
    HorizontalOptions="Center"
    VerticalOptions="Center"
    entryCustomReturn:CustomReturnEffect.ReturnType="{Binding EntryReturnType}"/>
```

### 2. Set the `ReturnCommand` Command

`ReturnCommand` will fire when the user finalizes the text in an entry with the return key.

#### Coded UI

```csharp
var goReturnTypeEntry = new Entry()
CustomReturnEffect.SetReturnCommand(goReturnTypeEntry, new Command(() => Navigation.PushAsync(new ContentPage()));
```

#### XAML UI

Use the [Coded UI example above](./README.md#coded-ui-8) to initialize a `Command` in the XAML Code Behind

### Bindable Property

`ReturnCommand` can also be used as a `Bindable Property` to bind to a ViewModel

#### Coded UI

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new Entry();
customReturnEntry.SetBinding(CustomReturnEffect.ReturnCommandProperty, nameof(MyViewModel.EntryReturnCommand));
```

#### XAML UI

```xml
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:local="SimpleXamlSample"
    x:Class="SimpleXamlSample.CustomRendererPage"
    xmlns:entryCustomReturn="clr-namespace:EntryCustomReturn.Forms.Plugin.Abstractions;assembly=EntryCustomReturn.Forms.Plugin.Abstractions"
    BindingContext="{Binding Source={local:MyViewModel}}">

    <ContentPage.Content>

        <entryCustomReturn:CustomReturnEntry
            x:Name = "MyCustomReturnEntry"
            HorizontalOptions="Center"
            VerticalOptions="Center"
            entryCustomReturn:CustomReturnEffect.ReturnCommand="{Binding EntryReturnCommand}"/>

    </ContentPage.Content>
</ContentPage>
```

### 3. Set the `ReturnCommandParameter` Property

The `ReturnCommandParameter` property is an object that can be passed to the `ReturnCommand` property.

#### Coded UI

```csharp
var goReturnTypeEntry = new Entry()
CustomReturnEffect.SetReturnCommand(goReturnTypeEntry, new Command<string>(async title => await DisplayAlert(title, "", "Ok")));
CustomReturnEffect.SetReturnCommandParameter(goReturnTypeEntry, "Return Button Tapped");
```

#### XAML UI

```xml
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="SimpleXamlSample.CustomRendererPage"
    xmlns:entryCustomReturn="clr-namespace:EntryCustomReturn.Forms.Plugin.Abstractions;assembly=EntryCustomReturn.Forms.Plugin.Abstractions">

    <ContentPage.Content>

        <entryCustomReturn:CustomReturnEntry
            x:Name = "MyCustomReturnEntry"
            HorizontalOptions="Center"
            VerticalOptions="Center"
            entryCustomReturn:CustomReturnEffect.ReturnCommandParameter="Return Button Tapped"/>

    </ContentPage.Content>
</ContentPage>
```

### Bindable Property

`ReturnCommandParameter` can also be used as a `Bindable Property` to bind to a ViewModel

#### Coded UI

```csharp
var viewModel = new MyViewModel();
BindingContext = viewModel;

var customReturnEntry = new Entry();
customReturnEntry.SetBinding(CustomReturnEffect.ReturnCommandParameterProperty, nameof(MyViewModel.EntryReturnCommandParameter));
```

#### XAML UI

```xml
<entryCustomReturn:CustomReturnEntry
    x:Name = "MyCustomReturnEntry"
    HorizontalOptions="Center"
    VerticalOptions="Center"
    entryCustomReturn:CustomReturnEffect.ReturnCommandParameter="{Binding EntryReturnCommandParameter}"/>
```
