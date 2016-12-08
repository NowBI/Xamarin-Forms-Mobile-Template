using Xunit;

namespace MobileTemplate.Droid.Test.Device.Sample
{
    public class SampleXunitTests
    {
        [Fact]
        public void PassedDroidTest()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip this Test")]
        public void SkippedDroidTest()
        {
            Assert.False(true, "We were supposed to skip this!");
        }
    }
}
