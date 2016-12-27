using System;
using Autofac;
using MobileTemplate.Core.Extensions;
using MobileTemplate.Core.Services;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.AssetSample
{
    public partial class AssetSampleView : ScrollView, IDisposable
    {
        public AssetSampleView()
        {
            InitializeComponent();
            var assetService = IoC.Container.Resolve<IAssetService>();
            var viewModel = new AssetSampleViewModel(assetService);
            BindingContext = viewModel;
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
