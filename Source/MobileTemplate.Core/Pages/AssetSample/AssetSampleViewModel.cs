using System;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.AssetSample
{
    public class AssetSampleViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<string> AssetText { get; }

        public AssetSampleViewModel(IAssetService assetService)
        {
            var loadingText = new ReactiveProperty<string>();
            AssetText = loadingText.ToReadOnlyReactiveProperty("Loading Text...");
            loadingText.Value = assetService.ReadAssetText("Text/asset_sample_text_file.txt");
        }

        public void Dispose()
        {
        }
    }
}
