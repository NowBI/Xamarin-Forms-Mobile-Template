# Xamarin-Forms-Mobile-Template
A simple [Xamarin Forms](https://www.xamarin.com/) project with a pre-configured Visual Studio 2015 environment, View Templates, [Themes](https://developer.xamarin.com/guides/xamarin-forms/themes/), Observables and [Reactive Properties](https://msdn.microsoft.com/en-us/library/hh242985(v=vs.103).aspx), Dependency Injection via [Autofac](https://autofac.org/), Unit Tests via [xUnit](http://xunit.github.io/), and Crash Logging via [HockeyApp](https://hockeyapp.net/) to be used as a starting point for mobile projects deployed to Android and iOS.

The projects are built targeting PCL libraries mainly because Xamarin’s dotnet standard support is still in a transitional state. 

# Getting Started

## Getting Xamarin
Head to [Xamarin.com](https://www.xamarin.com/) and download the latest version of Xamarin available. The provided installer will provide you with Xamarin, Visual Studio, the Android SDK, and anything else you may need to get started.

For more information, see [Getting Started](https://developer.xamarin.com/guides/cross-platform/getting_started/) on Xamarin's developer guide.

## Development Environment

Assuming Xamarin was fully installed and integrated into Visual Studio, the solution project should work right out of the box when you open `MobileTemplate.sln`.

Xamarin may throw a few red herring issues into your error box when you build. If so, please see the *Troubleshooting* section.

## Building Android

The **MobileTemplate.Droid** project is configured to use the latest Android platform available to you, targeting Android 4.0.3 (API Level 15 - Ice Cream Sandwich). This can be adjusted to whichever settings you prefer by right-clicking the **MobileTemplate.Droid** project and hitting "Properties". In the "Application" tab dropdowns for changing these are available.

To run the project on an Android device, simply set the Startup Project to "MobileTemplate.Droid" and the platform configuration to "Droid". Your list of emulators and connected devices should populate the run button. Select the device you want to deploy to and hit run to begin.

For more information, see [Deployment, Testing, and Metrics](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/) on Xamarin's developer guide.

## Building iOS

To build and test iOS projects on a Windows machine, you must create and connect to a Mac build agent remotely. For a guide on doing so, please see [Connecting to the Mac](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) on Xamarin's developer guide.

Once you have created a Mac build agent, you can connect to it by navigating to "Tools > iOS > Xamarin Mac Agent" in Visual Studio and following the dialog boxes. When you have successfully linked to the agent, set the Startup Project to "MobileTemplate.iOS" and the platform configuration to "iPhoneSimulator". Your list of available simulators should populate the run button. Select the device you want to deploy to and hit run to begin.

If you wish to deploy to actual devices, you must register an Apple Developer Account and create provisioning profiles for your project. See [Device Provisioning](https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/) on Xamarin's developer site for an overview of this process.

For further information, see [Deployment, Testing, and Metrics](https://developer.xamarin.com/guides/ios/deployment,_testing,_and_metrics/) on Xamarin's developer guide.

# Template Features

## Sample Views

This template project features a number of sample views that can be used as starting points for the content of your application, including a Main Menu pull-out, blog-style copy pages, e-commerce pages, forms with submission capabilities, and several examples of dependency injection and custom rendering capabilities.

Example views contain samples of both [XAML-driven](https://developer.xamarin.com/guides/xamarin-forms/xaml/) pages and manually-coded pages.

For more information about creating Xamarin Forms pages, views,view models, etcetera, see the [Xamarin Forms](https://developer.xamarin.com/guides/xamarin-forms/) section of the Xamarin developer guide.

## Themes

The template project is pre-configured with Xamarin's experimental [themeing engine](https://developer.xamarin.com/guides/xamarin-forms/themes/) with a sample theme based on the default [Light](https://developer.xamarin.com/guides/xamarin-forms/themes/light/) theme, allowing users to quickly customize the look and feel of their app to represent their intent.

For more information on customizing your theme, see [Creating a Custom Theme](https://developer.xamarin.com/guides/xamarin-forms/themes/custom/) on the Xamarin developer guide.

## Observables and Reactive Properties

To automatically hook into property changing events and have nice, responsive data flow, most of our services and view models are powered by Observables and Reactive Properties. For a primer on Observables, see [ReactiveX's Intro Page](http://reactivex.io/intro.html).

Observables can be used to quickly manipulate and process data from inputs and events. Reactive Properties are excellent for View Model binding since they can be used for both input and output.

For a simple example showing the power of observables and Reactive Properties, see `ReactiveSamplePage.cs` and its accompanying View and ViewModel.

### View Binding

In our samples, we typically use a MVVM approach to bind views with their data. For more information see [Data Binding Basics](https://developer.xamarin.com/guides/xamarin-forms/xaml/xaml-basics/data_binding_basics/) and [From Data Bindings to MVVM](https://developer.xamarin.com/guides/xamarin-forms/xaml/xaml-basics/data_bindings_to_mvvm/) in the Xamarin Developer Guide.

A view should have its BindingContext set to the View Model. Then you can bind individual objects in the view to properties of the View Model.

* We can convert an Observable into a Reactive Property with an extension method:

```C#
var reactiveProperty = observable.ToReactiveProperty();
```

* To bind to a Reactive Property to an object in XAML:

```C#
<Label Text="{Binding Name.Value}" />
```

* To bind a Reactive Property to an object programatically:

```C#
label.SetBinding(Label.TextProperty, "Name.Value")
```

## Dependency Injection and Services

To register shared components, singletons, and platform-per-platform functionality, we use Dependency Injection powered by [Autofac](https://autofac.org/).

To achieve this, we keep a static reference to our container in the `IoC.cs` class and call the method to build and publish the container in each individual app's startup procedure (`MainActivity.cs` on Android and `AppDelegate.cs` on iOS.)

Core services with functionality shared across all platforms are created and registered in the Core project. Services with per-platform functionality are interfaced and stubbed/abstracted out in the Core project and implemented and registered in the individual projects.

By following this approach you can call functions in the Core project that have implementations specific to each platform.

## Custom Renderers

Custom Renderers are used to define features and functionality for a Xamarin Forms on a Native platform. This can be used to access functionality unavailable to Xamarin Forms such as Accessibility features, platform-specific visual cues, and more.

There is a single Custom Renderer sample in the form of a Label in this project to show an example of how Custom Renderers are built and registered.

For a full guide on building and leveraging Custom Renderers see the [Custom Renderer](https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/) section of the Xamarin developer guide.

## Unit Tests

This template project features an xUnit Unit Testing suite covering both the Core and Native platforms.

### Core Unit Tests

The core unit tests cover the Core functionality of the application and can be ran in Visual Studio. These will also be run in the native unit test suites to ensure the core functionality also works on-device.

### Mobile Unit Tests

Each platform also contains a unit test project which are individual applications that can be deployed and ran on Android and iOS devices. These do not function like standard unit tests and do not hook into Visual Studio, but must be built and deployed just like standard application and run on their devices.

These unit tests will run their own suites and the core suite on-device.

These projects can be built and run just as you did the original **MobileTemplate.Droid** and **MobileTemplate.iOS** projects. See the *Building Android* and *Building iOS* sections for more info.

For more information see the [devices.xunit](https://github.com/xunit/devices.xunit) github project.

## HockeyApp

[HockeyApp](https://hockeyapp.net/) is a crash logging, metric keeping, and beta tracking tool suite that is extremely useful when working with quality assurance teams or deploying test builds to teams. It is free for users to keep track of up to two projects--which is just enough to have an Android and iOS build! You can register an account at [rink.hockeyapp.net](https://rink.hockeyapp.net/).

If you do not wish to use HockeyApp, simply uninstall the nuget packages from the Core and Mobile projects and remove the accompanying registration code in `MainActivity.cs` and `AppDelegate.cs`.

Once you have built your project and have a working APK and/or IPA, simply upload them to HockeyApp to have it automatically create your new project (it will pull all the data from your package.) When the new project is created you will get an App ID for the package. Copy and Paste that in your your `MagicStringsDroid.resx` file or your `MagicStringsiOS.resx` file (you will receive different App IDs for each platform) and any future builds will report their crashes and other metrics (if configured) to HockeyApp.

For more information on HockeyApp, its uses, and configuring it on both platforms, see the [HockeyApp Knowledge Base](https://support.hockeyapp.net/kb).

# Continuous Integration/Command-line Building

## MSBuild with Android

To build the APK with msbuild, run the following:

```shell
msbuild.exe "MobileTemplate.Droid.csproj" /t:Rebuild,SignAndroidPackage /p:Configuration="Release"
```

Please note that any distributed APK **must** be built in release mode or else the APK will crash immediately due to missing debugging tools.

If the build fails because it cannot find the Android SDK, try adding `/p:AndroidSdkDirectory="<PATH_TO_ANDROID_HOME>"` to the build config.

This can also be used to build the MobileTemplate.Droid.Test suite; simply replace the csproj directory.

For more information, see [Build Process](https://developer.xamarin.com/guides/android/under_the_hood/build_process/) in the Xamarin Developer's Guide.

## MSBuild with iOS

To build the IPA with msbuild, we must be able to access a Mac build agent as described in *Building iOS* above. We can then run the build via msbuild as follows:

```shell
msbuild.exe <MobileTemplate.iOS.csproj> /t:Rebuild /p:ServerAddress="<Mac IP>" /p:ServerUser="<Mac Username>" /p:ServerPassword="<Mac Password>" /p:Platform="iPhone" /p:Configuration="<Configuration>" /p:OutputPath="<Path to Output Directory>/" /p:IpaPackageDir="<Path to Output Directory>/" /p:BuildIpa=true
```

The `OutputPath` and `IpaPackageDir` must both end with a `/` or else the final set of the directory will be included as part of the filenames.

For more information see [Connecting to Mac](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/#Command_Line_Support) in the Xamarin Developer Guide. Please note that this is written assuming you only have on deployable iOS project (we have two--since the Unit Test Suite is its own iOS app) so their approach is a little more straight-forward.

## Deploying Builds to HockeyApp

You can deploy packages to HockeyApp via command line using curl and a HockeyApp API Token. To create a HockeyApp API Token, go to "Account Settings > API Tokens" on [rink.hockeyapp.net](https://rink.hockeyapp.net).

A sample curl command is as follows:

```shell
curl -F "status=2" -F "notify=0" -F "notes=<Patch Notes>" -F "notes_type=0" -F "ipa=@<Path to IPA or APK>" -F "commit_sha=<Commit SHA of project>" -H "X-HockeyAppToken: <API Token for your HockeyApp Account>" https://rink.hockeyapp.net/api/2/apps/upload
```

For more information see [API: Apps](https://support.hockeyapp.net/kb/api/api-apps#upload-app) in the HockeyApp API documentation.

## Mobile Unit Testing

Each unit testing project can be built as described in the above MSBuild sections.

# Troubleshooting

## Common Xamarin Issues

>The name 'XYZ' does not exist in the current context

Intellisense does not quite know how to handle Xamarin at all times. Sometimes it needs to cache things or generate code from XAML in order to know it's actually doing just fine. Try the following:

1. Build the solution twice in a row.

2. Restart Visual Studio

3. Clean and Rebuild the solution.

4. Open one of the offending view's XAML file (the .xaml file, not the .xaml.cs file) and make an inconsequential change (i.e. adding or removing whitespace) and hit Build to force Intellisense to refresh the xaml projects.

5. Right-click the Core project and Unload it, then Reload it.

For further discussion on this issue, see [this thread on the Xamarin forums](https://forums.xamarin.com/discussion/62671/initializecomponent-does-not-exist-in-the-current-context-error).

>Build action 'EmbeddedResource' is not supported by one or more of the project's targets.

Typically caused by Visual Studio not properly referencing the Xamarin build tools. Consider the following:

1. Restart Visual Studio

2. Clean and Rebuild the solution.

3. Right-click the Core project and Unload it, then Reload it.

For further discussion on this issue, see [this thread on the Xamarin forums](https://forums.xamarin.com/discussion/56559/vs-2015-errors-on-sample-projects).

>My builds hang/take a really long time.

If you're building Android or Core, make sure you're targeting the Droid or Core build configuration and don't have one of your iOs projects listed as your target build. Otherwise Visual Studio will attempt to communicate with your Mac Build Agent every time you rebuild. Alternatively, you can disconnect the Mac Build Agent in "Tools > iOS > Xamarin Mac Agent".

If you're building iOS, check the Mac Build Agent and ensure there are no popup dialogs awaiting your confirmation (i.e. allowing access to your keychain so you can use your provisioning profiles.) If it is a timing issue, unfortunately the process of compiling core binaries, transferring them to the Mac, compiling the remaining code, then transferring them back, is quite time consuming. It may be worthwhile to do iOS-specific coding and debugging directly in a Mac environment if you find it to be too time consuming.

>Visual Studio is stuck connecting to my Mac Build Agent.

Sometimes Visual Studio will get stuck trying to connect. If this happens simply close every instance of Visual Studio on your machine (make sure all devenv.exe and msbuild.exe processes are closed as well), double-check that your Mac is connected to the network, and re-launch Visual Studio.

>Android Emulator failed to start.

If you have an Android emulator currently running, close it out and kill any adb.exe and qemu-system-XXX.exe processes in your machine, then try re-running the application via Visual Studio.

>I can't deploy the Android app to my device because it says it already exists!

Sometimes your application can get in a bad state on your device and cannot be uninstalled automatically by the build system. To remedy this, on your device, go to "Settings > Apps" and manually uninstall the application. (Note that it may be named its package name instead of the actual application name.) Then re-deploy the application.

>Could not find file 'MobileTemplate.iOS.app.dSYM.zip'.

If you are building a platform configuration that builds the iOS projects and there is no Mac Build Agent connected, it will fail silently until it tries to extract the dSYM file produced by the build. Either connect to the Mac Build Agent or choose a different configuration.

*This Mobile Template is not affiliated or endorsed by Xamarin or Microsoft.*
