using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.ServiceSample
{
    public class ServiceSamplePage : ContentPage, IDisposable
    {
        public ServiceSamplePage()
        {
            Title = "Service Sample";
            Content = new ServiceSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
