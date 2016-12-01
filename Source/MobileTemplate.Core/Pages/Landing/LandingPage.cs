using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Landing
{
    public class LandingPage : ContentPage, IDisposable
    {
        public LandingPage()
        {
            Title = "Landing Page Sample";
            Content = new LandingView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
