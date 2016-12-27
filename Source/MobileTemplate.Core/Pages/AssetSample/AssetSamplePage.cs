using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.AssetSample
{
    public class AssetSamplePage : ContentPage, IDisposable
    {
        public AssetSamplePage()
        {
            Title = "Asset Sample";
            Content = new AssetSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
