using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ThemeSample
{
    public class LightThemeSamplePage : ContentPage, IDisposable
    {
        public LightThemeSamplePage()
        {
            Title = "Light Theme Sample";
            Content = new LightThemeSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
