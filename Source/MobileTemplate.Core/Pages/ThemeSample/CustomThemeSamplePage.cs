using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ThemeSample
{
    public class CustomThemeSamplePage : ContentPage, IDisposable
    {
        public CustomThemeSamplePage()
        {
            Title = "Custom Theme Sample";
            Content = new CustomThemeSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
