using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ThemeSample
{
    public class DarkThemeSamplePage : ContentPage, IDisposable
    {
        public DarkThemeSamplePage()
        {
            Title = "Dark Theme Sample";
            Content = new DarkThemeSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
