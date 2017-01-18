using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using HockeyApp;
using HockeyApp.Android;
using MobileTemplate.Core;
using CrashManager = HockeyApp.Android.CrashManager;

namespace MobileTemplate.Droid
{
    [Activity(Label = "MobileTemplate", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            RegisterHockeyApp();
            BuildIoCContainer();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnregisterHockeyApp();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UnregisterHockeyApp();
        }

        private void BuildIoCContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterCoreDependencies();
            builder.RegisterDroidDependencies();
            builder.Publish();
        }

        private void RegisterHockeyApp()
        {
            if (MagicStringsDroid.HockeyAppId?.Length == 32)
            {
                CrashManager.Register(this, MagicStringsDroid.HockeyAppId);
                UpdateManager.Register(this, MagicStringsDroid.HockeyAppId);
            }
        }

        private void UnregisterHockeyApp()
        {
            UpdateManager.Unregister();
        }
    }
}

