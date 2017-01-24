using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ThemeSample
{
    public class ThemeSamplePage : ContentPage, IDisposable
    {
        public ThemeSamplePage()
        {
            Title = "Theme Sample";
            Content = new ThemeSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
