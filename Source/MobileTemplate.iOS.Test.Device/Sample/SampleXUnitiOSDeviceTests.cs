using Xunit;

namespace MobileTemplate.iOS.Test.Device.Sample
{
    public class SampleXUnitiOSDeviceTests
    {
        [Fact]
        public void PassediOSDeviceTest()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip this Test")]
        public void SkippediOSDeviceTest()
        {
            Assert.False(true, "We were supposed to skip this!");
        }
    }
}
