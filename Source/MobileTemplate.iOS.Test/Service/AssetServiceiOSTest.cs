using MobileTemplate.Core.Test.Service;
using MobileTemplate.iOS.Service;
using Xunit;

namespace MobileTemplate.iOS.Test.Service
{
    public class AssetServiceiOSTest : AssetServiceTest
    {
        public AssetServiceiOSTest() : base(new AssetServiceiOS())
        {
        }

        [Fact]
        public void ReadAssetText_ShouldLoadTextFromFile_iOS()
        {
            base.ReadAssetText_ShouldLoadTextFromFile("Text/asset_sample_text_file.txt", "iOS test text");
        }
    }
}