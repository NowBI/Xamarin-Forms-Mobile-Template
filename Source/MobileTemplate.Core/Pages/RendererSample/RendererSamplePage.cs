using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.RendererSample
{
    public class RendererSamplePage : ContentPage, IDisposable
    {
        public RendererSamplePage()
        {
            Title = "Renderer Sample";
            Content = new RendererSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
