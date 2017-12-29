using MobileTemplate.Core.Test.Service;
using MobileTemplate.Droid.Service;
using Xunit;

namespace MobileTemplate.Droid.Test.Service
{
    public class AssetServiceiOSTest : AssetServiceTest
    {
        public AssetServiceiOSTest() : base(new AssetServiceDroid())
        {
        }

        [Fact]
        public void ReadAssetText_ShouldLoadTextFromFile_Droid()
        {
            base.ReadAssetText_ShouldLoadTextFromFile("Text/asset_sample_text_file.txt", "Droid test text");
        }
    }
}