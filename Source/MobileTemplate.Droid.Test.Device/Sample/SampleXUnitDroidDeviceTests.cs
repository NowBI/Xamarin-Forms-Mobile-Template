using Xunit;

namespace MobileTemplate.Droid.Test.Device.Sample
{
    public class SampleXunitDroidDeviceTests
    {
        [Fact]
        public void PassedDroidDeviceTest()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip this Test")]
        public void SkippedDroidDeviceTest()
        {
            Assert.False(true, "We were supposed to skip this!");
        }
    }
}
