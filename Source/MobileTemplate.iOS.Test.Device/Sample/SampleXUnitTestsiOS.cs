using Xunit;

namespace MobileTemplate.iOS.Test.Device.Sample
{
    public class SampleXunitTests
    {
        [Fact]
        public void PassediOSTest()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip this Test")]
        public void SkippediOSTest()
        {
            Assert.False(true, "We were supposed to skip this!");
        }
    }
}
