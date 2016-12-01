using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ReactiveSample
{
    public class ReactiveSamplePage : ContentPage, IDisposable
    {
        public ReactiveSamplePage()
        {
            Title = "Reactive Sample";
            Content = new ReactiveSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
