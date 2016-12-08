using Xunit;

namespace MobileTemplate.Droid.Test.Sample
{
    public class SampleXunitDroidTests
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
